﻿namespace Hexagonal_Chess
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
            this.layoutFormButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new Hexagonal_Chess.CustomButton();
            this.btnClose = new Hexagonal_Chess.CustomButton();
            this.lblGameWinner = new System.Windows.Forms.Label();
            this.layoutVariationButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnHexofen = new Hexagonal_Chess.CustomButton();
            this.btnMcCooey = new Hexagonal_Chess.CustomButton();
            this.btnGlinksi = new Hexagonal_Chess.CustomButton();
            this.lblVariation = new System.Windows.Forms.Label();
            this.layoutSettings.SuspendLayout();
            this.layoutFormButtons.SuspendLayout();
            this.layoutVariationButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutSettings
            // 
            this.layoutSettings.BackColor = System.Drawing.Color.Transparent;
            this.layoutSettings.ColumnCount = 1;
            this.layoutSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutSettings.Controls.Add(this.layoutFormButtons, 0, 2);
            this.layoutSettings.Controls.Add(this.lblGameWinner, 0, 0);
            this.layoutSettings.Controls.Add(this.layoutVariationButtons, 0, 1);
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
            // layoutFormButtons
            // 
            this.layoutFormButtons.BackColor = System.Drawing.Color.Transparent;
            this.layoutFormButtons.ColumnCount = 2;
            this.layoutFormButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutFormButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutFormButtons.Controls.Add(this.btnSave, 1, 0);
            this.layoutFormButtons.Controls.Add(this.btnClose, 0, 0);
            this.layoutFormButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutFormButtons.Location = new System.Drawing.Point(3, 401);
            this.layoutFormButtons.Name = "layoutFormButtons";
            this.layoutFormButtons.RowCount = 1;
            this.layoutFormButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutFormButtons.Size = new System.Drawing.Size(794, 195);
            this.layoutFormButtons.TabIndex = 6;
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
            // layoutVariationButtons
            // 
            this.layoutVariationButtons.BackColor = System.Drawing.Color.Transparent;
            this.layoutVariationButtons.ColumnCount = 3;
            this.layoutVariationButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.layoutVariationButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.layoutVariationButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.layoutVariationButtons.Controls.Add(this.btnHexofen, 2, 1);
            this.layoutVariationButtons.Controls.Add(this.btnMcCooey, 1, 1);
            this.layoutVariationButtons.Controls.Add(this.btnGlinksi, 0, 1);
            this.layoutVariationButtons.Controls.Add(this.lblVariation, 1, 0);
            this.layoutVariationButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutVariationButtons.Location = new System.Drawing.Point(3, 202);
            this.layoutVariationButtons.Name = "layoutVariationButtons";
            this.layoutVariationButtons.RowCount = 2;
            this.layoutVariationButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutVariationButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutVariationButtons.Size = new System.Drawing.Size(794, 193);
            this.layoutVariationButtons.TabIndex = 5;
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
            // lblVariation
            // 
            this.lblVariation.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            this.lblVariation.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblVariation.AutoSize = true;
            this.lblVariation.BackColor = System.Drawing.Color.Transparent;
            this.lblVariation.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblVariation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.lblVariation.Location = new System.Drawing.Point(274, 57);
            this.lblVariation.Name = "lblVariation";
            this.lblVariation.Size = new System.Drawing.Size(245, 39);
            this.lblVariation.TabIndex = 6;
            this.lblVariation.Text = "Chess Variation";
            this.lblVariation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.layoutSettings.ResumeLayout(false);
            this.layoutSettings.PerformLayout();
            this.layoutFormButtons.ResumeLayout(false);
            this.layoutVariationButtons.ResumeLayout(false);
            this.layoutVariationButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel layoutSettings;
        private CustomButton btnSave;
        private CustomButton btnClose;
        private System.Windows.Forms.Label lblGameWinner;
        private System.Windows.Forms.TableLayoutPanel layoutVariationButtons;
        private CustomButton btnHexofen;
        private CustomButton btnMcCooey;
        private CustomButton btnGlinksi;
        private System.Windows.Forms.Label lblVariation;
        private System.Windows.Forms.TableLayoutPanel layoutFormButtons;
    }
}