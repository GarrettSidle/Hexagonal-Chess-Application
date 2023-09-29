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

        private int currentGameType;

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            setGameType(Utils.gameType);
        }


        private void setGameType(int gameType)
        {
            currentGameType = gameType;
            Utils.gameType = gameType;

            //set all buttons to inactive
            btnGlinksi.ButtonColor = inactiveButton;
            btnGlinksi.BorderColor = inactiveBorder;

            btnMcCooey.ButtonColor = inactiveButton;
            btnMcCooey.BorderColor = inactiveBorder;

            btnHexofen.ButtonColor = inactiveButton;
            btnHexofen.BorderColor = inactiveBorder;

            CustomButton customButton;

            //get the active button
            switch (gameType)
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

            customButton.ButtonColor = activeButton;
            customButton.BorderColor = activeBorder;

            Utils.board.setBoard();
        }

        private void btnGlinksi_Click(object sender, EventArgs e)
        {
            setGameType(0);
        }

        private void btnMcCooey_Click(object sender, EventArgs e)
        {
            setGameType(1);
        }

        private void btnHexofen_Click(object sender, EventArgs e)
        {
            setGameType(2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Utils.gameType = currentGameType;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
