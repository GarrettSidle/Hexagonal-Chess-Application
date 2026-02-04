namespace Hexagonal_Chess
{
    partial class FrmBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEvaluation = new System.Windows.Forms.Panel();
            this.layoutEval = new System.Windows.Forms.TableLayoutPanel();
            this.pnlEvalBottom = new System.Windows.Forms.Panel();
            this.lblBottomEval = new System.Windows.Forms.Label();
            this.pnlEvalTop = new System.Windows.Forms.Panel();
            this.lblTopEval = new System.Windows.Forms.Label();
            this.pnlTopUser = new System.Windows.Forms.Panel();
            this.btnBackToHome = new Hexagonal_Chess.CustomButton();
            this.pnlTurnIndicatorBlack = new System.Windows.Forms.Panel();
            this.imgTopUser = new System.Windows.Forms.PictureBox();
            this.lblTopUserEval = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlBottomUser = new System.Windows.Forms.Panel();
            this.pnlTurnIndicatorWhite = new System.Windows.Forms.Panel();
            this.imgBottomUser = new System.Windows.Forms.PictureBox();
            this.lblBottomUserEval = new System.Windows.Forms.Label();
            this.lblBottomName = new System.Windows.Forms.Label();
            this.pnlMoves = new System.Windows.Forms.Panel();
            this.lblMovesTitle = new System.Windows.Forms.Label();
            this.lblMovesTableRef = new System.Windows.Forms.Label();
            this.dgMoves = new System.Windows.Forms.DataGridView();
            this.colMoveNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWhite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.pnlEngineTerminal = new System.Windows.Forms.Panel();
            this.txtEngineOutput = new System.Windows.Forms.TextBox();
            this.lblEngineTerminalTitle = new System.Windows.Forms.Label();
            this.layoutGame = new System.Windows.Forms.TableLayoutPanel();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.pnlEvaluation.SuspendLayout();
            this.layoutEval.SuspendLayout();
            this.pnlEvalBottom.SuspendLayout();
            this.pnlEvalTop.SuspendLayout();
            this.pnlTopUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTopUser)).BeginInit();
            this.pnlBottomUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBottomUser)).BeginInit();
            this.pnlMoves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMoves)).BeginInit();
            this.pnlBoard.SuspendLayout();
            this.pnlEngineTerminal.SuspendLayout();
            this.layoutGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEvaluation
            // 
            this.pnlEvaluation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.pnlEvaluation.Controls.Add(this.layoutEval);
            this.pnlEvaluation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEvaluation.Location = new System.Drawing.Point(0, 0);
            this.pnlEvaluation.Name = "pnlEvaluation";
            this.pnlEvaluation.Size = new System.Drawing.Size(86, 690);
            this.pnlEvaluation.TabIndex = 0;
            // 
            // layoutEval
            // 
            this.layoutEval.ColumnCount = 1;
            this.layoutEval.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutEval.Controls.Add(this.pnlEvalBottom, 0, 1);
            this.layoutEval.Controls.Add(this.pnlEvalTop, 0, 0);
            this.layoutEval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutEval.Location = new System.Drawing.Point(0, 0);
            this.layoutEval.Margin = new System.Windows.Forms.Padding(0);
            this.layoutEval.Name = "layoutEval";
            this.layoutEval.Padding = new System.Windows.Forms.Padding(10);
            this.layoutEval.RowCount = 2;
            this.layoutEval.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutEval.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutEval.Size = new System.Drawing.Size(86, 690);
            this.layoutEval.TabIndex = 4;
            // 
            // pnlEvalBottom
            // 
            this.pnlEvalBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(245)))));
            this.pnlEvalBottom.Controls.Add(this.lblBottomEval);
            this.pnlEvalBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEvalBottom.Location = new System.Drawing.Point(13, 348);
            this.pnlEvalBottom.Name = "pnlEvalBottom";
            this.pnlEvalBottom.Size = new System.Drawing.Size(60, 329);
            this.pnlEvalBottom.TabIndex = 4;
            // 
            // lblBottomEval
            // 
            this.lblBottomEval.AutoSize = true;
            this.lblBottomEval.BackColor = System.Drawing.Color.Transparent;
            this.lblBottomEval.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBottomEval.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomEval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            this.lblBottomEval.Location = new System.Drawing.Point(0, 297);
            this.lblBottomEval.Name = "lblBottomEval";
            this.lblBottomEval.Padding = new System.Windows.Forms.Padding(3, 0, 0, 10);
            this.lblBottomEval.Size = new System.Drawing.Size(55, 32);
            this.lblBottomEval.TabIndex = 5;
            this.lblBottomEval.Text = "+ 2.0";
            // 
            // pnlEvalTop
            // 
            this.pnlEvalTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlEvalTop.Controls.Add(this.lblTopEval);
            this.pnlEvalTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEvalTop.Location = new System.Drawing.Point(13, 13);
            this.pnlEvalTop.Name = "pnlEvalTop";
            this.pnlEvalTop.Size = new System.Drawing.Size(60, 329);
            this.pnlEvalTop.TabIndex = 3;
            // 
            // lblTopEval
            // 
            this.lblTopEval.AutoSize = true;
            this.lblTopEval.BackColor = System.Drawing.Color.Transparent;
            this.lblTopEval.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopEval.ForeColor = System.Drawing.Color.White;
            this.lblTopEval.Location = new System.Drawing.Point(0, 0);
            this.lblTopEval.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblTopEval.Name = "lblTopEval";
            this.lblTopEval.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.lblTopEval.Size = new System.Drawing.Size(57, 32);
            this.lblTopEval.TabIndex = 3;
            this.lblTopEval.Text = "+ 2.0";
            // 
            // pnlTopUser
            // 
            this.pnlTopUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlTopUser.Controls.Add(this.pnlTurnIndicatorBlack);
            this.pnlTopUser.Controls.Add(this.imgTopUser);
            this.pnlTopUser.Controls.Add(this.lblTopUserEval);
            this.pnlTopUser.Controls.Add(this.lblUser);
            this.pnlTopUser.Controls.Add(this.btnBackToHome);
            this.pnlTopUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopUser.Location = new System.Drawing.Point(3, 3);
            this.pnlTopUser.Name = "pnlTopUser";
            this.pnlTopUser.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlTopUser.Size = new System.Drawing.Size(889, 66);
            this.pnlTopUser.TabIndex = 1;
            // 
            // btnBackToHome
            // 
            this.btnBackToHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackToHome.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnBackToHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToHome.FlatAppearance.BorderSize = 0;
            this.btnBackToHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToHome.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnBackToHome.Location = new System.Drawing.Point(795, 14);
            this.btnBackToHome.Name = "btnBackToHome";
            this.btnBackToHome.Size = new System.Drawing.Size(90, 38);
            this.btnBackToHome.TabIndex = 6;
            this.btnBackToHome.Text = "Home";
            this.btnBackToHome.TextColor = System.Drawing.Color.White;
            this.btnBackToHome.UseVisualStyleBackColor = false;
            this.btnBackToHome.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // pnlTurnIndicatorBlack
            // 
            this.pnlTurnIndicatorBlack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.pnlTurnIndicatorBlack.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTurnIndicatorBlack.Location = new System.Drawing.Point(16, 0);
            this.pnlTurnIndicatorBlack.Name = "pnlTurnIndicatorBlack";
            this.pnlTurnIndicatorBlack.Size = new System.Drawing.Size(5, 66);
            this.pnlTurnIndicatorBlack.TabIndex = 5;
            // 
            // imgTopUser
            // 
            this.imgTopUser.Image = global::Hexagonal_Chess.Properties.Resources.BlackPawn;
            this.imgTopUser.Location = new System.Drawing.Point(40, 8);
            this.imgTopUser.Name = "imgTopUser";
            this.imgTopUser.Size = new System.Drawing.Size(52, 50);
            this.imgTopUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgTopUser.TabIndex = 4;
            this.imgTopUser.TabStop = false;
            // 
            // lblTopUserEval
            // 
            this.lblTopUserEval.AutoSize = true;
            this.lblTopUserEval.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopUserEval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.lblTopUserEval.Location = new System.Drawing.Point(108, 38);
            this.lblTopUserEval.Name = "lblTopUserEval";
            this.lblTopUserEval.Size = new System.Drawing.Size(0, 20);
            this.lblTopUserEval.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(108, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(64, 30);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Black";
            // 
            // pnlBottomUser
            // 
            this.pnlBottomUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(245)))));
            this.pnlBottomUser.Controls.Add(this.pnlTurnIndicatorWhite);
            this.pnlBottomUser.Controls.Add(this.imgBottomUser);
            this.pnlBottomUser.Controls.Add(this.lblBottomUserEval);
            this.pnlBottomUser.Controls.Add(this.lblBottomName);
            this.pnlBottomUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomUser.Location = new System.Drawing.Point(0, 618);
            this.pnlBottomUser.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBottomUser.Name = "pnlBottomUser";
            this.pnlBottomUser.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlBottomUser.Size = new System.Drawing.Size(895, 72);
            this.pnlBottomUser.TabIndex = 2;
            // 
            // pnlTurnIndicatorWhite
            // 
            this.pnlTurnIndicatorWhite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.pnlTurnIndicatorWhite.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTurnIndicatorWhite.Location = new System.Drawing.Point(16, 0);
            this.pnlTurnIndicatorWhite.Name = "pnlTurnIndicatorWhite";
            this.pnlTurnIndicatorWhite.Size = new System.Drawing.Size(5, 72);
            this.pnlTurnIndicatorWhite.TabIndex = 5;
            // 
            // imgBottomUser
            // 
            this.imgBottomUser.Image = global::Hexagonal_Chess.Properties.Resources.WhitePawn;
            this.imgBottomUser.Location = new System.Drawing.Point(40, 8);
            this.imgBottomUser.Name = "imgBottomUser";
            this.imgBottomUser.Size = new System.Drawing.Size(52, 50);
            this.imgBottomUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBottomUser.TabIndex = 4;
            this.imgBottomUser.TabStop = false;
            // 
            // lblBottomUserEval
            // 
            this.lblBottomUserEval.AutoSize = true;
            this.lblBottomUserEval.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomUserEval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(70)))), ((int)(((byte)(60)))));
            this.lblBottomUserEval.Location = new System.Drawing.Point(108, 38);
            this.lblBottomUserEval.Name = "lblBottomUserEval";
            this.lblBottomUserEval.Size = new System.Drawing.Size(0, 20);
            this.lblBottomUserEval.TabIndex = 3;
            // 
            // lblBottomName
            // 
            this.lblBottomName.AutoSize = true;
            this.lblBottomName.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            this.lblBottomName.Location = new System.Drawing.Point(108, 9);
            this.lblBottomName.Name = "lblBottomName";
            this.lblBottomName.Size = new System.Drawing.Size(72, 30);
            this.lblBottomName.TabIndex = 2;
            this.lblBottomName.Text = "White";
            // 
            // pnlMoves
            // 
            this.pnlMoves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.pnlMoves.Controls.Add(this.lblMovesTitle);
            this.pnlMoves.Controls.Add(this.lblMovesTableRef);
            this.pnlMoves.Controls.Add(this.dgMoves);
            this.pnlMoves.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMoves.Location = new System.Drawing.Point(981, 0);
            this.pnlMoves.Name = "pnlMoves";
            this.pnlMoves.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMoves.Size = new System.Drawing.Size(323, 690);
            this.pnlMoves.TabIndex = 3;
            // 
            // lblMovesTitle
            // 
            this.lblMovesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMovesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.lblMovesTitle.Location = new System.Drawing.Point(20, 20);
            this.lblMovesTitle.Name = "lblMovesTitle";
            this.lblMovesTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.lblMovesTitle.Size = new System.Drawing.Size(283, 40);
            this.lblMovesTitle.TabIndex = 4;
            this.lblMovesTitle.Text = "Moves";
            this.lblMovesTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblMovesTableRef
            // 
            this.lblMovesTableRef.AutoSize = true;
            this.lblMovesTableRef.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovesTableRef.Location = new System.Drawing.Point(6, 3);
            this.lblMovesTableRef.Name = "lblMovesTableRef";
            this.lblMovesTableRef.Size = new System.Drawing.Size(0, 19);
            this.lblMovesTableRef.TabIndex = 3;
            this.lblMovesTableRef.Visible = false;
            // 
            // dgMoves
            // 
            this.dgMoves.AllowUserToAddRows = false;
            this.dgMoves.AllowUserToDeleteRows = false;
            this.dgMoves.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(245)))));
            this.dgMoves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgMoves.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgMoves.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMoves.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(243)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White;
            this.dgMoves.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgMoves.EnableHeadersVisualStyles = false;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMoves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgMoves.ColumnHeadersHeight = 36;
            this.dgMoves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgMoves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMoveNumber,
            this.colWhite,
            this.colBlack});
            this.dgMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMoves.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(218)))), ((int)(((byte)(200)))));
            this.dgMoves.Location = new System.Drawing.Point(20, 20);
            this.dgMoves.Name = "dgMoves";
            this.dgMoves.ReadOnly = true;
            this.dgMoves.RowHeadersVisible = false;
            this.dgMoves.RowTemplate.Height = 32;
            this.dgMoves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMoves.Size = new System.Drawing.Size(283, 650);
            this.dgMoves.TabIndex = 0;
            // 
            // colMoveNumber
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMoveNumber.DefaultCellStyle = dataGridViewCellStyle14;
            this.colMoveNumber.HeaderText = "Move";
            this.colMoveNumber.Name = "colMoveNumber";
            this.colMoveNumber.ReadOnly = true;
            this.colMoveNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMoveNumber.Width = 50;
            // 
            // colWhite
            // 
            this.colWhite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colWhite.DefaultCellStyle = dataGridViewCellStyle15;
            this.colWhite.FillWeight = 100.6803F;
            this.colWhite.HeaderText = "White";
            this.colWhite.Name = "colWhite";
            this.colWhite.ReadOnly = true;
            // 
            // colBlack
            // 
            this.colBlack.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colBlack.DefaultCellStyle = dataGridViewCellStyle16;
            this.colBlack.FillWeight = 99.31973F;
            this.colBlack.HeaderText = "Black";
            this.colBlack.Name = "colBlack";
            this.colBlack.ReadOnly = true;
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.pnlBoard.Controls.Add(this.pnlEngineTerminal);
            this.pnlBoard.Controls.Add(this.layoutGame);
            this.pnlBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBoard.Location = new System.Drawing.Point(86, 0);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(895, 690);
            this.pnlBoard.TabIndex = 4;
            // 
            // pnlEngineTerminal
            // 
            this.pnlEngineTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEngineTerminal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlEngineTerminal.Controls.Add(this.txtEngineOutput);
            this.pnlEngineTerminal.Controls.Add(this.lblEngineTerminalTitle);
            this.pnlEngineTerminal.Location = new System.Drawing.Point(595, 520);
            this.pnlEngineTerminal.Name = "pnlEngineTerminal";
            this.pnlEngineTerminal.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
            this.pnlEngineTerminal.Size = new System.Drawing.Size(288, 158);
            this.pnlEngineTerminal.TabIndex = 5;
            this.pnlEngineTerminal.Visible = false;
            // 
            // txtEngineOutput
            // 
            this.txtEngineOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEngineOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtEngineOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEngineOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEngineOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtEngineOutput.Location = new System.Drawing.Point(9, 26);
            this.txtEngineOutput.Multiline = true;
            this.txtEngineOutput.Name = "txtEngineOutput";
            this.txtEngineOutput.ReadOnly = true;
            this.txtEngineOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEngineOutput.Size = new System.Drawing.Size(270, 125);
            this.txtEngineOutput.TabIndex = 1;
            this.txtEngineOutput.WordWrap = false;
            // 
            // lblEngineTerminalTitle
            // 
            this.lblEngineTerminalTitle.AutoSize = true;
            this.lblEngineTerminalTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEngineTerminalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lblEngineTerminalTitle.Location = new System.Drawing.Point(6, 5);
            this.lblEngineTerminalTitle.Name = "lblEngineTerminalTitle";
            this.lblEngineTerminalTitle.Size = new System.Drawing.Size(45, 15);
            this.lblEngineTerminalTitle.TabIndex = 0;
            this.lblEngineTerminalTitle.Text = "Engine";
            // 
            // layoutGame
            // 
            this.layoutGame.BackColor = System.Drawing.Color.Transparent;
            this.layoutGame.ColumnCount = 1;
            this.layoutGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutGame.Controls.Add(this.pnlBottomUser, 0, 2);
            this.layoutGame.Controls.Add(this.pnlTopUser, 0, 0);
            this.layoutGame.Controls.Add(this.pnlGame, 0, 1);
            this.layoutGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutGame.Location = new System.Drawing.Point(0, 0);
            this.layoutGame.Name = "layoutGame";
            this.layoutGame.RowCount = 3;
            this.layoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.layoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.layoutGame.Size = new System.Drawing.Size(895, 690);
            this.layoutGame.TabIndex = 3;
            // 
            // pnlGame
            // 
            this.pnlGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.pnlGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGame.Location = new System.Drawing.Point(3, 75);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(889, 540);
            this.pnlGame.TabIndex = 3;
            this.pnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGame_Paint);
            // 
            // FrmBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1304, 690);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.pnlMoves);
            this.Controls.Add(this.pnlEvaluation);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(50)))), ((int)(((byte)(45)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmBoard_Load);
            this.pnlEvaluation.ResumeLayout(false);
            this.layoutEval.ResumeLayout(false);
            this.pnlEvalBottom.ResumeLayout(false);
            this.pnlEvalBottom.PerformLayout();
            this.pnlEvalTop.ResumeLayout(false);
            this.pnlEvalTop.PerformLayout();
            this.pnlTopUser.ResumeLayout(false);
            this.pnlTopUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTopUser)).EndInit();
            this.pnlBottomUser.ResumeLayout(false);
            this.pnlBottomUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBottomUser)).EndInit();
            this.pnlMoves.ResumeLayout(false);
            this.pnlMoves.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMoves)).EndInit();
            this.pnlBoard.ResumeLayout(false);
            this.pnlEngineTerminal.ResumeLayout(false);
            this.pnlEngineTerminal.PerformLayout();
            this.layoutGame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEvaluation;
        private System.Windows.Forms.Panel pnlTopUser;
        private Hexagonal_Chess.CustomButton btnBackToHome;
        private System.Windows.Forms.Panel pnlTurnIndicatorBlack;
        private System.Windows.Forms.Panel pnlTurnIndicatorWhite;
        private System.Windows.Forms.PictureBox imgTopUser;
        public System.Windows.Forms.Label lblTopUserEval;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlBottomUser;
        private System.Windows.Forms.PictureBox imgBottomUser;
        public System.Windows.Forms.Label lblBottomUserEval;
        private System.Windows.Forms.Label lblBottomName;
        private System.Windows.Forms.Panel pnlMoves;
        private System.Windows.Forms.Label lblMovesTitle;
        public System.Windows.Forms.DataGridView dgMoves;
        private System.Windows.Forms.Panel pnlBoard;
        public System.Windows.Forms.TableLayoutPanel layoutEval;
        private System.Windows.Forms.Panel pnlEvalBottom;
        private System.Windows.Forms.Panel pnlEvalTop;
        public System.Windows.Forms.Label lblTopEval;
        public System.Windows.Forms.Label lblBottomEval;
        private System.Windows.Forms.Label lblMovesTableRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoveNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWhite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlack;
        private System.Windows.Forms.TableLayoutPanel layoutGame;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Panel pnlEngineTerminal;
        private System.Windows.Forms.Label lblEngineTerminalTitle;
        public System.Windows.Forms.TextBox txtEngineOutput;
    }
}