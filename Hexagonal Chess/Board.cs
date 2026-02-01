using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            //reset the board
            lblBottomEval.Text = "";
            lblTopEval.Text = "";
            board.setBoard();
            updateTurnIndicator();
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
            if (userMode != 0)
                CleanupMultiplayer();
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
                // Clone the image so each PictureBox owns its copy. Otherwise, when the Board
                // is disposed (e.g. going home then starting a new game), PictureBox.Dispose
                // disposes the shared Resources.AvailableMove bitmap, and the next Board gets
                // an invalid disposed image → "Parameter is not valid".
                tempImage.Image = (Image)Resources.AvailableMove.Clone();
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

            resetBoard();
        }

        private void resetBoard()
        {
            pnlGame.SuspendLayout();

            // Remove old piece PictureBoxes and clear dictionary (Board form is reused when starting a new game)
            foreach (var kvp in boardPieces.ToList())
            {
                var pb = kvp.Value;
                pnlGame.Controls.Remove(pb);
                pb.Image?.Dispose();
                pb.Dispose();
            }
            boardPieces.Clear();
            dgMoves.Rows.Clear();

            //The distance from the center of a hexagon to center of any of its lines
            int hexShortradius = (int)Math.Round((hexRadius / 2) * Math.Sqrt(3));

            //find the point that centers the board horizontally
            int x = (int)Math.Round((pnlGame.Width / 2) + (hexRadius * 0.0)); //7.78
            //find the point that centers the board vertical
            int y = (int)Math.Round((pnlGame.Height / 2) + (hexRadius * 8.0)); //4.26

            //Starting point of the entire board, this will be center of A1
            Point startingPosition = new Point(x, y);

            int rowMax = 5;

            for (int col = 0; col < 11; col++)
            {
                for (int row = 0; row <= rowMax; row++)
                {
                    //Find the location of the next node
                    Point tempLocation = new Point(
                            (int)(Math.Round(startingPosition.X + (col * hexShortradius * (.9) * 2))),
                        startingPosition.Y - (row * hexShortradius * 2) + ((col < 6 ? col : (10 - col)) * hexShortradius));


                    //place the starting pieces
                    placeStartingPieces(col, row, tempLocation);

                }
                //if we are in the first 6 rows
                if (col < 5)
                {
                    //add another row
                    rowMax++;
                }
                //otherwise
                else
                {
                    //remove another row
                    rowMax--;

                }
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

            Piece piece = board.gameBoard[atkPieceCol][atkPieceRow];
            if (piece == null)
                return;
            Move move = new Move(piece, new LocNotation(capturedCol, capturedRow), isCapture, enPassant);

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

        private void SendMove(Move move)
        {
            byte flags = (byte)(move.enPassent ? 0x01 : 0x00);
            byte[] datas = { (byte)move.piece.locNotation.col, (byte)move.piece.locNotation.row, (byte)move.endLocation.col, (byte)move.endLocation.row, flags };
            sock.Send(datas);

            if (!MessageReceiver.IsBusy)
                MessageReceiver.RunWorkerAsync();
            board.swapTurns();
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
            // Clone so each PictureBox owns its copy. Shared Resources get disposed when the previous
            // Board's piece PictureBoxes are disposed (e.g. going home → new game).
            pictureBox.Image = pieceImage != null ? (Image)pieceImage.Clone() : null;
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
            //if it is not the pieces turn to move
            if (!(piece.isWhite == board.whiteToPlay))
            {
                //ignore the click   
                return;
            }
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

                //update the image (clone to avoid disposing shared Resources when Board is disposed)
                var queenRes = move.piece.isWhite ? Properties.Resources.WhiteQueen : Properties.Resources.BlackQueen;
                pieceImage.Image = queenRes != null ? (Image)queenRes.Clone() : null;
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

            //if the king has been captured
            if (endGame)
            {
                //find the number of moves in the game
                int numOfMoves = dgMoves.Rows.Count + (move.piece.isWhite ? 1 : 0);
                
                //initialize and show the results screen
                ResultScreen resultScreen = new ResultScreen();
                resultScreen.setWinner(true, numOfMoves);
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
            //build the notation and remove the piece type char
            string moveNotation = pieceCharcter + move.moveNotation.TrimStart(move.piece.pieceType);


            DataGridView movesTable = frmBoard.dgMoves;

            DataGridViewRow row;

            int currentRow = movesTable.Rows.Count;

            //if it was whites move
            if (board.whiteToPlay)
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
            //if it was blacks move
            else
            {
                //find the first row
                row = movesTable.Rows[currentRow - 1];
                //input blacks last move
                row.Cells[2].Value = moveNotation;

                //select the row
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
