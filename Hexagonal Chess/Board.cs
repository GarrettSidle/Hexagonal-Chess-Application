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

        int hexRadius = 43;

        private void FrmBoard_Load(object sender, EventArgs e)
        {
            lblBottomEval.Text = "";
            lblTopEval.Text = "";

            hexRadius = (int)Math.Round(Screen.PrimaryScreen.Bounds.Height / 25.0);

            Utils.board.setBoard();
        }




        private IDictionary<string, Hexagon> boardNodes = new Dictionary<string, Hexagon>();

        private IDictionary<string, PictureBox> boardPieces = new Dictionary<string, PictureBox>();

        private List<PictureBox> MovementButtons = new List<PictureBox>();


        public FrmBoard()
        {
            InitializeComponent();
            buildBoard();
            CreateMovementButtons();


        }

        private void CreateMovementButtons()
        {
            PictureBox tempImage;
            //find the size of the dot based on the hexagon
            int size = (int)Math.Round(hexRadius * 1.0);
            for (int i = 0; i <  37; i++)
            {
                tempImage = new PictureBox();
                tempImage.Size = new Size(size, size);
                tempImage.Location = new Point(0,0);
                tempImage.Name = "MovementButton " + i;
                tempImage.BackColor = Color.Transparent;
                tempImage.SizeMode = PictureBoxSizeMode.StretchImage;

                //assign the image based on the move type
                tempImage.Image =  Resources.AvailableMove;

                this.pnlGame.Controls.Add(tempImage);

                //add it to the List for later removal
                MovementButtons.Add(tempImage);
                tempImage.BringToFront();

                tempImage.Visible = false;
            }
        }

        public void updateGameMode()
        {
            //if we are the host
            if (Utils.userMode == 1)
            {
                MessageReceiver.DoWork += MessageReceiver_DoWork;

                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket();
            }
            else if (Utils.userMode == 2)
            {
                try
                {
                    client = new TcpClient(Utils.IP, 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();

                    //Swap Screens
                    MDIParent.swapScreen("Board");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            resetBoard();


        }

        private void resetBoard()
        {
            


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
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            ReceiveMove();
        }

        private void ReceiveMove()
        {
            byte[] buffer = new byte[4];
            sock.Receive(buffer);

            int atkPieceCol = buffer[0];
            int atkPieceRow = buffer[1];

            int capturedCol = buffer[2];
            int capturedRow = buffer[3];

            Piece movingPiece = board.gameBoard[atkPieceCol][atkPieceRow];

            Piece capturedPiece = board.gameBoard[capturedCol][capturedRow];

            Move move = new Move(movingPiece, new LocNotation(capturedCol, capturedRow), capturedPiece != null, false);

            makeMove(move, board, boardPieces, boardNodes, (FrmBoard)MDIParent.getScreen("Board"));
        }

        private void SendMove(Move move)
        {
            byte[] datas = { (byte)move.piece.locNotation.col, (byte)move.piece.locNotation.row, (byte)move.endLocation.col, (byte)move.endLocation.row };
            sock.Send(datas);
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            if (!MessageReceiver.IsBusy)
            {
                MessageReceiver.RunWorkerAsync();
            }
            board.swapTurns();
        }




        private void buildBoard()
        {

            //The distance from the center of a hexagon to center of any of its lines
            int hexShortradius = (int)Math.Round((hexRadius / 2) * Math.Sqrt(3));

            //find the point that centers the board horizontally
            int x = (int)Math.Round((pnlGame.Width / 2) + (hexRadius * 0.0)); //7.78
            //find the point that centers the board vertical
            int y = (int)Math.Round((pnlGame.Height / 2) + (hexRadius * 8.0)); //4.26

            //Starting point of the entire board, this will be center of A1
            Point startingPosition = new Point(x, y);

            int rowMax = 5;

            int rowColorCode = 0;
            int colColorCode = 0;


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

                    colColorCode++;

                    //if we are in the first hexagon of the row
                    if (col == 0 || (row - col == 5 && col > 0 && col < 6))
                    {
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
                colColorCode = 0;

                placeLabel(
                    ((char)(col + 65)).ToString(),
                    (int)(Math.Round(startingPosition.X + (col * hexShortradius * (.9) * 2))) - 10,
                    startingPosition.Y + ((col < 6 ? col : (10 - col)) * hexShortradius + (hexRadius))
                );
            }
        }

        private void placeLabel(string text, int x, int y)
        {
            //create a label
            Label colLabel = new Label();
            colLabel.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            colLabel.ForeColor = Color.Black;
            colLabel.BackColor = Color.Transparent;
            //input the custom values
            colLabel.Text = text;
            colLabel.Location = new Point(x,y);
            colLabel.Width = 50;
            //add it to the board
            pnlGame.Controls.Add(colLabel);
        }

        private void placeStartingPieces(int col, int row, Point tempLocation)
        {
            Piece piece = board.gameBoard[col][row];

            if (piece == null)
            {
                return;
            }

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

            int size = (int)Math.Round(hexRadius * 1.55);
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(size, size);
            pictureBox.Location = new Point(tempLocation.X - size / 2, tempLocation.Y - size / 2);
            pictureBox.Image = pieceImage;
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox.Name = piece.pieceType + piece.locNotation.notation;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Click += (sender, EventArgs) => { Piece_Click(sender, EventArgs, piece); };
            this.pnlGame.Controls.Add(pictureBox);

            LocNotation tempNotation = piece.locNotation;

            ////Offset.
            //if (piece.locNotation.col > 5)
            //{
            //    //shift the row up by the number of columns it is right of center
            //    int newRow = piece.locNotation.row - 5 + piece.locNotation.col;
            //    //if we are off the board, continue to the next
            //    if (newRow > 0)
            //    {
            //        tempNotation = new LocNotation(piece.locNotation.col, newRow);
            //    }
            //}


            boardPieces.Add(tempNotation.notation, pictureBox);
        }

        private void Move_Click(object sender, EventArgs e, Move move)
        {
            //local
            if (Utils.userMode != 0)
            {
                SendMove(move);
            }

            makeMove(move, board, boardPieces, boardNodes, (FrmBoard)MDIParent.getScreen("Board"));
        }


        public void removeMovementIcons()
        {
            foreach (PictureBox image in MovementButtons)
            {
                image.Visible = false;
                RemoveEvent(image, "EventClick");
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

            removeMovementIcons();

            List<Move> availableMoves;
            //get all of the available moves for the selected piece
            availableMoves = FindMoves.FindPieceMoves(piece);



            Point tempLocation;

            for (int i = 0; i < availableMoves.Count; i++)
            {

                Move move = availableMoves[i];

                //LocNotation tempNotation = offsetRightBoard(move.endLocation);
                LocNotation tempNotation = move.endLocation;


                //Get the location of the hexagon on the screen
                tempLocation = boardNodes[tempNotation.notation].location;

                PictureBox tempImage = MovementButtons[i];

                //place movement buttons
                tempImage.Image = move.isCapture ? Properties.Resources.AvailableTake : Properties.Resources.AvailableMove;
                tempImage.Click += (sender, EventArgs) => { Move_Click(sender, EventArgs, move); };
                tempImage.Location = new Point(tempLocation.X - tempImage.Width / 2, tempLocation.Y - tempImage.Height / 2);
                tempImage.Visible = true;

            }


        }
        private void makeMove(Move move, Board board, IDictionary<string, PictureBox> boardPieces, IDictionary<string, Hexagon> boardNodes, FrmBoard frmBoard)
        {
            frmBoard.removeMovementIcons();

            LocNotation startLocation = move.piece.locNotation;
            LocNotation endLocation = move.endLocation;

            bool endGame = false;

            LocNotation tempEndLocation = endLocation;
            LocNotation eendLocation = endLocation;

            ////Offset.
            //if (endLocation.col > 5)
            //{
            //    //shift the row up by the number of columns it is right of center
            //    int newRow = endLocation.row - 5 + endLocation.col;
            //    //if we are off the board, continue to the next
            //    if (newRow > 0)
            //    {
            //        eendLocation = new LocNotation(endLocation.col, newRow);
            //    }
            //}
            ////Offset.
            //if (tempEndLocation.col > 5)
            //{
            //    //shift the row up by the number of columns it is right of center
            //    int newRow = tempEndLocation.row + 5 - tempEndLocation.col;
            //    //if we are off the board, continue to the next
            //    if (newRow > 0)
            //    {
            //        tempEndLocation = new LocNotation(tempEndLocation.col, newRow);
            //    }
            //}



            //if a piece was taken
            if (move.isCapture)
            {
                Piece capturedPiece;
                PictureBox capturedPieceImage;

                if (move.enPassent)
                {
                    
                    LocNotation enPassantLocation = new LocNotation(endLocation.col + (move.piece.isWhite ? -1 : 1), endLocation.row);

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

                //update the image
                pieceImage.Image = move.piece.isWhite ? Properties.Resources.WhiteQueen : Properties.Resources.BlackQueen;
                pieceImage.Click += (sender, EventArgs) => { Piece_Click(sender, EventArgs, move.piece); };
            }

            //update the internal board
            board.gameBoard[startLocation.col][startLocation.row] = null;
            board.gameBoard[endLocation.col][endLocation.row] = move.piece;

            updateMoveTable(move, board, frmBoard);


            //change it to the opposing teams move
            board.swapTurns();


            if (endGame)
            {
                int numOfMoves = dgMoves.Rows.Count + (move.piece.isWhite ? 1 : 0);

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
                //if we are on the right side of the board
                if (col > 5)
                {
                    //find final row for left side
                    return row - col == 5;
                }
                //if we are on the left side of the board
                else
                {
                    //find final row for right side
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

            movesTable.ForeColor = Color.Black;
            movesTable.Font = frmBoard.lblMovesTableRef.Font;


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
            foreach (KeyValuePair<string, Hexagon> node in boardNodes)
            {
                Hexagon.DrawHexagon(node.Value, e, hexRadius);
            }
        }

        private void placeHexagons(int rowColorCode, int colColorCode, int col, int row, Point tempLocation)
        {
            Color hexColor;

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

            boardNodes.Add(((char)(col + 65)).ToString() + (row + 1).ToString(), new Hexagon(tempLocation, hexColor, col , row));
        }

    }
}
