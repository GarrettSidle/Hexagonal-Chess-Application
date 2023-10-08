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
        }

        //stores the location for each hexagon based on its location notation on the board
        private readonly IDictionary<string, Hexagon> boardNodes = new Dictionary<string, Hexagon>();

        //stores each piece based on its location notation within the board
        private readonly IDictionary<string, PictureBox> boardPieces = new Dictionary<string, PictureBox>();

        //stores the action buttons for later retrival 
        private readonly List<PictureBox> MovementButtons = new List<PictureBox>();
        private readonly List<PictureBox> CaptureButtons = new List<PictureBox>();

        public FrmBoard()
        {
            InitializeComponent();
            buildBoard();
            popultateActionButtons();
        }

        private void popultateActionButtons()
        {
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
        }

        private void createActionButton(bool isMovementButton, int index) 
        {
            PictureBox tempImage;

            //calculate the size for the photobox
            int size = (int)Math.Round(hexRadius * (isMovementButton ? 1.0 : .65));

            //initialize the photobox settings
            tempImage = new PictureBox();
            tempImage.Size = new Size(size, size);
            tempImage.Location = new Point(0, 0);
            tempImage.Name = isMovementButton?"MovementButton ":"CaptureButton" + index;
            tempImage.BackColor = isMovementButton ? Color.Transparent: Color.Black;
            tempImage.SizeMode = PictureBoxSizeMode.StretchImage;

            //if this is a movement button
            if (isMovementButton)
            {
                //add the movement button image
                tempImage.Image = Resources.AvailableMove;
            }

            //place the image on screen
            this.pnlGame.Controls.Add(tempImage);
            tempImage.BringToFront();
            tempImage.Visible = false;

            //add it to the appropriate List for later retrieval
            (isMovementButton?MovementButtons:CaptureButtons).Add(tempImage);
        }

        //swap the board to a new player mode
        public void updateGameMode()
        {
            if (userMode == 1)//Host mode
            { 
                //start listening for new moves
                MessageReceiver.DoWork += MessageReceiver_DoWork;
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket();
            }
            else if (userMode == 2) //client mode
            {
                try
                {
                    //start listening for new moves
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

            //reset the board
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
            //retrieve the last sent byte array
            byte[] buffer = new byte[4];
            sock.Receive(buffer);

            //decode them into their indivual meanings
            int atkPieceCol = buffer[0];
            int atkPieceRow = buffer[1];

            int capturedCol = buffer[2];
            int capturedRow = buffer[3];

            //create a new move based on the recieved data
            Move move = new Move(board.gameBoard[atkPieceCol][atkPieceRow], new LocNotation(capturedCol, capturedRow), board.gameBoard[capturedCol][capturedRow] != null, false);

            //execute the data
            makeMove(move, board, boardPieces, boardNodes, (FrmBoard)MDIParent.getScreen("Board"));
        }
        

        private void SendMove(Move move)
        {
            //create the byte array to send
            byte[] datas = { (byte)move.piece.locNotation.col, (byte)move.piece.locNotation.row, (byte)move.endLocation.col, (byte)move.endLocation.row };
            sock.Send(datas);

            //restart listening
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            //if the reciever has already been issues
            if (!MessageReceiver.IsBusy)
            {
                //create a new reciever thread
                MessageReceiver.RunWorkerAsync();
            }
            //swap turns
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
        }

        private void placeLabel(string text, int x, int y)
        {
            //create a label
            Label colLabel = new Label();
            colLabel.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            colLabel.ForeColor = Color.Black;
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
            foreach (PictureBox image in MovementButtons)
            {
                image.Visible = false;
                RemoveEvent(image, "EventClick");
            }
            foreach (PictureBox image in CaptureButtons)
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
                if (move.isCapture)
                {
                    //use a capture button 
                    tempImage = CaptureButtons[captureCount];
                    captureCount++;
                }
                else
                {
                    //otherwise, show a movement button
                    tempImage = MovementButtons[i];
                }
                //add the click event to the button
                tempImage.Click += (sender, EventArgs) => { Move_Click(sender, EventArgs, move); };

                //place movement buttons
                tempImage.Location = new Point(tempLocation.X - tempImage.Width / 2, tempLocation.Y - tempImage.Height / 2);
                tempImage.Visible = true;

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
