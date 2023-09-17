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
            this.pnlIP = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new Hexagonal_Chess.CustomButton();
            this.btnConnect = new Hexagonal_Chess.CustomButton();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblGameMoves = new System.Windows.Forms.Label();
            this.layoutConnection.SuspendLayout();
            this.pnlIP.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutConnection
            // 
            this.layoutConnection.ColumnCount = 1;
            this.layoutConnection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutConnection.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.layoutConnection.Controls.Add(this.pnlIP, 0, 0);
            this.layoutConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutConnection.Location = new System.Drawing.Point(0, 0);
            this.layoutConnection.Name = "layoutConnection";
            this.layoutConnection.RowCount = 2;
            this.layoutConnection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutConnection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutConnection.Size = new System.Drawing.Size(800, 450);
            this.layoutConnection.TabIndex = 11;
            // 
            // pnlIP
            // 
            this.pnlIP.BackColor = System.Drawing.Color.Transparent;
            this.pnlIP.Controls.Add(this.lblGameMoves);
            this.pnlIP.Controls.Add(this.txtIP);
            this.pnlIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIP.Location = new System.Drawing.Point(3, 3);
            this.pnlIP.Name = "pnlIP";
            this.pnlIP.Size = new System.Drawing.Size(794, 219);
            this.pnlIP.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnConnect, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 228);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 219);
            this.tableLayoutPanel2.TabIndex = 5;
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
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F);
            this.txtIP.Location = new System.Drawing.Point(347, 76);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(287, 43);
            this.txtIP.TabIndex = 0;
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
            this.pnlIP.ResumeLayout(false);
            this.pnlIP.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel layoutConnection;
        private System.Windows.Forms.Panel pnlIP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CustomButton btnCancel;
        private CustomButton btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblGameMoves;
    }
}