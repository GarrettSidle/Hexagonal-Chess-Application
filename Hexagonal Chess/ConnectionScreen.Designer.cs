namespace Hexagonal_Chess
{
    partial class FrmConnection
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
            this.layoutConnection = new System.Windows.Forms.TableLayoutPanel();
            this.layoutButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new Hexagonal_Chess.CustomButton();
            this.btnConnect = new Hexagonal_Chess.CustomButton();
            this.pnlIPAddress = new System.Windows.Forms.Panel();
            this.lblGameMoves = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.layoutConnection.SuspendLayout();
            this.layoutButtons.SuspendLayout();
            this.pnlIPAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutConnection
            // 
            this.layoutConnection.ColumnCount = 1;
            this.layoutConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutConnection.Controls.Add(this.layoutButtons, 0, 1);
            this.layoutConnection.Controls.Add(this.pnlIPAddress, 0, 0);
            this.layoutConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutConnection.Location = new System.Drawing.Point(0, 0);
            this.layoutConnection.Name = "layoutConnection";
            this.layoutConnection.RowCount = 2;
            this.layoutConnection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutConnection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutConnection.Size = new System.Drawing.Size(800, 450);
            this.layoutConnection.TabIndex = 11;
            // 
            // layoutButtons
            // 
            this.layoutButtons.ColumnCount = 2;
            this.layoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutButtons.Controls.Add(this.btnCancel, 0, 0);
            this.layoutButtons.Controls.Add(this.btnConnect, 1, 0);
            this.layoutButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutButtons.Location = new System.Drawing.Point(3, 228);
            this.layoutButtons.Name = "layoutButtons";
            this.layoutButtons.RowCount = 1;
            this.layoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutButtons.Size = new System.Drawing.Size(794, 219);
            this.layoutButtons.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.btnCancel.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(20, 20);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnCancel.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnCancel.Size = new System.Drawing.Size(357, 179);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Transparent;
            this.btnConnect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(133)))), ((int)(((byte)(64)))));
            this.btnConnect.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(171)))), ((int)(((byte)(95)))));
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(417, 20);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnConnect.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConnect.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnConnect.Size = new System.Drawing.Size(357, 179);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextColor = System.Drawing.Color.White;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pnlIPAddress
            // 
            this.pnlIPAddress.BackColor = System.Drawing.Color.Transparent;
            this.pnlIPAddress.Controls.Add(this.lblGameMoves);
            this.pnlIPAddress.Controls.Add(this.txtIP);
            this.pnlIPAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIPAddress.Location = new System.Drawing.Point(3, 3);
            this.pnlIPAddress.Name = "pnlIPAddress";
            this.pnlIPAddress.Size = new System.Drawing.Size(794, 219);
            this.pnlIPAddress.TabIndex = 0;
            // 
            // lblGameMoves
            // 
            this.lblGameMoves.AutoSize = true;
            this.lblGameMoves.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameMoves.Location = new System.Drawing.Point(174, 79);
            this.lblGameMoves.Name = "lblGameMoves";
            this.lblGameMoves.Size = new System.Drawing.Size(167, 35);
            this.lblGameMoves.TabIndex = 6;
            this.lblGameMoves.Text = "IP Address :";
            this.lblGameMoves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F);
            this.txtIP.Location = new System.Drawing.Point(347, 76);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(287, 43);
            this.txtIP.TabIndex = 0;
            // 
            // FrmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.layoutConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.layoutConnection.ResumeLayout(false);
            this.layoutButtons.ResumeLayout(false);
            this.pnlIPAddress.ResumeLayout(false);
            this.pnlIPAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel layoutConnection;
        private System.Windows.Forms.Panel pnlIPAddress;
        private System.Windows.Forms.TableLayoutPanel layoutButtons;
        private CustomButton btnCancel;
        private CustomButton btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblGameMoves;
    }
}