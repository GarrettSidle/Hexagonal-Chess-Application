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

            Utils.MessageReceiver.DoWork += MessageReceiver_DoWork;
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] buffer = new byte[1];
            Utils.sock.Receive(buffer);

            Utils.gameFound = BitConverter.ToBoolean(buffer,0);

            if (Utils.gameFound)
            {
                this.Close();
            }
        }
    }
}
