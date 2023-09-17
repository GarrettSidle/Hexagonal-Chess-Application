namespace Hexagonal_Chess
{
    partial class FrmSettings
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
            this.layoutSettings = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new Hexagonal_Chess.CustomButton();
            this.btnClose = new Hexagonal_Chess.CustomButton();
            this.lblGameWinner = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHexofen = new Hexagonal_Chess.CustomButton();
            this.btnMcCooey = new Hexagonal_Chess.CustomButton();
            this.btnGlinksi = new Hexagonal_Chess.CustomButton();
            this.label1 = new System.Windows.Forms.Label();
            this.customButton1 = new Hexagonal_Chess.CustomButton();
            this.layoutSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutSettings
            // 
            this.layoutSettings.BackColor = System.Drawing.Color.Transparent;
            this.layoutSettings.ColumnCount = 1;
            this.layoutSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutSettings.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.layoutSettings.Controls.Add(this.lblGameWinner, 0, 0);
            this.layoutSettings.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.layoutSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutSettings.Location = new System.Drawing.Point(0, 0);
            this.layoutSettings.Name = "layoutSettings";
            this.layoutSettings.RowCount = 3;
            this.layoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutSettings.Size = new System.Drawing.Size(800, 599);
            this.layoutSettings.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClose, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 401);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 195);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.btnSave.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(418, 55);
            this.btnSave.Margin = new System.Windows.Forms.Padding(20);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnSave.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnSave.Size = new System.Drawing.Size(355, 85);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.btnClose.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(21, 55);
            this.btnClose.Margin = new System.Windows.Forms.Padding(20);
            this.btnClose.Name = "btnClose";
            this.btnClose.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnClose.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnClose.Size = new System.Drawing.Size(355, 85);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblGameWinner
            // 
            this.lblGameWinner.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            this.lblGameWinner.AutoSize = true;
            this.lblGameWinner.BackColor = System.Drawing.Color.Transparent;
            this.lblGameWinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGameWinner.Font = new System.Drawing.Font("Sitka Text", 65.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblGameWinner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.lblGameWinner.Location = new System.Drawing.Point(3, 0);
            this.lblGameWinner.Name = "lblGameWinner";
            this.lblGameWinner.Size = new System.Drawing.Size(794, 199);
            this.lblGameWinner.TabIndex = 4;
            this.lblGameWinner.Text = "Settings";
            this.lblGameWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Controls.Add(this.btnHexofen, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnMcCooey, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnGlinksi, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 202);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 193);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnHexofen
            // 
            this.btnHexofen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHexofen.BackColor = System.Drawing.Color.Transparent;
            this.btnHexofen.BorderColor = System.Drawing.Color.Silver;
            this.btnHexofen.ButtonColor = System.Drawing.Color.Gray;
            this.btnHexofen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHexofen.FlatAppearance.BorderSize = 0;
            this.btnHexofen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHexofen.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHexofen.Location = new System.Drawing.Point(551, 116);
            this.btnHexofen.Margin = new System.Windows.Forms.Padding(20);
            this.btnHexofen.Name = "btnHexofen";
            this.btnHexofen.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnHexofen.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHexofen.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnHexofen.Size = new System.Drawing.Size(223, 57);
            this.btnHexofen.TabIndex = 14;
            this.btnHexofen.Text = "Hexofen";
            this.btnHexofen.TextColor = System.Drawing.Color.White;
            this.btnHexofen.UseVisualStyleBackColor = false;
            this.btnHexofen.Click += new System.EventHandler(this.btnHexofen_Click);
            // 
            // btnMcCooey
            // 
            this.btnMcCooey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMcCooey.BackColor = System.Drawing.Color.Transparent;
            this.btnMcCooey.BorderColor = System.Drawing.Color.Silver;
            this.btnMcCooey.ButtonColor = System.Drawing.Color.Gray;
            this.btnMcCooey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMcCooey.FlatAppearance.BorderSize = 0;
            this.btnMcCooey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMcCooey.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMcCooey.Location = new System.Drawing.Point(282, 116);
            this.btnMcCooey.Margin = new System.Windows.Forms.Padding(20);
            this.btnMcCooey.Name = "btnMcCooey";
            this.btnMcCooey.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnMcCooey.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMcCooey.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnMcCooey.Size = new System.Drawing.Size(229, 57);
            this.btnMcCooey.TabIndex = 13;
            this.btnMcCooey.Text = " McCooey\'s";
            this.btnMcCooey.TextColor = System.Drawing.Color.White;
            this.btnMcCooey.UseVisualStyleBackColor = false;
            this.btnMcCooey.Click += new System.EventHandler(this.btnMcCooey_Click);
            // 
            // btnGlinksi
            // 
            this.btnGlinksi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGlinksi.BackColor = System.Drawing.Color.Transparent;
            this.btnGlinksi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.btnGlinksi.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnGlinksi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGlinksi.FlatAppearance.BorderSize = 0;
            this.btnGlinksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGlinksi.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGlinksi.Location = new System.Drawing.Point(20, 116);
            this.btnGlinksi.Margin = new System.Windows.Forms.Padding(20);
            this.btnGlinksi.Name = "btnGlinksi";
            this.btnGlinksi.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnGlinksi.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGlinksi.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnGlinksi.Size = new System.Drawing.Size(222, 57);
            this.btnGlinksi.TabIndex = 12;
            this.btnGlinksi.Text = "Gliński\'s";
            this.btnGlinksi.TextColor = System.Drawing.SystemColors.Window;
            this.btnGlinksi.UseVisualStyleBackColor = false;
            this.btnGlinksi.Click += new System.EventHandler(this.btnGlinksi_Click);
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(274, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Chess Variation";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customButton1
            // 
            this.customButton1.BorderColor = System.Drawing.Color.Silver;
            this.customButton1.ButtonColor = System.Drawing.Color.Red;
            this.customButton1.Location = new System.Drawing.Point(452, 312);
            this.customButton1.Name = "customButton1";
            this.customButton1.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.customButton1.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.customButton1.OnHoverTextColor = System.Drawing.Color.Gray;
            this.customButton1.Size = new System.Drawing.Size(8, 8);
            this.customButton1.TabIndex = 0;
            this.customButton1.Text = "customButton1";
            this.customButton1.TextColor = System.Drawing.Color.White;
            this.customButton1.UseVisualStyleBackColor = true;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = global::Hexagonal_Chess.Properties.Resources.Settings;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 599);
            this.ControlBox = false;
            this.Controls.Add(this.layoutSettings);
            this.Controls.Add(this.customButton1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.layoutSettings.ResumeLayout(false);
            this.layoutSettings.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton customButton1;
        private System.Windows.Forms.TableLayoutPanel layoutSettings;
        private CustomButton btnSave;
        private CustomButton btnClose;
        private System.Windows.Forms.Label lblGameWinner;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomButton btnHexofen;
        private CustomButton btnMcCooey;
        private CustomButton btnGlinksi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}