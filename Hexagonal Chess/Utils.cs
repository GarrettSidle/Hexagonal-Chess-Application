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

        public static void makeMove(Move move, Board board, IDictionary<LocNotation, PictureBox> boardPieces, IDictionary<string, Hexagon> boardNodes, FrmBoard frmBoard)
        {
            frmBoard.removeMovementIcons();

            var whitePieces = new Dictionary<char, string>()
                {
                     { 'P', "♙"},
                     { 'K', "♔"},
                     { 'Q', "♕"},
                     { 'R', "♖"},
                     { 'B', "♗"},
                     { 'N', "♘"},
                };

            var blackPieces = new Dictionary<char, string>()
                {
                     { 'P', "♟︎"},
                     { 'K', "♚"},
                     { 'Q', "♛"},
                     { 'R', "♜"},
                     { 'B', "♝"},
                     { 'N', "♞"},
                };

            LocNotation startLocation = move.piece.locNotation;
            LocNotation endLocation = move.endLocation;

            //if a piece was taken
            if (move.isCapture)
            {
                //get the piece object that is being captured
                Piece capturedPiece = board.gameBoard[endLocation.col][endLocation.row];

                //remove the pieces image
                frmBoard.Controls.Remove(boardPieces[endLocation]);

                //update the evaluation
                board.setEval(
                    board.evaluation - capturedPiece.value
                );

                //add the taken piece to the piece counter
                Label pieceLabel = move.piece.isWhite?frmBoard.lblBottomUserEval : frmBoard.lblBottomUserEval;
                pieceLabel.Text += capturedPiece.isWhite ? whitePieces[capturedPiece.pieceType] : blackPieces[capturedPiece.pieceType];
            }

            //move the piece image to the new location
            Point hexCenter = boardNodes[endLocation.notation].location;
            PictureBox pieceImage = boardPieces[startLocation];

            //place the piece in the center of the hex
            pieceImage.Location = new Point(hexCenter.X-pieceImage.Height/2, hexCenter.Y - pieceImage.Width / 2);

            //update the internal board
            board.gameBoard[startLocation.col][startLocation.row] = null;
            board.gameBoard[endLocation.col][endLocation.row] =  move.piece;

            //TODO
            //See if the move is check
            //if (findChecks(board))
            //{
            //    board.isCheck = true;

            //    if (findMate(board))
            //    {
            //        //TODO 
            //        //end game
            //    }
            //}


            //add the move the datagrid
            string pieceCharcter = move.piece.isWhite ? whitePieces[move.piece.pieceType] : blackPieces[move.piece.pieceType];
            string moveNotation = pieceCharcter + move.moveNotation;

            DataGridView movesTable = frmBoard.dgMoves;

            DataGridViewRow row;

            //if it was whites move
            if (board.whiteToPlay)
            {
                //create a new row
                row = new DataGridViewRow();
                row.CreateCells(movesTable);

                //insert the move number
                row.Cells[0].Value = movesTable.Rows.Count;

                //input whites last move
                row.Cells[1].Value = moveNotation;
            }
            //if it was blacks move
            else
            {
                //find the last row
                row = movesTable.Rows[movesTable.Rows.Count - 1];
                //input blacks last move
                row.Cells[2].Value = moveNotation;
            }
            //get the current row index
            int currentRow = movesTable.Rows.Count - 1;

            //scroll to the bottom of the moves
            movesTable.FirstDisplayedScrollingRowIndex = currentRow ;
            //select the row
            movesTable.Rows[currentRow].Selected = true;


            //change it to the opposing teams move
            board.swapTurns();
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

        public class Board
        {
            public int evaluation;
            public List<Piece>[] gameBoard;
            public bool whiteToPlay;
            public bool isCheck;

            public Board()
            {
                this.whiteToPlay = true;
                //evaluation for a defualt board
                this.evaluation = 43;
                List<char>[] tempBoard = new List<char>[] {
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


                //List<char>[] tempBoard = new List<char>[] {
                //    new List<char> { 'P', ' ', 'P', ' ', ' ', ' ' },
                //    new List<char> { ' ', 'p', ' ', ' ', ' ', ' ', ' ' } ,
                //    new List<char> { 'R', ' ', ' ', 'k', 'N', ' ', ' ', 'r' },
                //    new List<char> { 'N', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'n' },
                //    new List<char> { 'Q', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'q' },
                //    new List<char> { ' ', ' ', ' ', 'p', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char>      { 'K', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'k' },
                //    new List<char>           { 'N', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'n' },
                //    new List<char>                { 'R', ' ', ' ', ' ', 'Q', ' ', ' ', 'r' },
                //    new List<char>                     { 'p', ' ', ' ', ' ', 'P', ' ', 'P' } ,
                //    new List<char>                          { ' ', ' ', ' ', ' ', 'p', ' ' }
                //};

                //List<char>[] tempBoard = new List<char>[] {
                //    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char> { ' ', ' ', 'R', ' ', ' ', ' ', ' ' } ,
                //    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char> { ' ', ' ', ' ', ' ', 'B', ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char>      { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char>           { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char>                { ' ', ' ', ' ', ' ', ' ', ' ', 'R', ' ' },
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
                            outputBoard[col].Add(new Piece(new LocNotation(col, row), tempBoard[col][row], char.IsUpper(tempBoard[col][row])));
                        }
                    }
                }

                this.gameBoard = outputBoard;
                this.isCheck = false;
            }

            public void setEval(int newEval)
            {
                this.evaluation = newEval;
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
                        this.value = 1000;
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
            public bool isCheck;
            public bool isCapture;

            public Move(Piece piece, LocNotation endLocation, bool isCapture)
            {
                this.piece = piece;
                this.endLocation = endLocation;

                //build the chess move notation
                this.moveNotation = piece.pieceType + (isCapture?"x":"") + endLocation.notation /*+ (isCheck ? "+" : "")*/;
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
    }
}
