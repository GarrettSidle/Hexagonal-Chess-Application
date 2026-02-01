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
            MDIParent.regenerateBoard();
            this.Close();
            MDIParent.swapScreen("Home");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIP.Text))
            {
                MessageBox.Show("Please enter an IP address.", "Invalid IP");
                return;
            }

            Utils.IP = txtIP.Text.Trim();
            this.Close();
            FrmBoard board = (FrmBoard)MDIParent.getScreen("Board");
            try
            {
                board.updateGameMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to connect. Make sure the host is waiting for a player.\n\n{ex.Message}", "Connection failed");
            }
        }
    }
}
