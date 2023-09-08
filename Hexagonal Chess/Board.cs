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

using static Hexagonal_Chess.Utils;
using static Hexagonal_Chess.FindMoves;

namespace Hexagonal_Chess
{
    public partial class FrmBoard : Form
    {

        int hexRadius = 43;



        private IDictionary<string, Hexagon> boardNodes = new Dictionary<string, Hexagon>();

        private IDictionary<string, PictureBox> boardPieces = new Dictionary<string, PictureBox>();


        public FrmBoard()
        {
            InitializeComponent();
        }

        private List<PictureBox> MovementButtons = new List<PictureBox>();

        private void Board_Load(object sender, EventArgs e)
        {

            buildBoard();

            this.lblTopEval.Text = "";


        }


        private void buildBoard()
        {
            //find the point that centers the board horizontally
            int x = (int)Math.Round((pnlBoard.Width / 2) - (hexRadius * 7.78));

            //find the point that centers the board verti
            int y = (int)Math.Round((pnlBoard.Height / 2) + (hexRadius * 4.26));

            //Starting point of the entire board, this will be center of A1
            Point startingPosition = new Point(x, y);

            //The distance from the center of a hexagon to center of any of its lines
            int hexShortradius = (int)Math.Round((hexRadius / 2) * Math.Sqrt(3));

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

                    //place the starting pieces
                    placeStartingPieces(col, row, tempLocation);

                    colColorCode++;
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

            boardNodes.Add(((char)(col + 65)).ToString() + (row + 1).ToString(), new Hexagon(tempLocation, hexColor));
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

                    pieceImage = piece.isWhite ? Properties.Resources.WhitePawn : Properties.Resources.BlackPawn;
                    break;

                case 'R':
                    pieceImage = piece.isWhite ? Properties.Resources.WhiteRook : Properties.Resources.BlackRook;
                    break;

                case 'N':
                    pieceImage = piece.isWhite ? Properties.Resources.WhiteKnight : Properties.Resources.BlackKnight;
                    break;

                case 'B':
                    pieceImage = piece.isWhite ? Properties.Resources.WhiteBishop : Properties.Resources.BlackBishop;
                    break;

                case 'K':
                    pieceImage = piece.isWhite ? Properties.Resources.WhiteKing : Properties.Resources.BlackKing;
                    break;

                case 'Q':
                    pieceImage = piece.isWhite ? Properties.Resources.WhiteQueen : Properties.Resources.BlackQueen;
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
            this.pnlBoard.Controls.Add(pictureBox);

            LocNotation tempNotation = piece.locNotation;

            if (piece.locNotation.col > 5)
            {
                //shift the row down by the number of columns it is right of center
                int newRow = piece.locNotation.row - 5 + piece.locNotation.col;
                //if we are off the board, continue to the next
                if (newRow > 0)
                {
                    tempNotation = new LocNotation(piece.locNotation.col, newRow);
                }
            }


            boardPieces.Add(tempNotation.notation, pictureBox);
        }



        private void Board_Paint(object sender, PaintEventArgs e)
        {


        }

        private void DrawHexagon(Hexagon hexagon, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            //Get the middle of the panel

            var shape = new PointF[6];


            //Create 6 points
            for (int a = 0; a < 6; a++)
            {
                shape[a] = new PointF(
                    hexagon.location.X + hexRadius * (float)Math.Cos(a * 60 * Math.PI / 180f),
                    hexagon.location.Y + hexRadius * (float)Math.Sin(a * 60 * Math.PI / 180f));
            }

            graphics.FillPolygon(new SolidBrush(hexagon.color), shape);
        }


        private void Move_Click(object sender, EventArgs e, Move move)
        {
            makeMove(move, board, boardPieces, boardNodes, (FrmBoard)MDIParent.getScreen("Board"));
        }


        public void removeMovementIcons()
        {
            foreach (PictureBox image in MovementButtons)
            {
                this.pnlBoard.Controls.Remove(image);
            }
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

            //find the size of the dot based on the hexagon
            int size = (int)Math.Round(hexRadius * 1.0);


            Point tempLocation;
            PictureBox tempImage;

            for (int i = 0; i < availableMoves.Count; i++)
            {

                Move move = availableMoves[i];


                //Get the location of the hexagon on the screen
                tempLocation = boardNodes[move.endLocation.notation].location;

                tempImage = new PictureBox();
                tempImage.Size = new Size(size, size);
                tempImage.Location = new Point(tempLocation.X - size / 2, tempLocation.Y - size / 2);
                tempImage.Name = "MovementButton " + i;
                tempImage.BackColor = Color.Transparent;
                tempImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                tempImage.Click += (sender, EventArgs) => { Move_Click(sender, EventArgs, move); };

                //assign the image based on the move type
                tempImage.Image = move.isCapture ? Properties.Resources.AvailableTake : Properties.Resources.AvailableMove;

                this.pnlBoard.Controls.Add(tempImage);

                //add it to the List for later removal
                MovementButtons.Add(tempImage);
                tempImage.BringToFront();

            }


        }

        private void makeMove(Move move, Board board, IDictionary<string, PictureBox> boardPieces, IDictionary<string, Hexagon> boardNodes, FrmBoard frmBoard)
        {
            frmBoard.removeMovementIcons();

            LocNotation startLocation = move.piece.locNotation;
            LocNotation endLocation = move.endLocation;


            //if a piece was taken
            if (move.isCapture)
            {
                //get the piece object that is being captured
                Piece capturedPiece = board.gameBoard[endLocation.col][endLocation.row];
                PictureBox capturedPieceImage = boardPieces[endLocation.notation];

                //remove the pieces image
                capturedPieceImage.Visible = false;
                frmBoard.Controls.Remove(capturedPieceImage);

                //remove the piece from the dictionary
                boardPieces.Remove(endLocation.notation);

                //if the move is white, add to the eval, if black subtract
                int newEvaluation = board.whiteToPlay ? board.evaluation + capturedPiece.value : board.evaluation - capturedPiece.value;

                //update the evaluation
                board.setEval(newEvaluation, capturedPiece);

                //if the piece that was taken was a king
                if (capturedPiece.pieceType == 'K')
                {
                    ResultScreen resultScreen = new ResultScreen();
                    resultScreen.setWinner(true);
                    resultScreen.Show();
                }
            }

            //move the piece image to the new location
            Point hexCenter = boardNodes[endLocation.notation].location;
            PictureBox pieceImage = boardPieces[startLocation.notation];

            //replace the key with the new location
            boardPieces.Remove(startLocation.notation);
            boardPieces.Add(endLocation.notation, pieceImage);

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
                if (col > 6)
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


        public class Hexagon
        {
            public Point location;
            public Color color;

            public Hexagon(Point location, Color color)
            {
                this.location = location;
                this.color = color;
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

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (KeyValuePair<string, Hexagon> node in boardNodes)
            {
                DrawHexagon(node.Value, e);
            }
        }
    }
}
