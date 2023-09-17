using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hexagonal_Chess
{
    public partial class ResultScreen : Form
    {



        public void setWinner(bool whiteIsWinner, int numOfMoves)
        { 

            string tempWinner = whiteIsWinner ? "White" : "Black";

            //Find the semi colon in the text
            int movesStart = lblGameMoves.Text.IndexOf(':') + 1;

            //add the number of moves after the semicolon
            this.lblGameMoves.Text = $"{lblGameMoves.Text.Remove(movesStart)} {numOfMoves} Moves";
            this.lblGameWinner.Text = $"{tempWinner} Wins!!!";
        }

        public ResultScreen()
        {
            InitializeComponent();
        }


        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            //create a new board
            MDIParent.regenerateBoard();

            //open the new form
            MDIParent.swapScreen("Board");

            //close the results screen
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmBoard board = (FrmBoard) MDIParent.getScreen("Board");

            //create a new board
            MDIParent.regenerateBoard();
            //close the results screen
            this.Close();

            //Swap Screens
            MDIParent.swapScreen("Home");
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
