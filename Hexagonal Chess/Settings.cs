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
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        private Color inactiveButton = Color.Gray;
        private Color inactiveBorder = Color.Silver;

        private Color activeButton = Color.FromArgb(136, 171, 95);
        private Color activeBorder = Color.FromArgb(102, 133, 64);

        private int currentGameVarient;

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            // set selected varient
            setGameVarient(Utils.gameVarient);
            // load engine debug (default off)
            chkEngineDebugMode.Checked = Properties.Settings.Default.EngineDebugMode;
            // load bot max nodes, clamp to slider
            int maxNodes = Properties.Settings.Default.BotMaxNodes;
            if (maxNodes < trkMaxNodes.Minimum) maxNodes = trkMaxNodes.Minimum;
            if (maxNodes > trkMaxNodes.Maximum) maxNodes = trkMaxNodes.Maximum;
            trkMaxNodes.Value = maxNodes;
            lblMaxNodesValue.Text = maxNodes.ToString();
        }

        private void trkMaxNodes_ValueChanged(object sender, EventArgs e)
        {
            lblMaxNodesValue.Text = trkMaxNodes.Value.ToString();
        }


        private void setGameVarient(int gameVarient)
        {
            currentGameVarient = gameVarient;

            //set all buttons to inactive
            btnGlinksi.ButtonColor = inactiveButton;
            btnGlinksi.BorderColor = inactiveBorder;

            btnMcCooey.ButtonColor = inactiveButton;
            btnMcCooey.BorderColor = inactiveBorder;

            btnHexofen.ButtonColor = inactiveButton;
            btnHexofen.BorderColor = inactiveBorder;

            CustomButton customButton;

            //get the active button
            switch (gameVarient)
            {
                case 0:
                    customButton = btnGlinksi;
                    break;
                case 1:
                    customButton = btnMcCooey;
                    break;
                case 2:
                    customButton = btnHexofen;
                    break;
                default:
                    throw new Exception("Invalid Game Type");
            }
            //show the selected button as active
            customButton.ButtonColor = activeButton;
            customButton.BorderColor = activeBorder;

            //reset the board, using this new value
            Utils.board.setBoard();
        }

        private void btnGlinksi_Click(object sender, EventArgs e)
        {
            setGameVarient(0);
        }

        private void btnMcCooey_Click(object sender, EventArgs e)
        {
            setGameVarient(1);
        }

        private void btnHexofen_Click(object sender, EventArgs e)
        {
            setGameVarient(2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //save the selected value
            Utils.gameVarient = currentGameVarient;
            // save engine debug mode
            Properties.Settings.Default.EngineDebugMode = chkEngineDebugMode.Checked;
            // save bot max nodes
            Properties.Settings.Default.BotMaxNodes = trkMaxNodes.Value;
            Properties.Settings.Default.Save();
            //reset the board
            Utils.board.setBoard();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
