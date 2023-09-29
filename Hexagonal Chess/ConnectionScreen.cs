using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

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
            if(txtIP.Text == "")
            {
                MessageBox.Show("Invalid IP");
                return;
            }

            //if the IP is not valid
            if ((!PingHost(txtIP.Text)))
            {
                //show and error message
                MessageBox.Show($"Unable to locate {txtIP.Text}", "Error");
            }
            //if the ip is valid
            else
            {
                //start the game

                Utils.IP = txtIP.Text;
                this.Close();

                FrmBoard board = (FrmBoard)MDIParent.getScreen("Board");

                //local
                board.updateGameMode();



            }
        }

        private static bool PingHost(string address)
        {
            Cursor.Current = Cursors.WaitCursor;


            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(address);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }
            Cursor.Current = Cursors.Default;

            return pingable;
        }
    }
}
