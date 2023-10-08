using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hexagonal_Chess;

namespace Hexagonal_Chess
{
    public partial class FrmWaitingForPlayer : Form
    {
        public FrmWaitingForPlayer()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Utils.gameFound = false;
            this.Close();

            //start the listening function
            Utils.MessageReceiver.DoWork += MessageReceiver_DoWork;
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            //actively search for an intializing ping
            byte[] buffer = new byte[1];
            Utils.sock.Receive(buffer);

            Utils.gameFound = BitConverter.ToBoolean(buffer,0);

            //if we found a game
            if (Utils.gameFound)
            {
                //close this form
                this.Close();
            }
        }
    }
}
