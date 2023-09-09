﻿using System;
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


        public static void swapScreen(string screenName)
        {
            screens.TryGetValue(screenName, out var screen);
            screen.MdiParent = mdiParent;
            screen.Dock = DockStyle.Fill;
            screen.Show();
        }

        public static void regenerateBoard()
        {
            //reset them board
            Utils.board = new Utils.Board();

            //close the existing board form
            Form frmBoard = getScreen("Board");
            frmBoard.Close();

            //create a new board form 
            screens["Board"] = new FrmBoard();
        }

        public static Form getScreen(string screenName)
        {
            screens.TryGetValue(screenName, out var screen);
            return screen;
        }

    }

}
