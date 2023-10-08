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


    public partial class frmHome : Form
    {

        public frmHome()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //center the selection panel
            pnlSelection.Location = new Point((this.Width - pnlSelection.Width) / 2, (this.Height - pnlSelection.Height) / 2 - 50);
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            //set the game type to single player
            Utils.userMode = 0;

            FrmBoard board = (FrmBoard)MDIParent.getScreen("Board");
            //regenerate the board
            board.updateGameMode();

            //Swap Screens
            MDIParent.swapScreen("Board");
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            //start looking for a connection
            FrmWaitingForPlayer frmWaitingForPlayer = new FrmWaitingForPlayer();
            frmWaitingForPlayer.ShowDialog();

            //if we found a connection
            if (Utils.gameFound)
            {
                //set the game type to Host
                Utils.userMode = 1;

                FrmBoard board = (FrmBoard)MDIParent.getScreen("Board");
                //regenerate the board
                board.updateGameMode();

                //Swap Screens
                MDIParent.swapScreen("Board");
            }

        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            //set the game type to client
            Utils.userMode = 2;

            //open the connection form
            FrmConnection frmConnection = new FrmConnection();
            frmConnection.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //show to settigns form
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.ShowDialog();
        }
    }
}
