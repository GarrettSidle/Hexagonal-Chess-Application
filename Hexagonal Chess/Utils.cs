using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Hexagonal_Chess
{
    internal class Utils
    {

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
            public readonly int evaluation;
            public List<Piece>[] gameBoard;
            public bool whiteToPlay;

            public Board()
            {
                this.whiteToPlay = true;
                this.evaluation = 0;
                //List<char>[] tempBoard = new List<char>[] {
                //    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ' },
                //    new List<char> { 'P', ' ', ' ', ' ', ' ', ' ', 'p' } ,
                //    new List<char> { 'R', 'P', ' ', ' ', ' ', ' ', 'p', 'r' },
                //    new List<char> { 'N', ' ', 'P', ' ', ' ', ' ', 'p', ' ', 'n' },
                //    new List<char> { 'Q', ' ', ' ', 'P', ' ', ' ', 'p', ' ', ' ', 'q' },
                //    new List<char> { 'B', 'B', 'B', ' ', 'P', ' ', 'p', ' ', 'b', 'b', 'b' },
                //    new List<char>      { 'K', ' ', ' ', 'P', ' ', ' ', 'p', ' ', ' ', 'k' },
                //    new List<char>           { 'N', ' ', 'P', ' ', ' ', ' ', 'p', ' ', 'n' },
                //    new List<char>                { 'R', 'P', ' ', ' ', ' ', ' ', 'p', 'r' },
                //    new List<char>                     { 'P', ' ', ' ', ' ', ' ', ' ', 'p' } ,
                //    new List<char>                          { ' ', ' ', ' ', ' ', ' ', ' ' }
                //};


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

                List<char>[] tempBoard = new List<char>[] {
                    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ' },
                    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ' } ,
                    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    new List<char> { ' ', ' ', ' ', ' ', 'R', ' ', ' ', ' ', ' ', ' ', ' ' },
                    new List<char>      { ' ', 'R', ' ', ' ', 'R', ' ', ' ', ' ', ' ', ' ' },
                    new List<char>           { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    new List<char>                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    new List<char>                     { ' ', ' ', ' ', 'R', ' ', ' ', ' ' } ,
                    new List<char>                          { ' ', ' ', ' ', ' ', ' ', ' ' }
                };


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
            }

            public void makeMove(Move move)
            {
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


                //update the board



                if (move.isCapture)
                {
                    //update the evaluation

                    //add the taken piece to the piece counter
                }


                //add the move the datagrid
                string pieceCharcter = move.piece.isWhite? whitePieces[move.piece.pieceType] : blackPieces[move.piece.pieceType];
                string temp = pieceCharcter + move.moveNotation;

                //change it to the opposing teams move
                this.whiteToPlay = !this.whiteToPlay;
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
