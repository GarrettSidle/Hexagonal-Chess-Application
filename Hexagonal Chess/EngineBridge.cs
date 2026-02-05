using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Hexagonal_Chess
{
    /// <summary>
    /// Result of parsing an engine move line. For en passant, CapturedCol/CapturedRow are the captured pawn's square.
    /// </summary>
    public sealed class EngineMoveResult
    {
        public int FromCol { get; }
        public int FromRow { get; }
        public int ToCol { get; }
        public int ToRow { get; }
        public bool IsEnPassant { get; }
        public int? CapturedCol { get; }
        public int? CapturedRow { get; }

        public EngineMoveResult(int fromCol, int fromRow, int toCol, int toRow, bool isEnPassant = false, int? capturedCol = null, int? capturedRow = null)
        {
            FromCol = fromCol;
            FromRow = fromRow;
            ToCol = toCol;
            ToRow = toRow;
            IsEnPassant = isEnPassant;
            CapturedCol = capturedCol;
            CapturedRow = capturedRow;
        }
    }

    /// <summary>
    /// Runs the C++ engine process and communicates via stdin/stdout for single-player.
    /// Engine can play white or black; local player color is randomized at game start.
    /// </summary>
    public static class EngineBridge
    {
        private static Process _process;
        private static StreamWriter _stdin;
        private static StreamReader _stdout;
        private static readonly object _lock = new object();
        private static bool _initialized;
        private static EngineMoveResult _engineFirstMove;
        private static StreamReader _stderr;
        private static System.Threading.Tasks.Task _stderrReadTask;
        private static Timer _heartbeatTimer;

        /// <summary>Fired whenever a line is read from the engine's stdout or stderr (for UI terminal).</summary>
        public static event Action<string> EngineOutput;

        private static string GetEnginePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] candidates = new[]
            {
                // Project Engine folder: Hexagonal Chess\Engine\engine.exe (place engine.exe here)
                Path.GetFullPath(Path.Combine(baseDir, "..", "..", "Engine", "engine.exe")),
                Path.GetFullPath(Path.Combine(baseDir, "Engine", "engine.exe")),
                Path.GetFullPath(Path.Combine(baseDir, "engine.exe")),
                Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "Engine", "build", "Release", "engine.exe")),
                Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "Engine", "Release", "engine.exe"))
            };
            foreach (string path in candidates)
            {
                if (File.Exists(path))
                    return path;
            }
            return null;
        }

        /// <summary>
        /// Get startup command for variant: 0 = Glinski, 1 = McCooey, 2 = Hexofen.
        /// </summary>
        private static string GetVariantCommand(int gameVariant, bool enginePlaysWhite)
        {
            string name;
            switch (gameVariant)
            {
                case 1: name = "mccooey"; break;
                case 2: name = "hexofen"; break;
                default: name = "glinski"; break;
            }
            return enginePlaysWhite ? name + " white" : name;
        }

        /// <summary>
        /// Start the engine and send variant command (e.g. "glinski", "mccooey white"). When enginePlaysWhite is true,
        /// reads the engine's first move and stores it for GetEngineFirstMove().
        /// </summary>
        /// <param name="enginePlaysWhite">True if engine plays white.</param>
        /// <param name="gameVariant">0 = Glinski, 1 = McCooey, 2 = Hexofen.</param>
        public static bool Start(bool enginePlaysWhite, int gameVariant = 0)
        {
            lock (_lock)
            {
                if (_initialized)
                    return _stdin != null;

                _engineFirstMove = null;
                string exePath = GetEnginePath();
                if (string.IsNullOrEmpty(exePath))
                    return false;

                EngineOutput?.Invoke("[Engine] Using: " + exePath);

                try
                {
                    var si = new ProcessStartInfo
                    {
                        FileName = exePath,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        WorkingDirectory = Path.GetDirectoryName(exePath)
                    };
                    _process = Process.Start(si);
                    _stdin = _process.StandardInput;
                    _stdout = _process.StandardOutput;
                    _stderr = _process.StandardError;
                    _stderrReadTask = System.Threading.Tasks.Task.Run(() =>
                    {
                        try
                        {
                            string errLine;
                            while (_stderr != null && (errLine = _stderr.ReadLine()) != null)
                                EngineOutput?.Invoke("[err] " + errLine);
                        }
                        catch { }
                    });
                    string cmd = GetVariantCommand(gameVariant, enginePlaysWhite);
                    _stdin.WriteLine(cmd);
                    _stdin.Flush();
                    string posName;
                    switch (gameVariant)
                    {
                        case 1: posName = "mccooey"; break;
                        case 2: posName = "hexofen"; break;
                        default: posName = "glinski"; break;
                    }
                    string posPrefix = "position " + posName;
                    // Read until we have consumed startup output. Expect "thinking....." then "Engine Move (White): ...".
                    while (true)
                    {
                        string line = _stdout.ReadLine();
                        if (line == null)
                            break;
                        line = line.Trim();
                        EngineOutput?.Invoke(line);
                        if (line.StartsWith(posPrefix, StringComparison.OrdinalIgnoreCase))
                        {
                            if (!enginePlaysWhite)
                                break;
                            continue;
                        }
                        if (line.StartsWith("thinking.", StringComparison.OrdinalIgnoreCase))
                            continue;
                        if (enginePlaysWhite && line.StartsWith("Engine Move (White):", StringComparison.OrdinalIgnoreCase))
                        {
                            _engineFirstMove = ParseEngineMoveLine(line);
                            if (_engineFirstMove != null)
                                break;
                        }
                    }
                    _initialized = true;
                    StartHeartbeatTimer();
                    return true;
                }
                catch
                {
                    _process = null;
                    _stdin = null;
                    _stdout = null;
                    return false;
                }
            }
        }

        /// <summary>
        /// After Start(true), returns the engine's first (white) move, or null. Call once after load when local player is black.
        /// </summary>
        public static EngineMoveResult GetEngineFirstMove()
        {
            lock (_lock)
            {
                var move = _engineFirstMove;
                _engineFirstMove = null;
                return move;
            }
        }

        /// <summary>
        /// Send white's move (e.g. "a1b2" or "PeP a5 b6 c6") and read until "Engine Move (Black): ...", then parse and return move result.
        /// Returns null on failure or if engine returns "(none)".
        /// </summary>
        public static Task<EngineMoveResult> GetBlackMoveAsync(string whiteMoveNotation)
        {
            return Task.Run(() =>
            {
                lock (_lock)
                {
                    if (_stdin == null || _stdout == null)
                        return null;

                    try
                    {
                        _stdin.WriteLine(whiteMoveNotation.ToLowerInvariant());
                        _stdin.Flush();

                        string line;
                        while ((line = _stdout.ReadLine()) != null)
                        {
                            line = line.Trim();
                            EngineOutput?.Invoke(line);
                            if (line.StartsWith("thinking.", StringComparison.OrdinalIgnoreCase))
                                continue;
                            if (line.StartsWith("Player Move (", StringComparison.OrdinalIgnoreCase))
                                continue;
                            if (line.StartsWith("Engine Move (Black):", StringComparison.OrdinalIgnoreCase))
                                return ParseEngineMoveLine(line);
                        }
                    }
                    catch
                    {
                        // ignore
                    }
                    return null;
                }
            });
        }

        /// <summary>
        /// Send black's move and read until "Engine Move (White): ...", then return engine's (white) move result.
        /// Returns null on failure or if engine returns "(none)".
        /// </summary>
        public static Task<EngineMoveResult> GetWhiteMoveAsync(string blackMoveNotation)
        {
            return Task.Run(() =>
            {
                lock (_lock)
                {
                    if (_stdin == null || _stdout == null)
                        return null;
                    try
                    {
                        _stdin.WriteLine(blackMoveNotation.ToLowerInvariant());
                        _stdin.Flush();
                        string line;
                        while ((line = _stdout.ReadLine()) != null)
                        {
                            line = line.Trim();
                            EngineOutput?.Invoke(line);
                            if (line.StartsWith("thinking.", StringComparison.OrdinalIgnoreCase))
                                continue;
                            if (line.StartsWith("Player Move (", StringComparison.OrdinalIgnoreCase))
                                continue;
                            if (line.StartsWith("Engine Move (White):", StringComparison.OrdinalIgnoreCase))
                                return ParseEngineMoveLine(line);
                        }
                    }
                    catch { }
                    return null;
                }
            });
        }

        /// <summary>
        /// Parse a line like "Engine Move (White): P E7 E6", "Engine Move (White): PeP A5 B6 C6", or "Engine Move (Black): (none)".
        /// PeP format: PeP {pawn start} {pawn end} {captured pawn location}. Returns null on (none) or parse failure.
        /// </summary>
        private static EngineMoveResult ParseEngineMoveLine(string line)
        {
            if (line == null)
                return null;
            int colon = line.IndexOf(':');
            if (colon < 0)
                return null;
            string rest = line.Substring(colon + 1).Trim();
            if (rest.StartsWith("(none)", StringComparison.OrdinalIgnoreCase))
                return null;
            string[] parts = rest.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // PeP {start} {end} {captured}
            if (parts.Length >= 4 && parts[0].Equals("PeP", StringComparison.OrdinalIgnoreCase))
            {
                var from = ParseSquare(parts[1]);
                var to = ParseSquare(parts[2]);
                var captured = ParseSquare(parts[3]);
                if (from != null && to != null && captured != null)
                    return new EngineMoveResult(from.Item1, from.Item2, to.Item1, to.Item2, true, captured.Item1, captured.Item2);
            }
            if (parts.Length >= 3)
            {
                var from = ParseSquare(parts[1]);
                var to = ParseSquare(parts[2]);
                if (from != null && to != null)
                    return new EngineMoveResult(from.Item1, from.Item2, to.Item1, to.Item2);
            }
            if (parts.Length >= 1 && parts[0].Length >= 4)
            {
                string compact = parts[0].ToLowerInvariant();
                if (compact.Length >= 4)
                {
                    int c1 = compact[0] - 'a', r1 = compact[1] - '0' - 1;
                    int c2 = compact[2] - 'a', r2 = compact[3] - '0' - 1;
                    if (c1 >= 0 && c1 < 11 && r1 >= 0 && c2 >= 0 && c2 < 11 && r2 >= 0)
                        return new EngineMoveResult(c1, r1, c2, r2);
                }
            }
            return null;
        }

        private static Tuple<int, int> ParseSquare(string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            int col = char.ToUpperInvariant(s[0]) - 'A';
            if (col < 0 || col >= 11)
                return null;
            int row;
            if (!int.TryParse(s.Substring(1), out row) || row < 1)
                return null;
            row -= 1;
            return Tuple.Create(col, row);
        }

        private static void StartHeartbeatTimer()
        {
            StopHeartbeatTimer();
            _heartbeatTimer = new Timer(_ =>
            {
                lock (_lock)
                {
                    if (_stdin == null || (_process != null && _process.HasExited))
                    {
                        StopHeartbeatTimer();
                        return;
                    }
                    try
                    {
                        _stdin.WriteLine("heartbeat");
                        _stdin.Flush();
                    }
                    catch (ObjectDisposedException) { StopHeartbeatTimer(); }
                    catch (IOException) { StopHeartbeatTimer(); }
                }
            }, null, 500, 500);  // First after 500ms, then every 500ms
        }

        private static void StopHeartbeatTimer()
        {
            try
            {
                _heartbeatTimer?.Dispose();
                _heartbeatTimer = null;
            }
            catch { }
        }

        /// <summary>
        /// Kill the engine process. Call when leaving single-player or closing the board.
        /// </summary>
        public static void Stop()
        {
            lock (_lock)
            {
                _initialized = false;
                StopHeartbeatTimer();
                try
                {
                    if (_stdin != null)
                    {
                        _stdin.WriteLine("quit");
                        _stdin.Flush();
                        _stdin.Close();
                        _stdin = null;
                    }
                }
                catch { }
                try
                {
                    if (_process != null && !_process.HasExited)
                    {
                        _process.Kill();
                    }
                    _process = null;
                }
                catch { }
                _stdout = null;
                _stderr = null;
            }
        }
    }
}
