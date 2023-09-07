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

        private bool whiteIsWinner;

        public void setWinner(bool whiteIsWinner)
        {
            this.whiteIsWinner = whiteIsWinner;

            string tempWinner = whiteIsWinner ? "White" : "Black";

            this.lblGameWinner.Text = $"{tempWinner} Wins!!!";
        }

        public ResultScreen()
        {
            InitializeComponent();
        }


        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            FrmBoard board = (FrmBoard)MDIParent.getScreen("Board");

            //close the current board screen
            board.Close();

            //Swap Screens
            MDIParent.swapScreen("Home");
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmBoard board = (FrmBoard) MDIParent.getScreen("Board");

            //close the board screen
            board.Close();

            //Swap Screens
            MDIParent.swapScreen("Home");
            this.Close();
        }
    }
}
