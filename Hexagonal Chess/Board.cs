using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Hexagonal_Chess.Properties;
using System.Net.Sockets;
using System.Reflection;

using static Hexagonal_Chess.Utils;
using static Hexagonal_Chess.FindMoves;

namespace Hexagonal_Chess
{
    public partial class FrmBoard : Form
    {
        //find the size of each hexagon based on the screen size
        readonly int hexRadius = (int) Math.Round(Screen.PrimaryScreen.Bounds.Height / 25.0);

        private void FrmBoard_Load(object sender, EventArgs e)
        {
            // Board reset and engine start are done in updateGameMode()/resetBoard() so they run every new game
            updateTurnIndicator();
            updatePlayerLabels();
        }

        /// <summary>
        /// Set "White" / "Black" labels and append "(You)" next to the color the local player controls (Host/Client/Bot/Pass and Play).
        /// </summary>
        private void updatePlayerLabels()
        {
            bool youAreWhite = false;
            bool youAreBlack = false;
            switch (userMode)
            {
                case 0: // Play vs Bot: randomized at game start
                    youAreWhite = localPlayerIsWhite;
                    youAreBlack = !localPlayerIsWhite;
                    break;
                case 1: // Host: typically you are white
                    youAreWhite = true;
                    break;
                case 2: // Client: you are black
                    youAreBlack = true;
                    break;
                case 3: // Pass and Play: both sides are "you"
                    youAreWhite = true;
                    youAreBlack = true;
                    break;
                default:
                    break;
            }
            lblBottomName.Text = youAreWhite ? "White (You)" : "White";
            lblUser.Text = youAreBlack ? "Black (You)" : "Black";
        }

        private void updateTurnIndicator()
        {

            var activeColor = Color.FromArgb(136, 171, 95);
            var inactiveColor = Color.Transparent;

            if (board.whiteToPlay)
            {
                pnlTurnIndicatorWhite.BackColor = activeColor;
                pnlTurnIndicatorBlack.BackColor = inactiveColor;
            }
            else
            {
                pnlTurnIndicatorBlack.BackColor = activeColor;
                pnlTurnIndicatorWhite.BackColor = inactiveColor;
            }
        }

        //stores the location for each hexagon based on its location notation on the board
        private readonly IDictionary<string, Hexagon> boardNodes = new Dictionary<string, Hexagon>();

        //stores each piece based on its location notation within the board
        private readonly IDictionary<string, PictureBox> boardPieces = new Dictionary<string, PictureBox>();

        //stores the action buttons for later retrival (Panel = hitbox, PictureBox inside = icon)
        private readonly List<Panel> MovementButtons = new List<Panel>();
        private readonly List<Panel> CaptureButtons = new List<Panel>();

        public FrmBoard()
        {
            InitializeComponent();
            this.FormClosing += FrmBoard_FormClosing;

            // Enable double buffering to reduce flicker during repaints
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(pnlGame, true);

            buildBoard();
            popultateActionButtons();
        }

        private void FrmBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            EndGameAndDisconnect();
        }

        /// <summary>
        /// Disconnect from bot or other player and release resources. Call when leaving the board (FormClosing or Back to Home).
        /// </summary>
        private void EndGameAndDisconnect()
        {
            if (userMode == 0)
            {
                EngineBridge.EngineOutput -= OnEngineOutput;
                EngineBridge.Stop();
            }
            else
            {
                MessageReceiver.DoWork -= MessageReceiver_DoWork;
                MessageReceiver.RunWorkerCompleted -= MessageReceiver_RunWorkerCompleted;
                CleanupMultiplayer();
            }
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            try
            {
                EndGameAndDisconnect();
                MDIParent.swapScreen("Home");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error going to Home");
            }
        }

        private void OnEngineOutput(string line)
        {
            if (txtEngineOutput == null || txtEngineOutput.IsDisposed)
                return;
            if (InvokeRequired)
                BeginInvoke(new Action(() => AppendEngineLine(line)));
            else
                AppendEngineLine(line);
        }

        private void AppendEngineLine(string line)
        {
            if (txtEngineOutput == null || txtEngineOutput.IsDisposed)
                return;
            txtEngineOutput.AppendText(line + Environment.NewLine);
            txtEngineOutput.SelectionStart = txtEngineOutput.Text.Length;
            txtEngineOutput.ScrollToCaret();
        }

        private static void CleanupMultiplayer()
        {
            try { sock?.Close(); sock = null; } catch { }
            try { client?.Close(); client = null; } catch { }
            try { server?.Stop(); server = null; } catch { }
        }

        internal static void CleanupMultiplayerStatic()
        {
            CleanupMultiplayer();
        }

        private void popultateActionButtons()
        {
            pnlGame.SuspendLayout();

            //create the max of 37 movement buttons
            for (int i = 0; i <  37; i++)
            {
                createActionButton(true, i);
            }
            //create the max of 9 capture buttons
            for (int i = 0; i < 9; i++)
            {
                createActionButton(false, i);
            }

            pnlGame.ResumeLayout(false);
        }

        private void createActionButton(bool isMovementButton, int index) 
        {
            // Icon size (visible) - same as before
            int iconSize = (int)Math.Round(hexRadius * (isMovementButton ? 1.0 : .65));
            // Hitbox size - ~1.1x larger for easier clicking
            int hitboxSize = (int)Math.Round(iconSize * 1.3);

            // Panel = large invisible hitbox
            Panel hitbox = new Panel();
            hitbox.Size = new Size(hitboxSize, hitboxSize);
            hitbox.Location = new Point(0, 0);
            hitbox.Name = isMovementButton ? "MovementButton " : "CaptureButton" + index;
            hitbox.BackColor = Color.Transparent;

            // PictureBox = icon at original size, centered in hitbox
            PictureBox tempImage = new PictureBox();
            tempImage.Size = new Size(iconSize, iconSize);
            tempImage.Location = new Point((hitboxSize - iconSize) / 2, (hitboxSize - iconSize) / 2);
            tempImage.BackColor = isMovementButton ? Color.Transparent : Color.Black;
            tempImage.SizeMode = PictureBoxSizeMode.StretchImage;

            if (isMovementButton)
            {
                tempImage.Image = Resources.AvailableMove;
            }

            hitbox.Controls.Add(tempImage);
            hitbox.Cursor = Cursors.Hand;
            this.pnlGame.Controls.Add(hitbox);
            hitbox.BringToFront();
            hitbox.Visible = false;

            (isMovementButton ? MovementButtons : CaptureButtons).Add(hitbox);
        }

        //swap the board to a new player mode
        public void updateGameMode()
        {
            if (userMode == 1) // Host mode
            {
                if (sock == null)
                    return;
                MessageReceiver.DoWork -= MessageReceiver_DoWork;
                MessageReceiver.DoWork += MessageReceiver_DoWork;
                MessageReceiver.RunWorkerCompleted -= MessageReceiver_RunWorkerCompleted;
                MessageReceiver.RunWorkerCompleted += MessageReceiver_RunWorkerCompleted;
                if (!MessageReceiver.IsBusy)
                    MessageReceiver.RunWorkerAsync();
            }
            else if (userMode == 2) // Client mode
            {
                try
                {
                    client = new TcpClient(Utils.IP, Utils.GamePort);
                    sock = client.Client;
                    byte[] ready = new byte[] { 0x01 };
                    sock.Send(ready);
                    MessageReceiver.DoWork -= MessageReceiver_DoWork;
                    MessageReceiver.DoWork += MessageReceiver_DoWork;
                    MessageReceiver.RunWorkerCompleted -= MessageReceiver_RunWorkerCompleted;
                    MessageReceiver.RunWorkerCompleted += MessageReceiver_RunWorkerCompleted;
                    MessageReceiver.RunWorkerAsync();
                    MDIParent.swapScreen("Board");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            updatePlayerLabels();
            pnlEngineTerminal.Visible = (userMode == 0);
            resetBoard();

            // Start engine for single-player (runs every new game; Load only runs once so we do it here)
            if (userMode == 0)
            {
                pnlEngineTerminal.BringToFront();
                txtEngineOutput.Clear();
                EngineBridge.EngineOutput += OnEngineOutput;
                bool enginePlaysWhite = !localPlayerIsWhite;
                if (!EngineBridge.Start(enginePlaysWhite, Utils.gameVarient))
                {
                    MessageBox.Show("Engine not found. Place engine.exe in the Hexagonal Chess\\Engine\\ folder (or same folder as this app).", "Single Player");
                }
                else if (!localPlayerIsWhite)
                {
                    var firstMove = EngineBridge.GetEngineFirstMove();
                    if (firstMove != null)
                    {
                        int fromCol = firstMove.FromCol, fromRow = firstMove.FromRow, toCol = firstMove.ToCol, toRow = firstMove.ToRow;
                        if (fromCol >= 0 && fromCol < board.gameBoard.Length)
                        {
                            var colList = board.gameBoard[fromCol];
                            if (colList != null && fromRow >= 0 && fromRow < colList.Count)
                            {
                                Piece whitePiece = colList[fromRow];
                                if (whitePiece != null && whitePiece.isWhite)
                                {
                                    LocNotation toLoc = new LocNotation(toCol, toRow);
                                    Piece captured = null;
                                    if (firstMove.IsEnPassant && firstMove.CapturedCol.HasValue && firstMove.CapturedRow.HasValue)
                                    {
                                        int cc = firstMove.CapturedCol.Value, cr = firstMove.CapturedRow.Value;
                                        if (cc >= 0 && cc < board.gameBoard.Length)
                                        {
                                            var capList = board.gameBoard[cc];
                                            if (capList != null && cr >= 0 && cr < capList.Count)
                                                captured = capList[cr];
                                        }
                                    }
                                    else if (toCol >= 0 && toCol < board.gameBoard.Length)
                                    {
                                        var toColList = board.gameBoard[toCol];
                                        if (toRow >= 0 && toRow < toColList?.Count)
                                            captured = toColList[toRow];
                                    }
                                    Move engineMove = new Move(whitePiece, toLoc, captured != null || firstMove.IsEnPassant, firstMove.IsEnPassant, captured?.pieceType ?? (firstMove.IsEnPassant ? 'P' : (char?)null));
                                    makeMove(engineMove, board, boardPieces, boardNodes, this);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void resetBoard()
        {
            pnlGame.SuspendLayout();

            // Clear pieces from previous game so we don't get "An item with the same key has already been added"
            foreach (var kv in boardPieces)
            {
                if (kv.Value != null && pnlGame.Controls.Contains(kv.Value))
                {
                    pnlGame.Controls.Remove(kv.Value);
                    kv.Value.Dispose();
                }
            }
            boardPieces.Clear();

            // Reset game state so a new game doesn't show the previous game's position/moves/eval
            board.setBoard();
            lblBottomEval.Text = "";
            lblTopEval.Text = "";
            lblBottomUserEval.Text = "";
            lblTopUserEval.Text = "";
            dgMoves.Rows.Clear();

            int rowMax = 5;

            for (int col = 0; col < 11; col++)
            {
                for (int row = 0; row <= rowMax; row++)
                {
                    // Use the same hexagon positions as boardNodes (from buildBoard) so piece positions
                    // match the drawn hexagons and makeMove targets. Recomputing from pnlGame size here
                    // caused wrong initial positions for the client, since the client calls swapScreen
                    // before resetBoard, so pnlGame may already be resized while boardNodes still has
                    // constructor-time positions.
                    string notation = ((char)(col + 65)).ToString() + (row + 1).ToString();
                    Point tempLocation = boardNodes.TryGetValue(notation, out Hexagon hex)
                        ? hex.location
                        : new Point(0, 0);

                    placeStartingPieces(col, row, tempLocation);
                }
                if (col < 5)
                    rowMax++;
                else
                    rowMax--;
            }

            pnlGame.ResumeLayout(false);
            updateTurnIndicator();
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            ReceiveMove();
        }

        private void ReceiveMove()
        {
            FrmBoard frmBoard = (FrmBoard)MDIParent.getScreen("Board");
            byte[] buffer;
            try
            {
                buffer = new byte[5];
                int received = sock.Receive(buffer);
                if (received <= 0)
                {
                    InvokeConnectionLost(frmBoard);
                    return;
                }
            }
            catch (SocketException)
            {
                InvokeConnectionLost(frmBoard);
                return;
            }
            catch (ObjectDisposedException)
            {
                return;
            }

            int atkPieceCol = buffer[0];
            int atkPieceRow = buffer[1];
            int capturedCol = buffer[2];
            int capturedRow = buffer[3];
            byte flags = buffer.Length > 4 ? buffer[4] : (byte)0;
            bool enPassant = (flags & 0x01) != 0;
            bool isCapture = enPassant || (board.gameBoard[capturedCol] != null && capturedRow < board.gameBoard[capturedCol].Count && board.gameBoard[capturedCol][capturedRow] != null);
            char? capturedType = null;
            if (isCapture && board.gameBoard[capturedCol] != null && capturedRow < board.gameBoard[capturedCol].Count)
            {
                Piece cap = board.gameBoard[capturedCol][capturedRow];
                if (cap != null) capturedType = cap.pieceType;
                else if (enPassant) capturedType = 'P';
            }

            Piece piece = board.gameBoard[atkPieceCol][atkPieceRow];
            if (piece == null)
                return;
            Move move = new Move(piece, new LocNotation(capturedCol, capturedRow), isCapture, enPassant, capturedType);

            // Marshal makeMove to UI thread
            if (frmBoard.InvokeRequired)
                frmBoard.Invoke(new Action(() => makeMove(move, board, boardPieces, boardNodes, frmBoard)));
            else
                makeMove(move, board, boardPieces, boardNodes, frmBoard);
        }

        private void MessageReceiver_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (userMode != 0 && sock != null && sock.Connected && !MessageReceiver.IsBusy)
                MessageReceiver.RunWorkerAsync();
        }

        private void InvokeConnectionLost(FrmBoard frmBoard)
        {
            CleanupMultiplayer();
            if (frmBoard.IsHandleCreated)
                frmBoard.Invoke(new Action(() =>
                {
                    MessageBox.Show("Connection lost.", "Connection");
                    MDIParent.swapScreen("Home");
                }));
        }

        /// <summary>
        /// Format move for engine: "PeP {start} {end} {captured}" for en passant (e instead of x), else "startend" (e.g. a1b2).
        /// </summary>
        private static string GetMoveNotationForEngine(Move move)
        {
            string start = move.startLocation.notation.ToLowerInvariant();
            string end = move.endLocation.notation.ToLowerInvariant();
            if (move.enPassent)
            {
                int capRow = move.endLocation.row + (move.piece.isWhite ? -1 : 1);
                var capturedLoc = new LocNotation(move.endLocation.col, capRow);
                string captured = capturedLoc.notation.ToLowerInvariant();
                return "PeP " + start + " " + end + " " + captured;
            }
            return start + end;
        }

        private void SendMove(Move move)
        {
            // Only send over network for Host (1) or Client (2). Pass and Play (3) is local only.
            if (userMode == 1 || userMode == 2)
            {
                byte flags = (byte)(move.enPassent ? 0x01 : 0x00);
                byte[] datas = { (byte)move.piece.locNotation.col, (byte)move.piece.locNotation.row, (byte)move.endLocation.col, (byte)move.endLocation.row, flags };
                sock.Send(datas);
                if (!MessageReceiver.IsBusy)
                    MessageReceiver.RunWorkerAsync();
            }
            // Turn is swapped in makeMove(); do not swap here or we double-swap (turn would stay the same).
        }

        private void buildBoard()
        {
            pnlGame.SuspendLayout();

            //The distance from the center of a hexagon to center of any of its lines
            int hexShortradius = (int)Math.Round((hexRadius / 2) * Math.Sqrt(3));

            //find the point that centers the board horizontally
            int x = (int)Math.Round((pnlGame.Width / 2) + (hexRadius * 0.0)); //7.78
            //find the point that centers the board vertical
            int y = (int)Math.Round((pnlGame.Height / 2) + (hexRadius * 8.0)); //4.26

            //Starting point of the entire board, this will be center of A1
            Point startingPosition = new Point(x, y);

            int rowMax = 5;

            //used for calculating each hexagons colors
            int rowColorCode = 0;
            int colColorCode = 0;


            //for each hexagon on the board
            for (int col = 0; col < 11; col++)
            {
                for (int row = 0; row <= rowMax; row++)
                {
                    //Find the location of the next node
                    Point tempLocation = new Point(
                            (int)(Math.Round(startingPosition.X + (col * hexShortradius * (.9) * 2))),
                        startingPosition.Y - (row * hexShortradius * 2) + ((col < 6 ? col : (10 - col)) * hexShortradius));

                    //add hexagons to the collection
                    placeHexagons(rowColorCode, colColorCode, col, row, tempLocation);

                    //increase the color code
                    colColorCode++;

                    //if we are in the first hexagon of the row
                    if (col == 0 || (row - col == 5 && col > 0 && col < 6))
                    {
                        //place the row labels
                        placeLabel(
                            (row + 1).ToString(),
                            (int)Math.Round(startingPosition.X + (col * hexShortradius * (.9) * 2)) - hexRadius - 15,
                            startingPosition.Y - (row * hexShortradius * 2) + ((col < 6 ? col : (10 - col)) * hexShortradius) - hexShortradius
                            );
                    }

                }
                //if we are in the first 6 rows
                if (col < 5)
                {
                    //add another row
                    rowMax++;
                    rowColorCode++;
                }
                //otherwise
                else
                {
                    //remove another row
                    rowMax--;
                    rowColorCode--;

                }
                //reset the col code for each new column
                colColorCode = 0;

                //place a column label under the first hexagon in each column
                placeLabel(
                    ((char)(col + 65)).ToString(),
                    (int)(Math.Round(startingPosition.X + (col * hexShortradius * (.9) * 2))) - 10,
                    startingPosition.Y + ((col < 6 ? col : (10 - col)) * hexShortradius + (hexRadius))
                );
            }

            pnlGame.ResumeLayout(false);
        }

        private void placeLabel(string text, int x, int y)
        {
            //create a label
            Label colLabel = new Label();
            colLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            colLabel.ForeColor = Color.FromArgb(80, 70, 60);
            colLabel.BackColor = Color.Transparent;
            colLabel.Width = 30;
            //input the custom values
            colLabel.Text = text;
            colLabel.Location = new Point(x,y);
            //add it to the board
            pnlGame.Controls.Add(colLabel);
        }

        private void placeStartingPieces(int col, int row, Point tempLocation)
        {

            Piece piece = board.gameBoard[col][row];

            //if the square is empty
            if (piece == null)
            { 
                //end the function
                return;
            }
            
            //find the piece image based on the piece type
            Image pieceImage;
            switch (char.ToUpper(piece.pieceType))
            {
                case 'P':
                    pieceImage = piece.isWhite ? Resources.WhitePawn : Resources.BlackPawn;
                    break;

                case 'R':
                    pieceImage = piece.isWhite ? Resources.WhiteRook : Resources.BlackRook;
                    break;

                case 'N':
                    pieceImage = piece.isWhite ? Resources.WhiteKnight : Resources.BlackKnight;
                    break;

                case 'B':
                    pieceImage = piece.isWhite ? Resources.WhiteBishop : Resources.BlackBishop;
                    break;

                case 'K':
                    pieceImage = piece.isWhite ? Resources.WhiteKing : Resources.BlackKing;
                    break;

                case 'Q':
                    pieceImage = piece.isWhite ? Resources.WhiteQueen : Resources.BlackQueen;
                    break;

                default:
                    pieceImage = null;
                    break;
            }
            //set the defualt image values
            int size = (int)Math.Round(hexRadius * 1.55);
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(size, size);
            pictureBox.Image = pieceImage;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BackColor = Color.Transparent;
            //input the piece specific values
            pictureBox.Name = piece.pieceType + piece.locNotation.notation;
            pictureBox.Location = new Point(tempLocation.X - size / 2, tempLocation.Y - size / 2);
            //create the click even for adding action buttons
            pictureBox.Click += (sender, EventArgs) => { Piece_Click(sender, EventArgs, piece); };
            //add the image to the screen
            this.pnlGame.Controls.Add(pictureBox);

            LocNotation tempNotation = piece.locNotation;


            //add the piece to the piece dictionary for later retrieval
            boardPieces.Add(tempNotation.notation, pictureBox);
        }

        private void Move_Click(object sender, EventArgs e, Move move)
        {
            //if we are not in single player
            if (Utils.userMode != 0)
            {   
                //send the move to the other player
                SendMove(move);
            }

            //make the move
            makeMove(move, board, boardPieces, boardNodes, (FrmBoard)MDIParent.getScreen("Board"));

            // single player: send our move to engine and apply engine's reply
            if (Utils.userMode == 0)
            {
                string moveNotation = GetMoveNotationForEngine(move);
                Task<EngineMoveResult> engineTask = localPlayerIsWhite
                    ? EngineBridge.GetBlackMoveAsync(moveNotation)
                    : EngineBridge.GetWhiteMoveAsync(moveNotation);
                bool wePlayWhite = localPlayerIsWhite;
                FrmBoard frmBoard = this; // capture form that received the move so callback can Invoke on it
                engineTask.ContinueWith(t =>
                {
                    if (t.IsFaulted || t.Result == null)
                        return;
                    var result = t.Result;
                    int fromCol = result.FromCol, fromRow = result.FromRow, toCol = result.ToCol, toRow = result.ToRow;
                    if (fromCol < 0 || fromCol >= board.gameBoard.Length)
                        return;
                    var colList = board.gameBoard[fromCol];
                    if (colList == null || fromRow < 0 || fromRow >= colList.Count)
                        return;
                    Piece enginePiece = colList[fromRow];
                    if (enginePiece == null || enginePiece.isWhite == wePlayWhite)
                        return; // engine's piece: white when we're black, black when we're white — skip if it's our color
                    // Ensure piece's locNotation matches (fromCol, fromRow) so makeMove finds it in boardPieces
                    enginePiece.locNotation = new LocNotation(fromCol, fromRow);
                    LocNotation toLoc = new LocNotation(toCol, toRow);
                    Piece captured = null;
                    if (result.IsEnPassant && result.CapturedCol.HasValue && result.CapturedRow.HasValue)
                    {
                        int cc = result.CapturedCol.Value, cr = result.CapturedRow.Value;
                        if (cc >= 0 && cc < board.gameBoard.Length)
                        {
                            var capList = board.gameBoard[cc];
                            if (capList != null && cr >= 0 && cr < capList.Count)
                                captured = capList[cr];
                        }
                    }
                    else if (toCol >= 0 && toCol < board.gameBoard.Length)
                    {
                        var toColList = board.gameBoard[toCol];
                        if (toRow >= 0 && toRow < toColList?.Count)
                            captured = toColList[toRow];
                    }
                    Move engineMove = new Move(enginePiece, toLoc, captured != null || result.IsEnPassant, result.IsEnPassant, captured?.pieceType ?? (result.IsEnPassant ? 'P' : (char?)null));
                    if (frmBoard.IsDisposed || !frmBoard.IsHandleCreated)
                        return;
                    try
                    {
                        frmBoard.Invoke(new Action(() =>
                        {
                            if (frmBoard.IsDisposed) return;
                            if (!boardPieces.ContainsKey(engineMove.piece.locNotation.notation))
                                return;
                            makeMove(engineMove, board, boardPieces, boardNodes, frmBoard);
                        }));
                    }
                    catch (ObjectDisposedException) { }
                    catch (InvalidOperationException) { }
                    catch (KeyNotFoundException) { }
                }, TaskScheduler.Default);
            }
        }


        public void removeActionButtons()
        {
            //for each action button remove the click event and hide the button
            foreach (Panel hitbox in MovementButtons)
            {
                hitbox.Visible = false;
                RemoveEvent(hitbox, "EventClick");
                if (hitbox.Controls.Count > 0)
                    RemoveEvent(hitbox.Controls[0], "EventClick");
            }
            foreach (Panel hitbox in CaptureButtons)
            {
                hitbox.Visible = false;
                RemoveEvent(hitbox, "EventClick");
                if (hitbox.Controls.Count > 0)
                    RemoveEvent(hitbox.Controls[0], "EventClick");
            }
        }

        // Remove all event handlers from the control's named event.
        private void RemoveEvent(Control ctl, string event_name)
        {
            FieldInfo field_info = typeof(Control).GetField(event_name,
                BindingFlags.Static | BindingFlags.NonPublic);

            PropertyInfo property_info = ctl.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);

            object obj = field_info.GetValue(ctl);
            EventHandlerList event_handlers =
                (EventHandlerList)property_info.GetValue(ctl, null);
            event_handlers.RemoveHandler(obj, event_handlers[obj]);
        }


        private void Piece_Click(object s, EventArgs e, Piece piece)
        {
            // Only allow clicking pieces that belong to the local player
            bool isMyPiece = (userMode == 0 && (piece.isWhite == localPlayerIsWhite))  // Play vs Bot: randomized
                || (userMode == 1 && piece.isWhite)             // Host: I am white
                || (userMode == 2 && !piece.isWhite)             // Client: I am black
                || (userMode == 3 && (piece.isWhite == board.whiteToPlay)); // Pass and Play: side to move
            if (!isMyPiece)
                return;

            // If it is not that piece's turn to move, ignore
            if (!(piece.isWhite == board.whiteToPlay))
                return;
            //remove all the active action buttons
            removeActionButtons();

            List<Move> availableMoves;
            //get all of the available moves for the selected piece
            availableMoves = FindPieceMoves(piece);



            Point tempLocation;
            
            //keeps track of the current capture button index
            int captureCount = 0;

            //for each available move
            for (int i = 0; i < availableMoves.Count; i++)
            {

                Move move = availableMoves[i];

                //LocNotation tempNotation = offsetRightBoard(move.endLocation);
                LocNotation tempNotation = move.endLocation;


                //Get the location of the hexagon on the screen
                tempLocation = boardNodes[tempNotation.notation].location;

                PictureBox tempImage;

                //if we are taking a piece
                Panel hitbox;
                if (move.isCapture)
                {
                    //use a capture button 
                    hitbox = CaptureButtons[captureCount];
                    captureCount++;
                }
                else
                {
                    //otherwise, show a movement button
                    hitbox = MovementButtons[i];
                }
                //add the click event to both hitbox and icon (icon is hitbox.Controls[0])
                EventHandler moveHandler = (sender, ev) => Move_Click(sender, ev, move);
                hitbox.Click += moveHandler;
                hitbox.Controls[0].Click += moveHandler;

                //place movement buttons (center the hitbox on the hex)
                hitbox.Location = new Point(tempLocation.X - hitbox.Width / 2, tempLocation.Y - hitbox.Height / 2);
                hitbox.Visible = true;

            }


        }
        private void makeMove(Move move, Board board, IDictionary<string, PictureBox> boardPieces, IDictionary<string, Hexagon> boardNodes, FrmBoard frmBoard)
        {
            //remove all visiable action buttons
            removeActionButtons();

            LocNotation startLocation = move.piece.locNotation;
            LocNotation endLocation = move.endLocation;

            bool endGame = false;

            LocNotation tempEndLocation = endLocation;
            LocNotation eendLocation = endLocation;

            //if a piece was taken
            if (move.isCapture)
            {
                Piece capturedPiece;
                PictureBox capturedPieceImage;

                if (move.enPassent)
                {

                    LocNotation enPassantLocation = new LocNotation(endLocation.col, endLocation.row + (move.piece.isWhite ? -1 : 1));

                    //get the piece object that is being captured
                    capturedPiece = board.gameBoard[enPassantLocation.col][enPassantLocation.row];
                    capturedPieceImage = boardPieces[enPassantLocation.notation];
                }
                else
                {
                    //get the piece object that is being captured
                    capturedPiece = board.gameBoard[endLocation.col][endLocation.row];
                    capturedPieceImage = boardPieces[endLocation.notation];
                }

                // so the moves table can show e.g. ♕x♕F11 (moving piece x captured piece square)
                move.capturedPieceType = capturedPiece.pieceType;

                //remove the pieces image
                capturedPieceImage.Visible = false;
                frmBoard.Controls.Remove(capturedPieceImage);

                //remove the piece from the dictionary
                boardPieces.Remove(endLocation.notation);

                //if the move is white, add to the eval, if black subtract
                int newEvaluation = board.whiteToPlay ? board.evaluation + capturedPiece.value : board.evaluation - capturedPiece.value;

                //update the evaluation
                board.setEval(newEvaluation, capturedPiece);

                //if the piece that was taken was a king then store endgame as true
                endGame = (capturedPiece.pieceType == 'K');
            }

            //move the piece image to the new location
            Point hexCenter = boardNodes[tempEndLocation.notation].location;

            PictureBox pieceImage = boardPieces[startLocation.notation];


            //set the previous move
            board.prevMove = move;

            //replace the key with the new location
            boardPieces.Remove(startLocation.notation);
            boardPieces.Add(eendLocation.notation, pieceImage);

            //place the piece in the center of the hex
            pieceImage.Location = new Point(hexCenter.X - pieceImage.Height / 2, hexCenter.Y - pieceImage.Width / 2);

            //Change the pieces location
            move.piece.locNotation = new LocNotation(endLocation.col, endLocation.row);

            //if we are a pawn on the last rank
            if (pawnPromotion(move))
            {
                //promote the pawn to a queen
                move.piece = new Piece(move.piece.locNotation, 'Q', move.piece.isWhite);

                //update the image
                pieceImage.Image = move.piece.isWhite ? Properties.Resources.WhiteQueen : Properties.Resources.BlackQueen;
                pieceImage.Click += (sender, EventArgs) => { Piece_Click(sender, EventArgs, move.piece); };
            }

            //update the internal board
            board.gameBoard[startLocation.col][startLocation.row] = null;
            board.gameBoard[endLocation.col][endLocation.row] = move.piece;

            //add the move to the move table
            updateMoveTable(move, board, frmBoard);


            //change it to the opposing teams move
            board.swapTurns();
            updateTurnIndicator();

            // Redraw the board so the last-move arrow is shown
            frmBoard.pnlGame.Invalidate();

            //if the king has been captured
            if (endGame)
            {
                //find the number of moves in the game
                int numOfMoves = dgMoves.Rows.Count + (move.piece.isWhite ? 1 : 0);
                // Winner is the side that captured the king (the side that just moved)
                bool whiteWins = move.piece.isWhite;
                ResultScreen resultScreen = new ResultScreen();
                resultScreen.setWinner(whiteWins, numOfMoves);
                resultScreen.ShowDialog();
            }
        }

        private bool pawnPromotion(Move move)
        {
            int col = move.endLocation.col;
            int row = move.endLocation.row;

            //if it is a not pawn
            if (move.piece.pieceType != 'P')
            {
                return false;
            }
            //if we are white
            if (move.piece.isWhite)
            {
                //if we are on the left side of the board
                if (col <= 5)
                {
                    //find final row for right side
                    return row - col == 5;
                }
                //if we are on the right side of the board
                else
                {
                    //find final row for left side
                    return col + row == 15;
                }
            }
            //if we are black
            else
            {
                //0 is always the final row for black
                return row == 0;
            }
        }

        private static void updateMoveTable(Move move, Board board, FrmBoard frmBoard)
        {
            //add the move the datagrid
            string pieceCharcter = pieceChars[move.piece.pieceType];
            string moveNotation;
            if (move.isCapture && move.capturedPieceType.HasValue)
                moveNotation = pieceCharcter + "x" + pieceChars[move.capturedPieceType.Value] + move.endLocation.notation;
            else
                moveNotation = pieceCharcter + move.moveNotation.TrimStart(move.piece.pieceType);


            DataGridView movesTable = frmBoard.dgMoves;

            DataGridViewRow row;

            int currentRow = movesTable.Rows.Count;

            // Use the piece color to decide white vs black (not board.whiteToPlay, which may already be swapped)
            bool wasWhitesMove = move.piece.isWhite;

            if (wasWhitesMove)
            {
                string[] strRow = new string[] { "", "", "" };

                movesTable.Rows.Add(strRow);

                //input the move number
                movesTable.Rows[currentRow].Cells[0].Value = currentRow + 1;
                //input whites last move
                movesTable.Rows[currentRow].Cells[1].Value = moveNotation;

                //select the row
                movesTable.ClearSelection();
                movesTable.Rows[currentRow].Selected = true;
            }
            else
            {
                // Black's move: fill in the last row (must exist from white's move)
                if (currentRow <= 0)
                    return; // guard: no row to fill (should not happen in normal play)
                row = movesTable.Rows[currentRow - 1];
                row.Cells[2].Value = moveNotation;

                movesTable.ClearSelection();
                movesTable.Rows[currentRow - 1].Selected = true;
            }

            // Scroll to show the most recent move
            int lastRowIndex = movesTable.Rows.Count - 1;
            if (lastRowIndex >= 0)
            {
                movesTable.FirstDisplayedScrollingRowIndex = lastRowIndex;
            }
        }

        public static void stripEval()
        {
            FrmBoard frmBoard = (FrmBoard)MDIParent.getScreen("Board");

            Label whiteEvalLabel = frmBoard.lblBottomUserEval;
            Label blackEvalLabel = frmBoard.lblTopUserEval;

            Label whiteBarEval = frmBoard.lblBottomEval;
            Label blackBarEval = frmBoard.lblTopEval;

            //remove the +X from the current winner
            if (whiteEvalLabel.Text.Contains('+'))
            {
                //find the plus
                int plusLocation = whiteEvalLabel.Text.IndexOf("+");
                //remove everything after the plus
                whiteEvalLabel.Text = whiteEvalLabel.Text.Substring(0, plusLocation);
            }
            if (blackEvalLabel.Text.Contains('+'))
            {
                //find the plus
                int plusLocation = blackEvalLabel.Text.IndexOf("+");
                //remove everything after the plus
                blackEvalLabel.Text = blackEvalLabel.Text.Substring(0, plusLocation);
            }

            //clear both bar evals
            whiteBarEval.Text = "";
            blackBarEval.Text = "";
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            //for each calculated hexagon location
            foreach (KeyValuePair<string, Hexagon> node in boardNodes)
            {
                //draw the hexagon
                Hexagon.DrawHexagon(node.Value, e, hexRadius);
            }

            // Draw arrow for the most recent move (same green as application buttons)
            if (board.prevMove != null &&
                boardNodes.TryGetValue(board.prevMove.startLocation.notation, out Hexagon startHex) &&
                boardNodes.TryGetValue(board.prevMove.endLocation.notation, out Hexagon endHex))
            {
                Point startPoint = startHex.location;
                Point endPoint = endHex.location;
                Color arrowColor = Color.FromArgb(136, 171, 95);

                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                float dx = endPoint.X - startPoint.X;
                float dy = endPoint.Y - startPoint.Y;
                float len = (float)Math.Sqrt(dx * dx + dy * dy);
                if (len >= 2f)
                {
                    float ux = dx / len;
                    float uy = dy / len;
                    // Inset from both hex centers so the arrow doesn't overlap the pieces
                    float inset = hexRadius * 0.32f;
                    float lineStartX = startPoint.X + ux * inset;
                    float lineStartY = startPoint.Y + uy * inset;
                    float lineEndX = endPoint.X - ux * inset;
                    float lineEndY = endPoint.Y - uy * inset;
                    float lineLen = (float)Math.Sqrt((lineEndX - lineStartX) * (lineEndX - lineStartX) + (lineEndY - lineStartY) * (lineEndY - lineStartY));
                    if (lineLen >= 2f)
                    {
                        float arrowLen = Math.Min(hexRadius * 0.45f, lineLen * 0.3f);
                        float arrowW = arrowLen * 0.65f;
                        PointF tip = new PointF(lineEndX, lineEndY);
                        PointF baseCenter = new PointF(tip.X - ux * arrowLen, tip.Y - uy * arrowLen);
                        PointF perp = new PointF(-uy * arrowW, ux * arrowW);
                        PointF[] head = new PointF[]
                        {
                            tip,
                            new PointF(baseCenter.X + perp.X, baseCenter.Y + perp.Y),
                            new PointF(baseCenter.X - perp.X, baseCenter.Y - perp.Y)
                        };

                        using (var pen = new Pen(arrowColor, 8f))
                        using (var brush = new SolidBrush(arrowColor))
                        {
                            g.DrawLine(pen, lineStartX, lineStartY, baseCenter.X, baseCenter.Y);
                            g.FillPolygon(brush, head);
                        }
                    }
                }
            }
        }

        private void placeHexagons(int rowColorCode, int colColorCode, int col, int row, Point tempLocation)
        {
            Color hexColor;

            //find the hexaogns color 
            switch ((rowColorCode + colColorCode) % 3)
            {
                //Light
                case 0:
                    hexColor = Color.FromArgb(209, 139, 71);
                    break;
                //Medium
                case 2:
                    hexColor = Color.FromArgb(232, 171, 111);
                    break;
                //Dark
                case 1:
                    hexColor = Color.FromArgb(255, 206, 158);
                    break;
                //Error
                default:
                    hexColor = Color.Red;
                    break;
            }

            //add the 
            boardNodes.Add(((char)(col + 65)).ToString() + (row + 1).ToString(), new Hexagon(tempLocation, hexColor, col , row));
        }

    }
}
