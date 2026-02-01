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
    public partial class FrmWaitingForPlayer : Form
    {
        public FrmWaitingForPlayer()
        {
            InitializeComponent();
        }

        private void FrmWaitingForPlayer_Load(object sender, EventArgs e)
        {
            try
            {
                var hostName = Dns.GetHostName();
                var addresses = Dns.GetHostAddresses(hostName);
                var localIPs = addresses
                    .Where(a => a.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(a))
                    .Select(a => a.ToString())
                    .ToArray();
                lblHostIP.Text = localIPs.Length > 0
                    ? "Your IP: " + string.Join(", ", localIPs)
                    : "Your IP: (unknown)";
            }
            catch
            {
                lblHostIP.Text = "Your IP: (unknown)";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Utils.gameFound = false;
            try
            {
                Utils.server?.Stop();
            }
            catch { }
            this.Close();
        }
    }
}
