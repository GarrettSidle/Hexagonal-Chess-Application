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
    public partial class MDIParent : Form
    {
        public static IDictionary<string, Form> screens = new Dictionary<string, Form>();
        public static MDIParent mdiParent;
        public MDIParent()
        {
            InitializeComponent();

            // hide til loaded so nothing pops in
            this.Opacity = 0;
            this.Shown += MDIParent_Shown;

            // Home only, Board lazy loaded when game starts
            frmHome home = new frmHome();
            screens.Add("Home", home);

            mdiParent = this;

            home.MdiParent = this;
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void MDIParent_Shown(object sender, EventArgs e)
        {
            this.Shown -= MDIParent_Shown;
            // after layout/paint then show
            this.BeginInvoke(new Action(() =>
            {
                Application.DoEvents();
                this.Opacity = 1;
            }));
        }


        public static void swapScreen(string screenName)
        {
            if (!screens.TryGetValue(screenName, out Form screen))
                return;
            screen.MdiParent = mdiParent;
            screen.Dock = DockStyle.Fill;
            screen.Show();
            screen.BringToFront();
        }

        public static void regenerateBoard()
        {
            //reset the board state
            Utils.board = new Utils.Board();

            FrmBoard oldBoard = (FrmBoard)getScreen("Board");

            // register new board before tearing down old so getScreen never returns disposed one
            FrmBoard newBoard = new FrmBoard();
            screens["Board"] = newBoard;

            // tear down old: detach, close, dispose
            oldBoard.MdiParent = null;
            if (mdiParent != null && mdiParent.Controls.Contains(oldBoard))
                mdiParent.Controls.Remove(oldBoard);
            oldBoard.Close();
            oldBoard.Dispose();

            newBoard.updateGameMode();
        }

        public static Form getScreen(string screenName)
        {
            // Lazy load Board on first access - it's the heaviest screen
            if (screenName == "Board" && !screens.ContainsKey("Board"))
            {
                var board = new FrmBoard();
                screens.Add("Board", board);
            }

            //get the form object based on the screen name
            screens.TryGetValue(screenName, out var screen);
            return screen;
        }

    }

}
