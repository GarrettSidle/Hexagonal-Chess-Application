using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Hexagonal_Chess
{
    internal class Utils
    {
        // 0 = Glinski,
        // 1 = McCooey,
        // 2 = Hexofen
        public static int gameType = 2;

        // 0 = Single Player
        // 1 = Host
        // 2 = Client
        public static int userMode = 0;

        public static string IP;

        public static Dictionary<char, string> pieceChars = new Dictionary<char, string>()
                {
                     { 'P', "♙"},
                     { 'K', "♔"},
                     { 'Q', "♕"},
                     { 'R', "♖"},
                     { 'B', "♗"},
                     { 'N', "♘"},
                };

        public static Board board = new Board();

        public class Board
        {
            public int evaluation;
            public List<Piece>[] gameBoard;
            public bool whiteToPlay;
            public Move prevMove;

            public Board()
            {
                this.whiteToPlay = true;

                //evaluation for the starting board board
                //negative evalution represents black, and postive white
                this.evaluation = 0;

                this.setBoard();
            }

            public void setBoard()
            {
                List<char>[] glinskiBoard = new List<char>[] {
                    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ' },
                    new List<char> { 'P', ' ', ' ', ' ', ' ', ' ', 'p' } ,
                    new List<char> { 'R', 'P', ' ', ' ', ' ', ' ', 'p', 'r' },
                    new List<char> { 'N', ' ', 'P', ' ', ' ', ' ', 'p', ' ', 'n' },
                    new List<char> { 'Q', ' ', ' ', 'P', ' ', ' ', 'p', ' ', ' ', 'q' },
                    new List<char> { 'B', 'B', 'B', ' ', 'P', ' ', 'p', ' ', 'b', 'b', 'b' },
                    new List<char>      { 'K', ' ', ' ', 'P', ' ', ' ', 'p', ' ', ' ', 'k' },
                    new List<char>           { 'N', ' ', 'P', ' ', ' ', ' ', 'p', ' ', 'n' },
                    new List<char>                { 'R', 'P', ' ', ' ', ' ', ' ', 'p', 'r' },
                    new List<char>                     { 'P', ' ', ' ', ' ', ' ', ' ', 'p' } ,
                    new List<char>                          { ' ', ' ', ' ', ' ', ' ', ' ' }
                };

                List<char>[] mcCooeyBoard = new List<char>[] {
                    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ' },
                    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ' } ,
                    new List<char> { 'P', ' ', ' ', ' ', ' ', ' ', ' ', 'p' },
                    new List<char> { 'R', 'P', ' ', ' ', ' ', ' ', ' ', 'p', 'r' },
                    new List<char> { 'Q', 'N', 'P', ' ', ' ', ' ', ' ', 'p', 'n', 'q' },
                    new List<char> { 'B', 'B', 'B', 'P', ' ', ' ', ' ', 'p', 'b', 'b', 'b' },
                    new List<char>      { 'K', 'N', 'P', ' ', ' ', ' ', ' ', 'p', 'n', 'k' },
                    new List<char>           { 'R', 'P', ' ', ' ', ' ', ' ', ' ', 'p', 'r' },
                    new List<char>                { 'P', ' ', ' ', ' ', ' ', ' ', ' ', 'p' },
                    new List<char>                     { ' ', ' ', ' ', ' ', ' ', ' ', ' ' } ,
                    new List<char>                          { ' ', ' ', ' ', ' ', ' ', ' ' }
                };

                List<char>[] hexofenBoard = new List<char>[] {
                    new List<char> { 'P', ' ', ' ', ' ', ' ', 'p' },
                    new List<char> { 'P', ' ', ' ', ' ', ' ', ' ', 'p' } ,
                    new List<char> { 'N', 'P', ' ', ' ', ' ', ' ', 'p', 'b' },
                    new List<char> { 'R', 'P', ' ', ' ', ' ', ' ', ' ', 'p', 'r' },
                    new List<char> { 'B', 'N', 'P', ' ', ' ', ' ', ' ', 'p', 'n', 'q' },
                    new List<char> { 'K', 'B', 'P', ' ', ' ', ' ', ' ', ' ', 'p', 'b', 'k' },
                    new List<char>      { 'Q', 'N', 'P', ' ', ' ', ' ', ' ', 'p', 'n', 'b' },
                    new List<char>           { 'R', 'P', ' ', ' ', ' ', ' ', ' ', 'p', 'r' },
                    new List<char>                { 'B', 'P', ' ', ' ', ' ', ' ', 'p', 'n' },
                    new List<char>                     { 'P', ' ', ' ', ' ', ' ', ' ', 'p' } ,
                    new List<char>                          { 'P', ' ', ' ', ' ', ' ', 'p' }
                };

                List<char>[] tempBoard;
                switch (gameType)
                {
                    case 0:
                        tempBoard = glinskiBoard;
                        break;
                    case 1:
                        tempBoard = mcCooeyBoard;
                        break;
                    case 2:
                        tempBoard = hexofenBoard;
                        break;
                    default:
                        throw new Exception("Invalid Game Type");
                }



                //tempBoard = new List<char>[] {
                //    new List<char> { ' ', ' ', 'P', ' ', ' ', ' ' },
                //    new List<char> { ' ', ' ', ' ', 'p', ' ', ' ', ' ' } ,
                //    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char> { ' ', ' ', ' ', ' ', ' ', 'R', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char>      { ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'R', ' ', ' ' },
                //    new List<char>           { ' ', 'N', ' ', ' ', 'N', ' ', ' ', ' ', ' ' },
                //    new List<char>                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char>                     { ' ', ' ', ' ', ' ', ' ', ' ', ' ' } ,
                //    new List<char>                          { ' ', ' ', ' ', ' ', ' ', ' ' }
                //};




                List<Piece>[] outputBoard = new List<Piece>[tempBoard.Length];

                for (int col = 0; col < tempBoard.Length; col++)
                {
                    outputBoard[col] = new List<Piece>();
                    for (int row = 0; row < tempBoard[col].Count; row++)
                    {
                        if (tempBoard[col][row] == ' ')
                        {
                            outputBoard[col].Add(null);
                        }
                        else
                        {
                            Piece tempPiece = new Piece(new LocNotation(col, row), tempBoard[col][row], char.IsUpper(tempBoard[col][row]));
                            outputBoard[col].Add(tempPiece);
                        }
                    }
                }

                this.gameBoard = outputBoard;
            }

            public void setEval(int newEval, Piece capturedPiece)
            {

                FrmBoard.stripEval();
                updatePieceEvalIndicator(newEval, capturedPiece);

                //update to the new evaluation
                this.evaluation = newEval;
            }


            public static void updatePieceEvalIndicator(int newEval, Piece capturedPiece)
            {
                FrmBoard frmBoard = (FrmBoard)MDIParent.getScreen("Board");

                Label whiteEvalLabel = frmBoard.lblBottomUserEval;
                Label blackEvalLabel = frmBoard.lblTopUserEval;

                Label whiteBarEval = frmBoard.lblBottomEval;
                Label blackBarEval = frmBoard.lblTopEval;

                //add the taken piece to the piece counter
                Label pieceLabel = capturedPiece.isWhite ? frmBoard.lblTopUserEval : frmBoard.lblBottomUserEval;
                pieceLabel.Text += pieceChars[capturedPiece.pieceType];

                //if white is winning
                if (newEval > 0)
                {
                    //display their winning value
                    whiteEvalLabel.Text = $"{whiteEvalLabel.Text}+{Math.Abs(newEval)}";
                    whiteBarEval.Text = $"+{Math.Abs(newEval)}.0";
                }
                //if black is winning
                else if (newEval < 0)
                {
                    //display their winning value
                    blackEvalLabel.Text = $"{blackEvalLabel.Text}+{Math.Abs(newEval)}";
                    blackBarEval.Text = $"+{Math.Abs(newEval)}.0";
                }

                int blackBarPercent;
                //if white is overwelmingly winning
                if (newEval > 6)
                {
                    //Cap whites % at 90
                    blackBarPercent = 10;
                }
                //if black is overwelmingly winning
                else if (newEval < -6)
                {
                    //Cap blacks % at 90
                    blackBarPercent = 90;
                }
                else
                {
                    //calculate the % based on the eval
                    blackBarPercent = ((20 / 3) * newEval) + 50;
                }

                //Update the bar display
                frmBoard.layoutEval.RowStyles[1].Height = blackBarPercent;
            }

            public void swapTurns()
            {
                this.whiteToPlay = !whiteToPlay;
            }

         
        }

        public class Piece
        {
            public LocNotation locNotation;
            public char pieceType;
            public int value;
            public bool isWhite;
            public Piece(LocNotation locNotation, char pieceType, bool isWhite)
            {
                this.locNotation = locNotation;
                this.pieceType = char.ToUpper(pieceType);
                this.isWhite = isWhite;

                switch (char.ToUpper(pieceType))
                {
                    case 'P':
                        this.value = 1;
                        break;

                    case 'R':
                        this.value = 5;
                        break;

                    case 'N':
                        this.value = 3;
                        break;

                    case 'B':
                        this.value = 3;
                        break;

                    case 'K':
                        this.value = 0;
                        break;

                    case 'Q':
                        this.value = 9;
                        break;

                    default:
                        throw new Exception("Invalid Piece Type");
                }
            }
        }

        public class Move
        {
            public Piece piece;
            public LocNotation endLocation;
            public readonly string moveNotation;
            public bool isCapture;
            public bool enPassent;

            public Move(Piece piece, LocNotation endLocation, bool isCapture, bool enPassant)
            {
                this.piece = piece;
                this.endLocation = endLocation;
                this.enPassent = enPassant;

                //build the chess move notation
                this.moveNotation = piece.pieceType + (isCapture?"x":"") + endLocation.notation;
                this.isCapture = isCapture;
            }
        }

        public class LocNotation
        {
            public int col;
            public int row;
            public string notation;
            public LocNotation(int col, int row)
            {
                this.col = col;
                this.row = row;
                this.notation = ((char)(col + 65)).ToString() + (row + 1).ToString();
            }

            public void setColumn(int col)
            {
                this.col = col;
                this.notation = ((char)(col + 65)).ToString() + (this.row + 1).ToString();
            }

            public void setRow(int row)
            {
                this.row = row;
                this.notation = ((char)(this.col + 65)).ToString() + (row + 1).ToString();
            }
        }
        public class Hexagon
        {
            public Point location;
            public Color color;
            public int col;
            public int row;

            public Hexagon(Point location, Color color, int col, int row)
            {
                this.location = location;
                this.color = color;
                this.col = col;
                this.row=row;
            }

            public static void DrawHexagon(Hexagon hexagon, PaintEventArgs e, int hexRadius)
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

        }
    }
}
