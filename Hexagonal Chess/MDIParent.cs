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

            // Hide window until fully loaded to prevent elements popping in
            this.Opacity = 0;
            this.Shown += MDIParent_Shown;

            //initialize each screen and add it to 
            frmHome home = new frmHome();
            screens.Add("Home", home);

            FrmBoard board = new FrmBoard();
            screens.Add("Board", board);

            mdiParent = this;

            home.MdiParent = this;
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void MDIParent_Shown(object sender, EventArgs e)
        {
            this.Shown -= MDIParent_Shown;
            // Defer until after layout and paint complete, then reveal the window
            this.BeginInvoke(new Action(() =>
            {
                Application.DoEvents();
                this.Opacity = 1;
            }));
        }


        public static void swapScreen(string screenName)
        {
            //get the new the screen
            screens.TryGetValue(screenName, out var screen);
            //set it as the new active screen
            screen.MdiParent = mdiParent;
            screen.Dock = DockStyle.Fill;
            screen.Show();
        }

        public static void regenerateBoard()
        {
            //reset them board
            Utils.board = new Utils.Board();

            //close the existing board form
            FrmBoard frmBoard = (FrmBoard) getScreen("Board");
            frmBoard.Dispose();

            frmBoard = new FrmBoard();

            //create a new board form 
            screens["Board"] = frmBoard;
            frmBoard.updateGameMode();
        }

        public static Form getScreen(string screenName)
        {
            //get the form object based on the screen name
            screens.TryGetValue(screenName, out var screen);
            return screen;
        }

    }

}
