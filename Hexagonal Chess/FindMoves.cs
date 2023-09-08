using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hexagonal_Chess.Utils;
using static Hexagonal_Chess.MDIParent;

namespace Hexagonal_Chess
{
    internal class FindMoves
    {

        public static List<Move> FindPieceMoves(Piece piece)
        {
            //Piece piece = new Piece(origPiece.locNotation, origPiece.pieceType, origPiece.isWhite);


            List<Move> Moves = new List<Move>();

            int[][] horizontalIncrementors = new int[][] {
                new int[2] { 0, 1 }, //Up
                new int[2] { 0, -1 }, //down
                new int[2] { -1, 0 }, //Up and left
                new int[2] { 1, 0 }, //down and right
                new int[2] { 1, 1 }, //up and right
                new int[2] { -1, -1 } //down and left
            };
            int[][] diagnalIncrementors = new int[][] {
                new int[2] { -2, -1 }, //left
                new int[2] { 2, 1 }, //right
                new int[2] { 1, 2 }, //up and right
                new int[2] { -1, 1 }, //up and left
                new int[2] { 1, -1 }, //down and right
                new int[2] { -1, -2 } //down and left
            };

            int[][] knightDisplacers = new int[][] {
                new int[2] { 1, 3 }, //left most up and right
                new int[2] { 2, 3 }, //right most up and right

                new int[2] { 3, 1 }, //down most right
                new int[2] { 3, 2 }, //up most right

                new int[2] { 2, -1 }, //right most down and right
                new int[2] { 1, -2 }, //left most down and right

                new int[2] {-1 , -3 }, //right most down and left
                new int[2] {-2 , -3 }, //left most down and left

                new int[2] {-3 ,  -1}, //up most left
                new int[2] {-3 ,  -2}, //down most left

                new int[2] { -2, 1 }, //left most up and left
                new int[2] {-1 , 2  }, //right most up and right
            };


            int[][] kingDisplacers = new int[][] {
                //Horizontals
                new int[2] { 0, 1 }, //Up
                new int[2] { 0, -1 }, //down
                new int[2] { -1, 0 }, //Up and left
                new int[2] { 1, 0 }, //down and right
                new int[2] { 1, 1 }, //up and right
                new int[2] { -1, -1 }, //down and left

                //Diagnals
                new int[2] { -2, -1 }, //left
                new int[2] { 2, 1 }, //right
                new int[2] { 1, 2 }, //up and right
                new int[2] { -1, 1 }, //up and left
                new int[2] { 1, -1 }, //down and right
                new int[2] { -1, -2 } //down and left
            };

            if (piece.locNotation.col > 5)
            {
                //shift the row down by the number of columns it is right of center
                int newRow = piece.locNotation.row - 5 + piece.locNotation.col;
                //if we are off the board, continue to the next
                if (newRow > 0)
                {
                    piece.locNotation.setRow(newRow);
                }
            }

            switch (piece.pieceType)
            {
                case 'P':
                    Moves.AddRange(FindPawnMoves(piece));
                    break;

                case 'R':
                    Moves.AddRange(FindStraightMoves(piece, horizontalIncrementors));
                    break;

                case 'N':
                    Moves.AddRange(FindDisplacement(piece, knightDisplacers));
                    break;

                case 'B':
                    Moves.AddRange(FindStraightMoves(piece, diagnalIncrementors));
                    break;

                case 'K':
                    Moves.AddRange(FindDisplacement(piece, kingDisplacers));
                    break;

                case 'Q':
                    Moves.AddRange(FindStraightMoves(piece, horizontalIncrementors));
                    Moves.AddRange(FindStraightMoves(piece, diagnalIncrementors));
                    break;

                default:
                    throw new Exception("Invalid Piece Type");
            }

            return Moves;
        }


        private static LocNotation offsetRightBoard(LocNotation origLocNotation)
        {

            LocNotation locNotation = new LocNotation(origLocNotation.col, origLocNotation.row);

            //if the move is right of the centerline
            if (locNotation.col > 5)
            {
                //shift the row down by the number of columns it is right of center
                int newRow = locNotation.row + 5 - locNotation.col;
                //if we are off the board, continue to the next
                if (newRow >= 0)
                {
                    locNotation.setRow(newRow);
                }
            }
            return locNotation;

        }

        private static int offsetRightBoard(int col, int row)
        {


            //if the move is right of the centerline
            if (col > 5)
            {

                //shift the row down by the number of columns it is right of center
                //int newRow = row - 1;
                int newRow = row + 5 - col;
                //if we are off the board, continue to the next
                if (newRow >= 0)
                {
                    return newRow;
                }
            }
            return row;

        }




        private static List<Move> FindDisplacement(Piece piece, int[][] displacements)
        {
            List<Move> outputMoves = new List<Move>();

            //Get the location of the piece we are moving
            int col = piece.locNotation.col;
            int row = piece.locNotation.row;

            LocNotation tempLocation;

            //This represents the square we are trying to move to 
            Piece selectedPiece;

            //For each potential move
            for (int i = 0; i < displacements.Length; i++)
            {
                //calculate the new position using the displacements
                tempLocation = new LocNotation(col + displacements[i][0], row + displacements[i][1]);

                //offset the position 
                tempLocation = offsetRightBoard(tempLocation);

                try
                {
                    //get the piece at the next square
                    selectedPiece = board.gameBoard[tempLocation.col][tempLocation.row];
                }
                catch (Exception)
                {
                    //we have moved outside the bounds of the board
                    continue;
                }

                //if the square is empty
                if (selectedPiece == null)
                {
                    //add it as a potential move 
                    outputMoves.Add(new Move(piece, tempLocation, false));

                    //look at the next displacement
                    continue;
                }
                //if the pieces are not the same color
                else if (selectedPiece.isWhite != piece.isWhite)
                {
                    //add it as a potential move 
                    outputMoves.Add(new Move(piece, tempLocation, true));
                }
                //Otherwise we are looking at one of our own pieces
            }
            return outputMoves;
        }

        private static List<Move> FindStraightMoves(Piece piece, int[][] incrementors)
        {
            //Get the moves for each direction

            List<Move> outputMoves = new List<Move>();

            //for each set of direction icrementors
            for (int i = 0; i < incrementors.Length; i++)
            {
                // find the available moves in that direction
                outputMoves.AddRange(FindStraightLine(piece, incrementors[i][0], incrementors[i][1]));
            }

            return outputMoves;
        }


        private static List<Move> FindStraightLine(Piece piece, int colIncrement, int rowIncrement)
        {

            List<Move> outputMoves = new List<Move>();
            bool moving = true;

            int col = piece.locNotation.col;
            int row = piece.locNotation.row;

            int newRow;

            Piece selectedPiece;


            while (moving)
            {

                //move in the selected direction
                col += colIncrement;
                row += rowIncrement;

                //offset the position 
                newRow = offsetRightBoard(col, row);


                try
                {
                    //get the piece at the next square
                    selectedPiece = board.gameBoard[col][newRow];
                }
                catch (Exception)
                {
                    //we have moved outside the bounds of the board
                    //Stop searching in this direction
                    break;
                }

                //if the square is empty
                if (selectedPiece == null)
                {
                    //add it as a potential move 
                    outputMoves.Add(new Move(piece, new LocNotation(col, newRow), false));

                    //look at the next square 
                    continue;
                }
                //if the pieces are not the same color
                else if (selectedPiece.isWhite != piece.isWhite)
                {
                    //add it as a potential move 
                    outputMoves.Add(new Move(piece, new LocNotation(col, newRow), true));

                    //stop moving down the line
                    moving = false;

                }
                //Otherwise we are looking at one of our own pieces
                else
                {
                    //stop moving down the line
                    moving = false;
                }

            }

            return outputMoves;
        }

        private static List<Move> FindPawnMoves(Piece piece)
        {
            List<Move> outputMoves = new List<Move>();

            //Horizontals
            int[][] whitePawnDisplacers = new int[][] {
                new int[2] { -1, 0 }, //up and left
                new int[2] { 1, 1 } //up and right
            };
            int[][] blackPawnDisplacers = new int[][] {
                new int[2] { -1, -1 }, //down and left
                new int[2] {  1, 0 } //down and right
            };

            //Get the location of the piece we are moving
            int col = piece.locNotation.col;
            int row = piece.locNotation.row;

            LocNotation tempLocation;

            Piece selectedPiece;

            int[][] displacements = piece.isWhite ? whitePawnDisplacers : blackPawnDisplacers;

            for (int i = 0; i < displacements.Length; i++)
            {
                //calculate the new position using the displacements
                tempLocation = new LocNotation(col + displacements[i][0], row + displacements[i][1]);

                //offset the position 
                tempLocation = offsetRightBoard(tempLocation);

                try
                {
                    //get the piece at the next square
                    selectedPiece = board.gameBoard[tempLocation.col][tempLocation.row];
                }
                catch (Exception)
                {
                    //we have moved outside the bounds of the board
                    continue;
                }

                //if the square is empty
                if (selectedPiece == null)
                {
                    //look at the next displacement
                    continue;
                }
                //if the pieces are not the same color
                else if (selectedPiece.isWhite != piece.isWhite)
                {
                    //add it as a potential move 
                    outputMoves.Add(new Move(piece, tempLocation, true));
                }
                //Otherwise we are looking at one of our own pieces
            }


            //Look one square ahead
            tempLocation = new LocNotation(col, row + (piece.isWhite ? 1 : -1));

            //offset the position 
            tempLocation = offsetRightBoard(tempLocation);

            try
            {
                //get the piece at the next square
                selectedPiece = board.gameBoard[tempLocation.col][tempLocation.row];
            }
            catch (Exception)
            {
                //we have moved outside the bounds of the board
                return outputMoves;
            }

            //If space is not empty
            if (!(selectedPiece == null))
            {
                //finish the function becuase there is no reason to look 2 squares ahead
                return outputMoves;
            }
            //if the space is empty, add the move
            outputMoves.Add(new Move(piece, tempLocation, false));

            //If the piece is on a starting square
            if (isStartingPawn(piece))
            {
                //Get the square two spaces ahead
                tempLocation = new LocNotation(col, row + (piece.isWhite ? 2 : -2));

                //offset the position 
                tempLocation = offsetRightBoard(tempLocation);

                try
                {
                    //get the piece at the square
                    selectedPiece = board.gameBoard[tempLocation.col][tempLocation.row];
                }
                catch (Exception)
                {
                    //we have moved outside the bounds of the board
                    return outputMoves;
                }

                //if the spot is empty
                if (selectedPiece == null)
                {
                    //add the move
                    outputMoves.Add(new Move(piece, tempLocation, false));
                }
            }

            return outputMoves;
        }


        private static bool isStartingPawn(Piece piece)
        {

            int col = piece.locNotation.col;
            int row = piece.locNotation.row;

            row = offsetRightBoard(col, row);

            // 0 = Glinski,
            if (Utils.gameType == 0)
            {
                if (piece.isWhite)
                {
                    //if we are on the left side of the board
                    if (col < 6)
                    {
                        return col - 1 == row;
                    }
                    //if we are on the right side of the board
                    else
                    {
                        return row + col == 9;
                    }
                }
                else //if piece is black
                {
                    //true if we are on row 6
                    return row == 6;
                }
            }

            // 1 = McCooey,
            if (Utils.gameType == 1)
            {
                if (piece.isWhite)
                {
                    //if we are on the left side of the board
                    if (col < 6)
                    {
                        return col - 2 == row;
                    }
                    //if we are on the right side of the board
                    else
                    {
                        return row + col == 8;
                    }
                }
                else //if piece is black
                {
                    return row == 7;
                }
            }

            // 2 = Hexofen
            else
            {
                Dictionary<int, int> whitePawns = new Dictionary<int, int>
                {
                    { 0, 0 },
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 0 },
                    { 10, 0 }
                };

                Dictionary<int, int> blackPawns = new Dictionary<int, int>
                {
                    { 0, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 3, 7 },
                    { 4, 7 },
                    { 5, 8 },
                    { 6, 7 },
                    { 7, 7 },
                    { 8, 6 },
                    { 9, 6 },
                    { 10, 5 }
                };

                int[] search = new int[2] { col, row };

                if (piece.isWhite)
                {
                    return whitePawns[col] == row;
                }
                else //if piece is black
                {
                    return blackPawns[col] == row;
                }
            }
        }

    }
}
