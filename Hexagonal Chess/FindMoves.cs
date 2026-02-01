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

            ////Offset.
            //if (piece.locNotation.col > 5)
            //{
            //    //shift the row up  by the number of columns it is right of center
            //    int newRow = piece.locNotation.row - 5 + piece.locNotation.col;
            //    //if we are off the board, continue to the next
            //    if (newRow > 0)
            //    {
            //        piece.locNotation.setRow(newRow);
            //    }
            //}

            //select the appropriate moves based on the piece type
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


        
        private static List<Move> FindDisplacement(Piece piece, int[][] displacements)
        {
            List<Move> outputMoves = new List<Move>();

            //Get the location of the piece we are moving (storage coords)
            int col = piece.locNotation.col;
            int row = piece.locNotation.row;
            int logicalRow = GetLogicalRow(col, row);

            LocNotation tempLocation;

            //represents the square we are trying to move to 
            Piece selectedPiece;

            //For each potential move
            for (int i = 0; i < displacements.Length; i++)
            {
                int dc = displacements[i][0];
                int dr = displacements[i][1];
                int newCol = col + dc;
                int newLogicalRow = logicalRow + dr;
                int newStorageRow = GetStorageRow(newCol, newLogicalRow);

                tempLocation = new LocNotation(newCol, newStorageRow);

                try
                {
                    //get the piece at the next square (use storage row for array index)
                    selectedPiece = board.gameBoard[newCol][newStorageRow];
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
                    outputMoves.Add(new Move(piece, tempLocation, false, false));

                    //look at the next displacement
                    continue;
                }
                //if the pieces are not the same color
                else if (selectedPiece.isWhite != piece.isWhite)
                {
                    //add it as a potential move 
                    outputMoves.Add(new Move(piece, tempLocation, true, false));
                }
                //Otherwise we are looking at one of our own pieces
            }
            return outputMoves;
        }

        //used when calculating both horizontal and diaganal moves
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

        //return the moves when looking in on specific direction
        private static List<Move> FindStraightLine(Piece piece, int colIncrement, int rowIncrement)
        {

            List<Move> outputMoves = new List<Move>();
            bool moving = true;

            int col = piece.locNotation.col;
            int row = piece.locNotation.row;
            int logicalRow = GetLogicalRow(col, row);

            int storageRow;

            Piece selectedPiece;

            //while we are still on the board, and haven't hit a piece
            while (moving)
            {

                //move in the selected direction (in logical row space)
                col += colIncrement;
                logicalRow += rowIncrement;
                storageRow = GetStorageRow(col, logicalRow);

                try
                {
                    //get the piece at the next square (use storage row for array index)
                    selectedPiece = board.gameBoard[col][storageRow];
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
                    outputMoves.Add(new Move(piece, new LocNotation(col, storageRow), false, false));

                    //look at the next square 
                    continue;
                }
                //if the pieces are not the same color
                else if (selectedPiece.isWhite != piece.isWhite)
                {
                    //add it as a potential move 
                    outputMoves.Add(new Move(piece, new LocNotation(col, storageRow), true, false));

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

            //return the found moves
            return outputMoves;
        }

      

        //calculates if a piece is standing on a startinng hex
        private static bool isStartingPawn(Piece piece)
        {

            int col = piece.locNotation.col;
            int row = piece.locNotation.row;

            //row = offsetRightBoard(col, row);

            // 0 = Glinski,
            if (Utils.gameVarient == 0)
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
            if (Utils.gameVarient == 1)
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
                Dictionary<int, int> whiteStartingPawns = new Dictionary<int, int>
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

                Dictionary<int, int> blackStartingPawns = new Dictionary<int, int>
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

                //return true, if the piece matches the preset array
                if (piece.isWhite)
                {
                    return whiteStartingPawns[col] == row;
                }
                else //if piece is black
                {
                    return blackStartingPawns[col] == row;
                }
            }
        }


        private static List<Move> FindPawnMoves(Piece piece)
        {
            List<Move> outputMoves = new List<Move>();

            int col = piece.locNotation.col;
            int row = piece.locNotation.row;
            int logicalRow = GetLogicalRow(col, row);

            int[][] whitePawnDisplacers = new int[][] {
                new int[2] { -1, 0 }, //up and left
                new int[2] { 1, 1 } //up and right
            };
            int[][] blackPawnDisplacers = new int[][] {
                new int[2] { -1, -1 }, //down and left
                new int[2] {  1, 0 } //down and right
            };
            //select the corret displacement
            int[][] displacements = piece.isWhite ? whitePawnDisplacers : blackPawnDisplacers;

            //find the en passent square
            string enPassantSquareNotation = findEnPassentSquare();


            Piece selectedPiece;
            LocNotation tempLocation;
            foreach (int[] displacement in displacements)
            {
                int newCol = col + displacement[0];
                int newLogicalRow = logicalRow + displacement[1];
                int newStorageRow = GetStorageRow(newCol, newLogicalRow);
                tempLocation = new LocNotation(newCol, newStorageRow);
                
                //if we are looking at an en passent square
                if (tempLocation.notation == enPassantSquareNotation)
                {
                    //add the move
                    outputMoves.Add(new Move(piece, tempLocation, true, true));
                    continue;
                }

                try
                {
                    //get the piece at the next square (use storage row for array index)
                    selectedPiece = board.gameBoard[newCol][newStorageRow];
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
                    outputMoves.Add(new Move(piece, tempLocation, true, false));
                }
                //Otherwise we are looking at one of our own pieces
            }


            //Look one square ahead (in logical row)
            int forwardLogicalRow = logicalRow + (piece.isWhite ? 1 : -1);
            int forwardStorageRow = GetStorageRow(col, forwardLogicalRow);
            tempLocation = new LocNotation(col, forwardStorageRow);

            try
            {
                //get the piece at the next square
                selectedPiece = board.gameBoard[col][forwardStorageRow];
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
            outputMoves.Add(new Move(piece, tempLocation, false, false));

            //If the piece is on a starting square
            if (isStartingPawn(piece))
            {
                //Get the square two spaces ahead (in logical row)
                int doubleForwardLogicalRow = logicalRow + (piece.isWhite ? 2 : -2);
                int doubleForwardStorageRow = GetStorageRow(col, doubleForwardLogicalRow);
                tempLocation = new LocNotation(col, doubleForwardStorageRow);

                try
                {
                    //get the piece at the square
                    selectedPiece = board.gameBoard[col][doubleForwardStorageRow];
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
                    outputMoves.Add(new Move(piece, tempLocation, false, false));
                }
            }


            return outputMoves;
        }

        private static string findEnPassentSquare()
        {
            //if there is a previous move
            if (board.prevMove != null)
            {
                var temp = board.prevMove;  
                //if the previous move was a pawn double move
                if (Math.Abs(board.prevMove.startLocation.row - board.prevMove.endLocation.row) == 2 && board.prevMove.piece.pieceType == 'P')
                {
                    
                    //find the square between your moves
                    return new LocNotation(board.prevMove.endLocation.col, board.prevMove.piece.isWhite ? board.prevMove.endLocation.row - 1 : board.prevMove.endLocation.row+ 1).notation;
                }
            }
            return null;
        }


        /// <summary>
        /// Converts storage row (array index) to logical row for move direction math.
        /// On the right side of the board (col > 5), columns have fewer rows, so the same
        /// logical "horizontal line" has a higher logical row index.
        /// </summary>
        private static int GetLogicalRow(int col, int storageRow)
        {
            if (col <= 5) return storageRow;
            return storageRow + col - 5;
        }

        /// <summary>
        /// Converts logical row (from move direction math) to storage row (array index).
        /// </summary>
        private static int GetStorageRow(int col, int logicalRow)
        {
            if (col <= 5) return logicalRow;
            return logicalRow + 5 - col;
        }

        public static LocNotation offsetRightBoard(LocNotation origLocNotation)
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
    }
}
