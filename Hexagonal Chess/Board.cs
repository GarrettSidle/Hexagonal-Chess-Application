using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Hexagonal_Chess.Utils;

namespace Hexagonal_Chess
{
    public partial class FrmBoard : Form
    {

        int hexRadius = 45;



        private IDictionary<string, Hexagon> boardNodes = new Dictionary<string, Hexagon>();


        private Board board = new Board();

        public FrmBoard()
        {
            InitializeComponent();
        }

        private void Board_Load(object sender, EventArgs e)
        {
            buildBoard();

        }


        private void buildBoard()
        {
            //Starting point of the entire board, this will be center of A1
            Point startingPosition = new Point(100, 725);

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
            this.Controls.Add(pictureBox);
        }



        private void Board_Paint(object sender, PaintEventArgs e)
        {
            foreach (KeyValuePair<string, Hexagon> node in boardNodes)
            {
                DrawHexagon(node.Value, e);
            }


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


        private async void Piece_Click(object sender, EventArgs e, Piece piece)
        {
            foreach (Control item in this.Controls.OfType<Control>().ToList())
            {
                if (item.Name == "MovementButton")
                    await Task.Run(() => this.Controls.Remove(item));
            }

            List<Move> availableMoves;
            //get all of the available moves for the selected piece
            availableMoves = FindMoves(piece);

            //find the size of the dot based on the hexagon
            int size = (int)Math.Round(hexRadius * 1.0);


            Point tempLocation;
            PictureBox tempImage;
            //
            for (int i = 0; i < availableMoves.Count; i++)
            {

                Move move = availableMoves[i];


                //Get the location of the hexagon on the screen
                tempLocation = boardNodes[move.endLocation.notation].location;

                tempImage = new PictureBox();
                tempImage.Size = new Size(size, size);
                tempImage.Location = new Point(tempLocation.X - size / 2, tempLocation.Y - size / 2);
                tempImage.Name = "MovementButton";
                tempImage.BackColor = Color.Transparent;
                tempImage.Image = Hexagonal_Chess.Properties.Resources.AvailableMove;
                tempImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                //tempImage.Click += (sender, EventArgs) => { Move_Click(sender, EventArgs, piece); };
                this.Controls.Add(tempImage);


            }


        }

        private List<Move> FindMoves(Piece piece)
        {
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



            switch (piece.pieceType)
            {
                case 'P':
                    Moves.AddRange(FindDisplacement(piece, horizontalIncrementors));
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
                    Moves.AddRange(FindStraightMoves(piece, horizontalIncrementors ));
                    Moves.AddRange(FindStraightMoves(piece , diagnalIncrementors));
                    break;

                default:
                    throw new Exception("Invalid Piece Type");
            }
            return Moves;
        }


        private List<Move> FindDisplacement(Piece piece, int[][] displacements)
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
                    outputMoves.Add(new Move(piece, tempLocation));

                    //look at the next displacement
                    continue;
                }
                //if the pieces are not the same color
                else if (selectedPiece.isWhite != piece.isWhite)
                {
                    //add it as a potential move 
                    outputMoves.Add(new Move(piece, tempLocation ));
                }
                //Otherwise we are looking at one of our own pieces
            }
            return outputMoves;
        }

        private List<Move> FindStraightMoves(Piece piece, int[][] incrementors)
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

        private List<Move> FindStraightLine(Piece piece, int colIncrement, int rowIncrement)
        {
            List<Move> outputMoves = new List<Move>();
            bool moving = true;

            int col = piece.locNotation.col;
            int row = piece.locNotation.row;

            Piece selectedPiece;


            while (moving)
            {

                //move in the selected direction
                col += colIncrement;
                row += rowIncrement;

                try
                {
                    //get the piece at the next square
                    selectedPiece = board.gameBoard[col][row];
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
                    outputMoves.Add(new Move(piece, new LocNotation(col, row)));

                    //look at the next square 
                    continue;
                }
                //if the pieces are not the same color
                else if (selectedPiece.isWhite != piece.isWhite)
                {
                    //add it as a potential move 
                    outputMoves.Add(new Move(piece, new LocNotation(col, row)));

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

    }
}
