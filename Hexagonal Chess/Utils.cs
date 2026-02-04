using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Windows;
using Hexagonal_Chess.Properties;

namespace Hexagonal_Chess
{
    internal class Utils
    {
        //Game Varient
        public static int gameVarient = 0;        // 0 = Glinski, 1 = McCooey, 2 = Hexofen

        //User modes
        public static int userMode = 0;        // 0 = Play vs Bot,  1 = Host,  2 = Client,  3 = Pass and Play

        /// <summary>Play vs Bot: true = local player is white, false = local player is black (randomized at game start).</summary>
        public static bool localPlayerIsWhite = true;

        //network flags
        public static bool gameFound = false;
        public static string IP;

        /// <summary>TCP port for multiplayer (host listen and client connect).</summary>
        public const int GamePort = 5732;

        // Networking Components
        public static BackgroundWorker MessageReceiver = new BackgroundWorker();
        public static TcpListener server = null;
        public static TcpClient client;
        public static Socket sock;

        // Unicode chess symbols for pieces
        public static Dictionary<char, string> pieceChars = new Dictionary<char, string>()
        { 
            { 'P', "♙" }, // Pawn
            { 'K', "♔" }, // King
            { 'Q', "♕" }, // Queen
            { 'R', "♖" }, // Rook
            { 'B', "♗" }, // Bishop
            { 'N', "♘" }  // Knight
        };

        // Current Game Board object
        public static Board board = new Board();

        public class Board
        {
            public int evaluation;
            public List<Piece>[] gameBoard;
            public bool whiteToPlay;
            public Move prevMove;

            public Board()
            {
                //defualt state of a new board
                this.whiteToPlay = true;
                this.evaluation = 0;

                //add pieces based on the varient
                this.setBoard();
            }

            // Set up the initial game board based on the selected variant
            public void setBoard()
            {
                whiteToPlay = true;
                evaluation = 0;
                prevMove = null;
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
                //grab the correct board based on the game varient
                switch (gameVarient)
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


                List<Piece>[] outputBoard = new List<Piece>[tempBoard.Length];

                //for every col
                for (int col = 0; col < tempBoard.Length; col++)
                {
                    //add a new row
                    outputBoard[col] = new List<Piece>();
                    //for every row
                    for (int row = 0; row < tempBoard[col].Count; row++)
                    {
                        //create either an empty hexagon
                        if (tempBoard[col][row] == ' ')
                        {
                            outputBoard[col].Add(null);
                        }
                        //or create and append a piece
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
                // add the correct value
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
            public LocNotation startLocation;
            public readonly string moveNotation;
            public bool isCapture;
            public bool enPassent;
            /// <summary>Piece type captured (e.g. 'Q' for queen). Set when the move is applied so the moves table can show e.g. ♕x♕F11.</summary>
            public char? capturedPieceType;

            public Move(Piece piece, LocNotation endLocation, bool isCapture, bool enPassant, char? capturedPieceType = null)
            {
                this.piece = piece;
                this.endLocation = endLocation;
                this.enPassent = enPassant;
                this.startLocation = piece.locNotation;
                this.capturedPieceType = capturedPieceType;

                //build the chess move notation (capture: QxQF11 so display can show ♕x♕F11)
                if (isCapture && capturedPieceType.HasValue)
                    this.moveNotation = piece.pieceType + "x" + capturedPieceType.Value + endLocation.notation;
                else
                    this.moveNotation = piece.pieceType + (isCapture ? "x" : "") + endLocation.notation;
                this.isCapture = isCapture;
            }
        }

        // Represents location on the board in chess notation (e.g., A1, B2)
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
        // Represents a hexagonal shape for GUI rendering
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
                this.row = row;
            }

            // Reused buffer to avoid allocating 91 PointF[] per paint (paint is UI-thread only)
            private static readonly PointF[] HexShapeBuffer = new PointF[6];

            public static void DrawHexagon(Hexagon hexagon, PaintEventArgs e, int hexRadius)
            {
                var graphics = e.Graphics;

                //Create the 6 points (reuse buffer to reduce GC pressure)
                for (int a = 0; a < 6; a++)
                {
                    HexShapeBuffer[a] = new PointF(
                        hexagon.location.X + hexRadius * (float)Math.Cos(a * 60 * Math.PI / 180f),
                        hexagon.location.Y + hexRadius * (float)Math.Sin(a * 60 * Math.PI / 180f));
                }

                //color in the shape (dispose brush to avoid GDI leak on every repaint)
                using (var brush = new SolidBrush(hexagon.color))
                {
                    graphics.FillPolygon(brush, HexShapeBuffer);
                }
            }

        }
    }
}
