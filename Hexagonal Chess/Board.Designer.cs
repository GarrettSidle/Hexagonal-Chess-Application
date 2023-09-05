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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEvaluation = new System.Windows.Forms.Panel();
            this.layoutEval = new System.Windows.Forms.TableLayoutPanel();
            this.pnlEvalBottom = new System.Windows.Forms.Panel();
            this.lblBottomEval = new System.Windows.Forms.Label();
            this.pnlEvalTop = new System.Windows.Forms.Panel();
            this.lblTopEval = new System.Windows.Forms.Label();
            this.pnlTopUser = new System.Windows.Forms.Panel();
            this.imgTopUser = new System.Windows.Forms.PictureBox();
            this.lblTopUserEval = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlBottomUser = new System.Windows.Forms.Panel();
            this.imgBottomUser = new System.Windows.Forms.PictureBox();
            this.lblBottomUserEval = new System.Windows.Forms.Label();
            this.lblBottomName = new System.Windows.Forms.Label();
            this.pnlMoves = new System.Windows.Forms.Panel();
            this.dgMoves = new System.Windows.Forms.DataGridView();
            this.colMoveNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWhite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBoard = new System.Windows.Forms.Panel();
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
            this.SuspendLayout();
            // 
            // pnlEvaluation
            // 
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
            this.pnlEvalBottom.BackColor = System.Drawing.Color.White;
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
            this.lblBottomEval.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomEval.ForeColor = System.Drawing.Color.Black;
            this.lblBottomEval.Location = new System.Drawing.Point(0, 297);
            this.lblBottomEval.Name = "lblBottomEval";
            this.lblBottomEval.Padding = new System.Windows.Forms.Padding(3, 0, 0, 10);
            this.lblBottomEval.Size = new System.Drawing.Size(55, 32);
            this.lblBottomEval.TabIndex = 5;
            this.lblBottomEval.Text = "+ 2.0";
            // 
            // pnlEvalTop
            // 
            this.pnlEvalTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
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
            this.lblTopEval.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTopEval.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTopEval.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopEval.ForeColor = System.Drawing.Color.White;
            this.lblTopEval.Location = new System.Drawing.Point(5, 0);
            this.lblTopEval.Name = "lblTopEval";
            this.lblTopEval.Padding = new System.Windows.Forms.Padding(3, 10, 0, 0);
            this.lblTopEval.Size = new System.Drawing.Size(55, 32);
            this.lblTopEval.TabIndex = 3;
            this.lblTopEval.Text = "+ 2.0";
            // 
            // pnlTopUser
            // 
            this.pnlTopUser.Controls.Add(this.imgTopUser);
            this.pnlTopUser.Controls.Add(this.lblTopUserEval);
            this.pnlTopUser.Controls.Add(this.lblUser);
            this.pnlTopUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopUser.Location = new System.Drawing.Point(0, 0);
            this.pnlTopUser.Name = "pnlTopUser";
            this.pnlTopUser.Size = new System.Drawing.Size(895, 72);
            this.pnlTopUser.TabIndex = 1;
            // 
            // imgTopUser
            // 
            this.imgTopUser.Image = global::Hexagonal_Chess.Properties.Resources.BlackPawn;
            this.imgTopUser.Location = new System.Drawing.Point(19, 3);
            this.imgTopUser.Name = "imgTopUser";
            this.imgTopUser.Size = new System.Drawing.Size(60, 49);
            this.imgTopUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgTopUser.TabIndex = 4;
            this.imgTopUser.TabStop = false;
            // 
            // lblTopUserEval
            // 
            this.lblTopUserEval.AutoSize = true;
            this.lblTopUserEval.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopUserEval.ForeColor = System.Drawing.Color.Black;
            this.lblTopUserEval.Location = new System.Drawing.Point(87, 40);
            this.lblTopUserEval.Name = "lblTopUserEval";
            this.lblTopUserEval.Size = new System.Drawing.Size(68, 21);
            this.lblTopUserEval.TabIndex = 3;
            this.lblTopUserEval.Text = "♙♙ +2";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(85, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(77, 31);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Black";
            // 
            // pnlBottomUser
            // 
            this.pnlBottomUser.Controls.Add(this.imgBottomUser);
            this.pnlBottomUser.Controls.Add(this.lblBottomUserEval);
            this.pnlBottomUser.Controls.Add(this.lblBottomName);
            this.pnlBottomUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomUser.Location = new System.Drawing.Point(0, 618);
            this.pnlBottomUser.Name = "pnlBottomUser";
            this.pnlBottomUser.Size = new System.Drawing.Size(895, 72);
            this.pnlBottomUser.TabIndex = 2;
            // 
            // imgBottomUser
            // 
            this.imgBottomUser.Image = global::Hexagonal_Chess.Properties.Resources.WhitePawn;
            this.imgBottomUser.Location = new System.Drawing.Point(19, 3);
            this.imgBottomUser.Name = "imgBottomUser";
            this.imgBottomUser.Size = new System.Drawing.Size(60, 49);
            this.imgBottomUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBottomUser.TabIndex = 4;
            this.imgBottomUser.TabStop = false;
            // 
            // lblBottomUserEval
            // 
            this.lblBottomUserEval.AutoSize = true;
            this.lblBottomUserEval.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomUserEval.ForeColor = System.Drawing.Color.Black;
            this.lblBottomUserEval.Location = new System.Drawing.Point(87, 40);
            this.lblBottomUserEval.Name = "lblBottomUserEval";
            this.lblBottomUserEval.Size = new System.Drawing.Size(68, 21);
            this.lblBottomUserEval.TabIndex = 3;
            this.lblBottomUserEval.Text = "♙♙ +2";
            // 
            // lblBottomName
            // 
            this.lblBottomName.AutoSize = true;
            this.lblBottomName.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomName.ForeColor = System.Drawing.Color.Black;
            this.lblBottomName.Location = new System.Drawing.Point(85, 9);
            this.lblBottomName.Name = "lblBottomName";
            this.lblBottomName.Size = new System.Drawing.Size(87, 31);
            this.lblBottomName.TabIndex = 2;
            this.lblBottomName.Text = "White";
            // 
            // pnlMoves
            // 
            this.pnlMoves.Controls.Add(this.dgMoves);
            this.pnlMoves.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMoves.Location = new System.Drawing.Point(981, 0);
            this.pnlMoves.Name = "pnlMoves";
            this.pnlMoves.Padding = new System.Windows.Forms.Padding(30);
            this.pnlMoves.Size = new System.Drawing.Size(323, 690);
            this.pnlMoves.TabIndex = 3;
            // 
            // dgMoves
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMoves.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgMoves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMoves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMoveNumber,
            this.colWhite,
            this.colBlack});
            this.dgMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMoves.Location = new System.Drawing.Point(30, 30);
            this.dgMoves.Name = "dgMoves";
            this.dgMoves.ReadOnly = true;
            this.dgMoves.Size = new System.Drawing.Size(263, 630);
            this.dgMoves.TabIndex = 0;
            // 
            // colMoveNumber
            // 
            this.colMoveNumber.HeaderText = "Move";
            this.colMoveNumber.Name = "colMoveNumber";
            this.colMoveNumber.ReadOnly = true;
            this.colMoveNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMoveNumber.Width = 40;
            // 
            // colWhite
            // 
            this.colWhite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colWhite.HeaderText = "White";
            this.colWhite.Name = "colWhite";
            this.colWhite.ReadOnly = true;
            // 
            // colBlack
            // 
            this.colBlack.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBlack.HeaderText = "Black";
            this.colBlack.Name = "colBlack";
            this.colBlack.ReadOnly = true;
            // 
            // pnlBoard
            // 
            this.pnlBoard.Controls.Add(this.pnlBottomUser);
            this.pnlBoard.Controls.Add(this.pnlTopUser);
            this.pnlBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBoard.Location = new System.Drawing.Point(86, 0);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(895, 690);
            this.pnlBoard.TabIndex = 4;
            this.pnlBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);
            // 
            // FrmBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 690);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.pnlMoves);
            this.Controls.Add(this.pnlEvaluation);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Board_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgMoves)).EndInit();
            this.pnlBoard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEvaluation;
        private System.Windows.Forms.Panel pnlTopUser;
        private System.Windows.Forms.PictureBox imgTopUser;
        public System.Windows.Forms.Label lblTopUserEval;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlBottomUser;
        private System.Windows.Forms.PictureBox imgBottomUser;
        public System.Windows.Forms.Label lblBottomUserEval;
        private System.Windows.Forms.Label lblBottomName;
        private System.Windows.Forms.Panel pnlMoves;
        public System.Windows.Forms.DataGridView dgMoves;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.TableLayoutPanel layoutEval;
        private System.Windows.Forms.Panel pnlEvalBottom;
        private System.Windows.Forms.Panel pnlEvalTop;
        private System.Windows.Forms.Label lblTopEval;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoveNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWhite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBlack;
        private System.Windows.Forms.Label lblBottomEval;
    }
}