namespace Hexagonal_Chess
{
    partial class frmHome
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
            this.lblSubitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSinglePlayer = new Hexagonal_Chess.CustomButton();
            this.layoutHomeButtons = new System.Windows.Forms.TableLayoutPanel();
            this.layoutLowerButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnHost = new Hexagonal_Chess.CustomButton();
            this.btnJoin = new Hexagonal_Chess.CustomButton();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.layoutUpperButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSettings = new Hexagonal_Chess.CustomButton();
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.layoutHomeButtons.SuspendLayout();
            this.layoutLowerButtons.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.layoutUpperButtons.SuspendLayout();
            this.pnlSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSubitle
            // 
            this.lblSubitle.AutoSize = true;
            this.lblSubitle.Font = new System.Drawing.Font("Sitka Text", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.lblSubitle.Location = new System.Drawing.Point(97, 134);
            this.lblSubitle.Name = "lblSubitle";
            this.lblSubitle.Size = new System.Drawing.Size(212, 35);
            this.lblSubitle.TabIndex = 3;
            this.lblSubitle.Text = "Hexagonal Chess";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Sitka Text", 89.99999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.lblTitle.Location = new System.Drawing.Point(10, -8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(389, 174);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "cHEX";
            // 
            // btnSinglePlayer
            // 
            this.btnSinglePlayer.BackColor = System.Drawing.Color.Transparent;
            this.btnSinglePlayer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.btnSinglePlayer.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnSinglePlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSinglePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSinglePlayer.FlatAppearance.BorderSize = 0;
            this.btnSinglePlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinglePlayer.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinglePlayer.Location = new System.Drawing.Point(20, 20);
            this.btnSinglePlayer.Margin = new System.Windows.Forms.Padding(20);
            this.btnSinglePlayer.Name = "btnSinglePlayer";
            this.btnSinglePlayer.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnSinglePlayer.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSinglePlayer.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnSinglePlayer.Size = new System.Drawing.Size(361, 140);
            this.btnSinglePlayer.TabIndex = 8;
            this.btnSinglePlayer.Text = "Single Player";
            this.btnSinglePlayer.TextColor = System.Drawing.Color.White;
            this.btnSinglePlayer.UseVisualStyleBackColor = false;
            this.btnSinglePlayer.Click += new System.EventHandler(this.btnSinglePlayer_Click);
            // 
            // layoutHomeButtons
            // 
            this.layoutHomeButtons.ColumnCount = 1;
            this.layoutHomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutHomeButtons.Controls.Add(this.layoutLowerButtons, 0, 2);
            this.layoutHomeButtons.Controls.Add(this.pnlTitle, 0, 0);
            this.layoutHomeButtons.Controls.Add(this.layoutUpperButtons, 0, 1);
            this.layoutHomeButtons.Location = new System.Drawing.Point(0, -31);
            this.layoutHomeButtons.Name = "layoutHomeButtons";
            this.layoutHomeButtons.RowCount = 3;
            this.layoutHomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutHomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutHomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutHomeButtons.Size = new System.Drawing.Size(808, 558);
            this.layoutHomeButtons.TabIndex = 9;
            // 
            // layoutLowerButtons
            // 
            this.layoutLowerButtons.ColumnCount = 2;
            this.layoutLowerButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutLowerButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutLowerButtons.Controls.Add(this.btnHost, 0, 0);
            this.layoutLowerButtons.Controls.Add(this.btnJoin, 1, 0);
            this.layoutLowerButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutLowerButtons.Location = new System.Drawing.Point(3, 375);
            this.layoutLowerButtons.Name = "layoutLowerButtons";
            this.layoutLowerButtons.RowCount = 1;
            this.layoutLowerButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutLowerButtons.Size = new System.Drawing.Size(802, 180);
            this.layoutLowerButtons.TabIndex = 2;
            // 
            // btnHost
            // 
            this.btnHost.BackColor = System.Drawing.Color.Transparent;
            this.btnHost.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.btnHost.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnHost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHost.FlatAppearance.BorderSize = 0;
            this.btnHost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHost.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHost.Location = new System.Drawing.Point(20, 20);
            this.btnHost.Margin = new System.Windows.Forms.Padding(20);
            this.btnHost.Name = "btnHost";
            this.btnHost.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnHost.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHost.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnHost.Size = new System.Drawing.Size(361, 140);
            this.btnHost.TabIndex = 9;
            this.btnHost.Text = "Host Game";
            this.btnHost.TextColor = System.Drawing.Color.White;
            this.btnHost.UseVisualStyleBackColor = false;
            this.btnHost.Click += new System.EventHandler(this.btnHost_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.Transparent;
            this.btnJoin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.btnJoin.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnJoin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJoin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJoin.FlatAppearance.BorderSize = 0;
            this.btnJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoin.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoin.Location = new System.Drawing.Point(421, 20);
            this.btnJoin.Margin = new System.Windows.Forms.Padding(20);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnJoin.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnJoin.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnJoin.Size = new System.Drawing.Size(361, 140);
            this.btnJoin.TabIndex = 10;
            this.btnJoin.Text = "Join Game";
            this.btnJoin.TextColor = System.Drawing.Color.White;
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.AllowDrop = true;
            this.pnlTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Controls.Add(this.lblSubitle);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Location = new System.Drawing.Point(203, 8);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(402, 169);
            this.pnlTitle.TabIndex = 10;
            // 
            // layoutUpperButtons
            // 
            this.layoutUpperButtons.ColumnCount = 2;
            this.layoutUpperButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutUpperButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutUpperButtons.Controls.Add(this.btnSettings, 1, 0);
            this.layoutUpperButtons.Controls.Add(this.btnSinglePlayer, 0, 0);
            this.layoutUpperButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutUpperButtons.Location = new System.Drawing.Point(3, 189);
            this.layoutUpperButtons.Name = "layoutUpperButtons";
            this.layoutUpperButtons.RowCount = 1;
            this.layoutUpperButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutUpperButtons.Size = new System.Drawing.Size(802, 180);
            this.layoutUpperButtons.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.btnSettings.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(421, 20);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(20);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnSettings.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSettings.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnSettings.Size = new System.Drawing.Size(361, 140);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextColor = System.Drawing.Color.White;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlSelection
            // 
            this.pnlSelection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSelection.BackColor = System.Drawing.Color.Transparent;
            this.pnlSelection.Controls.Add(this.layoutHomeButtons);
            this.pnlSelection.Location = new System.Drawing.Point(235, 12);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(808, 527);
            this.pnlSelection.TabIndex = 11;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Hexagonal_Chess.Properties.Resources.Home;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1219, 665);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHome";
            this.Load += new System.EventHandler(this.Home_Load);
            this.layoutHomeButtons.ResumeLayout(false);
            this.layoutLowerButtons.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.layoutUpperButtons.ResumeLayout(false);
            this.pnlSelection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubitle;
        private CustomButton btnSinglePlayer;
        private System.Windows.Forms.TableLayoutPanel layoutHomeButtons;
        private CustomButton btnSettings;
        private CustomButton btnJoin;
        private CustomButton btnHost;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.TableLayoutPanel layoutLowerButtons;
        private System.Windows.Forms.TableLayoutPanel layoutUpperButtons;
        private System.Windows.Forms.Panel pnlSelection;
    }
}

