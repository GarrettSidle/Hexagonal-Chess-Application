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
            label2.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            btnComputer.BackColor = Color.Transparent;
            btnHostGame.BackColor = Color.Transparent;
            btnJoinGame.BackColor = Color.Transparent;
            btnSettings.BackColor = Color.Transparent;
        }

        private void HomeButton_MouseEnter(object sender, EventArgs e)
        {
            Label Label = (Label)sender;
            Label.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void HomeButton_MouseLeave(object sender, EventArgs e)
        {
            Label Label = (Label)sender;
            Label.ForeColor = Color.Black;
        }

        private void btnComputer_Click(object sender, EventArgs e)
        {
            //set the game type to single player
            Utils.userMode = 0;

            //Swap Screens
            MDIParent.swapScreen("Board");
        }

        private void btnHostGame_Click(object sender, EventArgs e)
        {
            //set the game type to Host
            Utils.userMode = 1;

            //Swap Screens
            MDIParent.swapScreen("Board");
        }

        private void btnJoinGame_Click(object sender, EventArgs e)
        {
            //set the game type to client
            Utils.userMode = 0;

            //Swap Screens
            MDIParent.swapScreen("Board");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            
        }
    }
}
