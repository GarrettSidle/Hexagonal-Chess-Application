namespace Hexagonal_Chess
{
    partial class ResultScreen
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
            this.layoutContent = new System.Windows.Forms.TableLayoutPanel();
            this.lblGameWinner = new System.Windows.Forms.Label();
            this.layoutButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnPlayAgain = new Hexagonal_Chess.CustomButton();
            this.btnHome = new Hexagonal_Chess.CustomButton();
            this.lblGameMoves = new System.Windows.Forms.Label();
            this.layoutContent.SuspendLayout();
            this.layoutButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutContent
            // 
            this.layoutContent.BackColor = System.Drawing.Color.Transparent;
            this.layoutContent.ColumnCount = 1;
            this.layoutContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutContent.Controls.Add(this.lblGameWinner, 0, 0);
            this.layoutContent.Controls.Add(this.layoutButtons, 0, 2);
            this.layoutContent.Controls.Add(this.lblGameMoves, 0, 1);
            this.layoutContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutContent.Location = new System.Drawing.Point(0, 0);
            this.layoutContent.Name = "layoutContent";
            this.layoutContent.RowCount = 3;
            this.layoutContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutContent.Size = new System.Drawing.Size(657, 492);
            this.layoutContent.TabIndex = 0;
            // 
            // lblGameWinner
            // 
            this.lblGameWinner.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            this.lblGameWinner.AutoSize = true;
            this.lblGameWinner.BackColor = System.Drawing.Color.Transparent;
            this.lblGameWinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGameWinner.Font = new System.Drawing.Font("Sitka Text", 56.24999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblGameWinner.ForeColor = System.Drawing.Color.Black;
            this.lblGameWinner.Location = new System.Drawing.Point(3, 0);
            this.lblGameWinner.Name = "lblGameWinner";
            this.lblGameWinner.Size = new System.Drawing.Size(651, 196);
            this.lblGameWinner.TabIndex = 3;
            this.lblGameWinner.Text = "COLOR WINS!!!";
            this.lblGameWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layoutButtons
            // 
            this.layoutButtons.ColumnCount = 2;
            this.layoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutButtons.Controls.Add(this.btnPlayAgain, 0, 0);
            this.layoutButtons.Controls.Add(this.btnHome, 1, 0);
            this.layoutButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutButtons.Location = new System.Drawing.Point(3, 346);
            this.layoutButtons.Name = "layoutButtons";
            this.layoutButtons.RowCount = 1;
            this.layoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutButtons.Size = new System.Drawing.Size(651, 143);
            this.layoutButtons.TabIndex = 4;
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayAgain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.btnPlayAgain.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnPlayAgain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlayAgain.FlatAppearance.BorderSize = 0;
            this.btnPlayAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayAgain.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayAgain.Location = new System.Drawing.Point(20, 20);
            this.btnPlayAgain.Margin = new System.Windows.Forms.Padding(20);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnPlayAgain.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPlayAgain.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnPlayAgain.Size = new System.Drawing.Size(285, 103);
            this.btnPlayAgain.TabIndex = 2;
            this.btnPlayAgain.Text = "Play Again";
            this.btnPlayAgain.TextColor = System.Drawing.Color.White;
            this.btnPlayAgain.UseVisualStyleBackColor = false;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.btnHome.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Location = new System.Drawing.Point(345, 20);
            this.btnHome.Margin = new System.Windows.Forms.Padding(20);
            this.btnHome.Name = "btnHome";
            this.btnHome.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnHome.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHome.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnHome.Size = new System.Drawing.Size(286, 103);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.TextColor = System.Drawing.Color.White;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // lblGameMoves
            // 
            this.lblGameMoves.AutoSize = true;
            this.lblGameMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGameMoves.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameMoves.Location = new System.Drawing.Point(3, 196);
            this.lblGameMoves.Name = "lblGameMoves";
            this.lblGameMoves.Size = new System.Drawing.Size(651, 147);
            this.lblGameMoves.TabIndex = 5;
            this.lblGameMoves.Text = "Your game took : XX Moves";
            this.lblGameMoves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Hexagonal_Chess.Properties.Resources.Trophy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(657, 492);
            this.ControlBox = false;
            this.Controls.Add(this.layoutContent);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ResultScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.layoutContent.ResumeLayout(false);
            this.layoutContent.PerformLayout();
            this.layoutButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutContent;
        private System.Windows.Forms.Label lblGameWinner;
        private System.Windows.Forms.TableLayoutPanel layoutButtons;
        private CustomButton btnPlayAgain;
        private CustomButton btnHome;
        private System.Windows.Forms.Label lblGameMoves;
    }
}