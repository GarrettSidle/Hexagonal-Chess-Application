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

        private void Form1_Load(object sender, EventArgs e)
        {
            lblSubitle.BackColor = Color.Transparent;
            lblTitle.BackColor = Color.Transparent;
            btnSettings.BackColor = Color.Transparent;
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            //set the game type to single player
            Utils.userMode = 0;

            //Swap Screens
            MDIParent.swapScreen("Board");
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            //set the game type to Host
            Utils.userMode = 1;

            //Swap Screens
            MDIParent.swapScreen("Board");
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            //set the game type to client
            Utils.userMode = 0;

            //Swap Screens
            MDIParent.swapScreen("Board");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.ShowDialog();
        }

    }
}
