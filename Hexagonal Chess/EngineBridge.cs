using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Hexagonal_Chess
{
    /// <summary>Parsed engine move. En passant uses CapturedCol/Row for captured pawn.</summary>
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

    /// <summary>C++ engine over stdin/stdout. Plays white or black, we randomize who.</summary>
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

        /// <summary>Fired when we read a line from engine stdout/stderr.</summary>
        public static event Action<string> EngineOutput;

        private static string GetEnginePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] candidates = new[]
            {
                // engine.exe lives in Engine folder
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

        /// <summary>Startup cmd: 0=Glinski 1=McCooey 2=Hexofen. e.g. glinski white 3000.</summary>
        private static string GetVariantCommand(int gameVariant, bool enginePlaysWhite, int maxNodes)
        {
            string name;
            switch (gameVariant)
            {
                case 1: name = "mccooey"; break;
                case 2: name = "hexofen"; break;
                default: name = "glinski"; break;
            }
            string cmd = enginePlaysWhite ? name + " white" : name;
            return cmd + " " + maxNodes.ToString();
        }

        /// <summary>Start engine, send variant cmd. If engine plays white we read first move for GetEngineFirstMove.</summary>
        public static bool Start(bool enginePlaysWhite, int gameVariant = 0, int maxNodes = 1500)
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
                    string cmd = GetVariantCommand(gameVariant, enginePlaysWhite, maxNodes);
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
                    // consume startup output til we get Engine Move line
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

        /// <summary>After Start(true), returns engines first white move or null. Call once when we're black.</summary>
        public static EngineMoveResult GetEngineFirstMove()
        {
            lock (_lock)
            {
                var move = _engineFirstMove;
                _engineFirstMove = null;
                return move;
            }
        }

        /// <summary>Send white move, read til Engine Move (Black), return result or null.</summary>
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

        /// <summary>Send black move, read til Engine Move (White), return result or null.</summary>
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

        /// <summary>Parse Engine Move line. PeP = start end captured. Returns null on (none) or fail.</summary>
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
            }, null, 500, 500);  // first 500ms then every 500ms
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

        /// <summary>Kill engine. Call when leaving single player or closing board.</summary>
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
