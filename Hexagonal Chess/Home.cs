using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
            FrmBoard.CleanupMultiplayerStatic();
            Utils.gameFound = false;
            Utils.sock = null;
            try
            {
                Utils.server = new TcpListener(IPAddress.Any, Utils.GamePort);
                Utils.server.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not start server: {ex.Message}", "Error");
                return;
            }

            FrmWaitingForPlayer frmWaitingForPlayer = new FrmWaitingForPlayer();
            Task.Run(() =>
            {
                try
                {
                    Utils.sock = Utils.server.AcceptSocket();
                    byte[] ready = new byte[1];
                    if (Utils.sock.Receive(ready) >= 1)
                    {
                        Utils.gameFound = true;
                        if (frmWaitingForPlayer.IsHandleCreated)
                            frmWaitingForPlayer.Invoke((Action)(() => frmWaitingForPlayer.Close()));
                    }
                }
                catch (ObjectDisposedException) { }
                catch (SocketException) { }
                catch (Exception) { }
            });

            frmWaitingForPlayer.ShowDialog();

            if (Utils.gameFound)
            {
                Utils.userMode = 1;
                FrmBoard board = (FrmBoard)MDIParent.getScreen("Board");
                board.updateGameMode();
                MDIParent.swapScreen("Board");
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            Utils.userMode = 2;
            FrmBoard.CleanupMultiplayerStatic();
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
