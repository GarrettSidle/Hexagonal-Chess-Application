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
    public partial class FrmConnection : Form
    {
        public FrmConnection()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FrmBoard board = (FrmBoard)MDIParent.getScreen("Board");

            //create a new board
            MDIParent.regenerateBoard();
            //close the results screen
            this.Close();

            //Swap Screens
            MDIParent.swapScreen("Home");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Utils.IP = txtIP.Text;
            this.Close();

            FrmBoard board = (FrmBoard)MDIParent.getScreen("Board");
            //local
            //board.updateGameMode();


            //Swap Screens
            MDIParent.swapScreen("Board");
        }
    }
}
