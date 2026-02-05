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
            this.layoutFormButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new Hexagonal_Chess.CustomButton();
            this.btnClose = new Hexagonal_Chess.CustomButton();
            this.pnlBotStrength = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxNodesValue = new System.Windows.Forms.Label();
            this.lblExpensive = new System.Windows.Forms.Label();
            this.lblHard = new System.Windows.Forms.Label();
            this.lblMedium = new System.Windows.Forms.Label();
            this.lblEasy = new System.Windows.Forms.Label();
            this.trkMaxNodes = new Hexagonal_Chess.CustomSlider();
            this.lblMaxNodesTitle = new System.Windows.Forms.Label();
            this.chkEngineDebugMode = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.layoutVariationButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnHexofen = new Hexagonal_Chess.CustomButton();
            this.btnMcCooey = new Hexagonal_Chess.CustomButton();
            this.btnGlinksi = new Hexagonal_Chess.CustomButton();
            this.lblVariation = new System.Windows.Forms.Label();
            this.layoutSettings.SuspendLayout();
            this.layoutFormButtons.SuspendLayout();
            this.pnlBotStrength.SuspendLayout();
            this.layoutVariationButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutSettings
            // 
            this.layoutSettings.BackColor = System.Drawing.Color.Transparent;
            this.layoutSettings.ColumnCount = 1;
            this.layoutSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutSettings.Controls.Add(this.layoutFormButtons, 0, 4);
            this.layoutSettings.Controls.Add(this.pnlBotStrength, 0, 3);
            this.layoutSettings.Controls.Add(this.chkEngineDebugMode, 0, 2);
            this.layoutSettings.Controls.Add(this.lblTitle, 0, 0);
            this.layoutSettings.Controls.Add(this.layoutVariationButtons, 0, 1);
            this.layoutSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutSettings.Location = new System.Drawing.Point(0, 0);
            this.layoutSettings.Name = "layoutSettings";
            this.layoutSettings.RowCount = 5;
            this.layoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.layoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
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
            this.layoutFormButtons.Location = new System.Drawing.Point(3, 456);
            this.layoutFormButtons.Name = "layoutFormButtons";
            this.layoutFormButtons.RowCount = 1;
            this.layoutFormButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutFormButtons.Size = new System.Drawing.Size(794, 140);
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
            this.btnSave.Location = new System.Drawing.Point(418, 27);
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
            this.btnClose.Location = new System.Drawing.Point(21, 27);
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
            // pnlBotStrength
            // 
            this.pnlBotStrength.BackColor = System.Drawing.Color.Transparent;
            this.pnlBotStrength.Controls.Add(this.label1);
            this.pnlBotStrength.Controls.Add(this.lblMaxNodesValue);
            this.pnlBotStrength.Controls.Add(this.lblExpensive);
            this.pnlBotStrength.Controls.Add(this.lblHard);
            this.pnlBotStrength.Controls.Add(this.lblMedium);
            this.pnlBotStrength.Controls.Add(this.lblEasy);
            this.pnlBotStrength.Controls.Add(this.trkMaxNodes);
            this.pnlBotStrength.Controls.Add(this.lblMaxNodesTitle);
            this.pnlBotStrength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotStrength.Location = new System.Drawing.Point(3, 336);
            this.pnlBotStrength.Name = "pnlBotStrength";
            this.pnlBotStrength.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.pnlBotStrength.Size = new System.Drawing.Size(794, 114);
            this.pnlBotStrength.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(699, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Very Hard";
            // 
            // lblMaxNodesValue
            // 
            this.lblMaxNodesValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMaxNodesValue.AutoSize = true;
            this.lblMaxNodesValue.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxNodesValue.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxNodesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.lblMaxNodesValue.Location = new System.Drawing.Point(371, 83);
            this.lblMaxNodesValue.Name = "lblMaxNodesValue";
            this.lblMaxNodesValue.Size = new System.Drawing.Size(60, 26);
            this.lblMaxNodesValue.TabIndex = 6;
            this.lblMaxNodesValue.Text = "1500";
            this.lblMaxNodesValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpensive
            // 
            this.lblExpensive.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblExpensive.AutoSize = true;
            this.lblExpensive.BackColor = System.Drawing.Color.Transparent;
            this.lblExpensive.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpensive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.lblExpensive.Location = new System.Drawing.Point(298, 20);
            this.lblExpensive.Name = "lblExpensive";
            this.lblExpensive.Size = new System.Drawing.Size(213, 17);
            this.lblExpensive.TabIndex = 5;
            this.lblExpensive.Text = "More computationally expensive ➔\r\n";
            // 
            // lblHard
            // 
            this.lblHard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHard.AutoSize = true;
            this.lblHard.BackColor = System.Drawing.Color.Transparent;
            this.lblHard.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.lblHard.Location = new System.Drawing.Point(534, 82);
            this.lblHard.Name = "lblHard";
            this.lblHard.Size = new System.Drawing.Size(42, 20);
            this.lblHard.TabIndex = 4;
            this.lblHard.Text = "Hard";
            // 
            // lblMedium
            // 
            this.lblMedium.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMedium.AutoSize = true;
            this.lblMedium.BackColor = System.Drawing.Color.Transparent;
            this.lblMedium.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedium.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.lblMedium.Location = new System.Drawing.Point(197, 82);
            this.lblMedium.Name = "lblMedium";
            this.lblMedium.Size = new System.Drawing.Size(66, 20);
            this.lblMedium.TabIndex = 3;
            this.lblMedium.Text = "Medium";
            // 
            // lblEasy
            // 
            this.lblEasy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEasy.AutoSize = true;
            this.lblEasy.BackColor = System.Drawing.Color.Transparent;
            this.lblEasy.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.lblEasy.Location = new System.Drawing.Point(33, 82);
            this.lblEasy.Name = "lblEasy";
            this.lblEasy.Size = new System.Drawing.Size(38, 20);
            this.lblEasy.TabIndex = 2;
            this.lblEasy.Text = "Easy";
            // 
            // trkMaxNodes
            // 
            this.trkMaxNodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkMaxNodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.trkMaxNodes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trkMaxNodes.Location = new System.Drawing.Point(37, 39);
            this.trkMaxNodes.Maximum = 5000;
            this.trkMaxNodes.Minimum = 100;
            this.trkMaxNodes.MinimumSize = new System.Drawing.Size(100, 36);
            this.trkMaxNodes.Name = "trkMaxNodes";
            this.trkMaxNodes.Size = new System.Drawing.Size(734, 40);
            this.trkMaxNodes.TabIndex = 1;
            this.trkMaxNodes.Value = 1500;
            this.trkMaxNodes.ValueChanged += new System.EventHandler(this.trkMaxNodes_ValueChanged);
            // 
            // lblMaxNodesTitle
            // 
            this.lblMaxNodesTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMaxNodesTitle.AutoSize = true;
            this.lblMaxNodesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxNodesTitle.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxNodesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.lblMaxNodesTitle.Location = new System.Drawing.Point(282, -6);
            this.lblMaxNodesTitle.Name = "lblMaxNodesTitle";
            this.lblMaxNodesTitle.Size = new System.Drawing.Size(256, 26);
            this.lblMaxNodesTitle.TabIndex = 0;
            this.lblMaxNodesTitle.Text = "Bot strength (max nodes)";
            this.lblMaxNodesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkEngineDebugMode
            // 
            this.chkEngineDebugMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkEngineDebugMode.AutoSize = true;
            this.chkEngineDebugMode.BackColor = System.Drawing.Color.Transparent;
            this.chkEngineDebugMode.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEngineDebugMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.chkEngineDebugMode.Location = new System.Drawing.Point(290, 296);
            this.chkEngineDebugMode.Name = "chkEngineDebugMode";
            this.chkEngineDebugMode.Size = new System.Drawing.Size(220, 29);
            this.chkEngineDebugMode.TabIndex = 7;
            this.chkEngineDebugMode.Text = "Engine Debug Mode";
            this.chkEngineDebugMode.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Sitka Text", 65.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(794, 144);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Settings";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.layoutVariationButtons.Location = new System.Drawing.Point(3, 147);
            this.layoutVariationButtons.Name = "layoutVariationButtons";
            this.layoutVariationButtons.RowCount = 2;
            this.layoutVariationButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.81159F));
            this.layoutVariationButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.18841F));
            this.layoutVariationButtons.Size = new System.Drawing.Size(794, 138);
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
            this.btnHexofen.Location = new System.Drawing.Point(551, 64);
            this.btnHexofen.Margin = new System.Windows.Forms.Padding(20);
            this.btnHexofen.Name = "btnHexofen";
            this.btnHexofen.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnHexofen.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHexofen.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnHexofen.Size = new System.Drawing.Size(223, 46);
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
            this.btnMcCooey.Location = new System.Drawing.Point(282, 64);
            this.btnMcCooey.Margin = new System.Windows.Forms.Padding(20);
            this.btnMcCooey.Name = "btnMcCooey";
            this.btnMcCooey.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnMcCooey.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMcCooey.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnMcCooey.Size = new System.Drawing.Size(229, 45);
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
            this.btnGlinksi.Location = new System.Drawing.Point(20, 62);
            this.btnGlinksi.Margin = new System.Windows.Forms.Padding(20);
            this.btnGlinksi.Name = "btnGlinksi";
            this.btnGlinksi.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnGlinksi.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGlinksi.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnGlinksi.Size = new System.Drawing.Size(222, 49);
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
            this.lblVariation.Location = new System.Drawing.Point(274, 0);
            this.lblVariation.Name = "lblVariation";
            this.lblVariation.Size = new System.Drawing.Size(245, 36);
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
            this.pnlBotStrength.ResumeLayout(false);
            this.pnlBotStrength.PerformLayout();
            this.layoutVariationButtons.ResumeLayout(false);
            this.layoutVariationButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel layoutSettings;
        private CustomButton btnSave;
        private CustomButton btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel layoutVariationButtons;
        private CustomButton btnHexofen;
        private CustomButton btnMcCooey;
        private CustomButton btnGlinksi;
        private System.Windows.Forms.Label lblVariation;
        private System.Windows.Forms.TableLayoutPanel layoutFormButtons;
        private System.Windows.Forms.CheckBox chkEngineDebugMode;
        private System.Windows.Forms.Panel pnlBotStrength;
        private Hexagonal_Chess.CustomSlider trkMaxNodes;
        private System.Windows.Forms.Label lblMaxNodesTitle;
        private System.Windows.Forms.Label lblMaxNodesValue;
        private System.Windows.Forms.Label lblEasy;
        private System.Windows.Forms.Label lblMedium;
        private System.Windows.Forms.Label lblHard;
        private System.Windows.Forms.Label lblExpensive;
        private System.Windows.Forms.Label label1;
    }
}