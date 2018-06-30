namespace Klijent
{
    partial class PocetnaForma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PocetnaForma));
            this.btnBeginSession = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupOsoblje = new System.Windows.Forms.GroupBox();
            this.btnOpenOsoblje = new System.Windows.Forms.Button();
            this.groupTim = new System.Windows.Forms.GroupBox();
            this.btnOpenTim = new System.Windows.Forms.Button();
            this.groupOperacija = new System.Windows.Forms.GroupBox();
            this.btnOpenOperacije = new System.Windows.Forms.Button();
            this.btnEndSession = new System.Windows.Forms.Button();
            this.lblStatusOK = new System.Windows.Forms.Label();
            this.groupOsoblje.SuspendLayout();
            this.groupTim.SuspendLayout();
            this.groupOperacija.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBeginSession
            // 
            this.btnBeginSession.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnBeginSession.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBeginSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeginSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBeginSession.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnBeginSession.Location = new System.Drawing.Point(174, 54);
            this.btnBeginSession.Name = "btnBeginSession";
            this.btnBeginSession.Size = new System.Drawing.Size(200, 30);
            this.btnBeginSession.TabIndex = 0;
            this.btnBeginSession.Text = "Pristupi sistemu";
            this.btnBeginSession.UseVisualStyleBackColor = false;
            this.btnBeginSession.Click += new System.EventHandler(this.btnBeginSession_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblStatus.Location = new System.Drawing.Point(169, 22);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(213, 20);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Niste povezani na sistem.";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupOsoblje
            // 
            this.groupOsoblje.Controls.Add(this.btnOpenOsoblje);
            this.groupOsoblje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupOsoblje.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupOsoblje.Location = new System.Drawing.Point(19, 147);
            this.groupOsoblje.Name = "groupOsoblje";
            this.groupOsoblje.Size = new System.Drawing.Size(160, 161);
            this.groupOsoblje.TabIndex = 3;
            this.groupOsoblje.TabStop = false;
            this.groupOsoblje.Text = "Rad sa medicinskim osobljem";
            this.groupOsoblje.Visible = false;
            // 
            // btnOpenOsoblje
            // 
            this.btnOpenOsoblje.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpenOsoblje.BackgroundImage")));
            this.btnOpenOsoblje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpenOsoblje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenOsoblje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenOsoblje.ForeColor = System.Drawing.Color.White;
            this.btnOpenOsoblje.Location = new System.Drawing.Point(16, 24);
            this.btnOpenOsoblje.Name = "btnOpenOsoblje";
            this.btnOpenOsoblje.Size = new System.Drawing.Size(128, 128);
            this.btnOpenOsoblje.TabIndex = 2;
            this.btnOpenOsoblje.UseVisualStyleBackColor = true;
            this.btnOpenOsoblje.Visible = false;
            this.btnOpenOsoblje.Click += new System.EventHandler(this.btnOpenOsoblje_Click);
            // 
            // groupTim
            // 
            this.groupTim.Controls.Add(this.btnOpenTim);
            this.groupTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupTim.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupTim.Location = new System.Drawing.Point(194, 147);
            this.groupTim.Name = "groupTim";
            this.groupTim.Size = new System.Drawing.Size(160, 161);
            this.groupTim.TabIndex = 4;
            this.groupTim.TabStop = false;
            this.groupTim.Text = "Rad sa operativnim timovima";
            this.groupTim.Visible = false;
            // 
            // btnOpenTim
            // 
            this.btnOpenTim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpenTim.BackgroundImage")));
            this.btnOpenTim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpenTim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenTim.ForeColor = System.Drawing.Color.White;
            this.btnOpenTim.Location = new System.Drawing.Point(16, 24);
            this.btnOpenTim.Name = "btnOpenTim";
            this.btnOpenTim.Size = new System.Drawing.Size(128, 128);
            this.btnOpenTim.TabIndex = 1;
            this.btnOpenTim.UseVisualStyleBackColor = true;
            this.btnOpenTim.Visible = false;
            this.btnOpenTim.Click += new System.EventHandler(this.btnOpenTim_Click);
            // 
            // groupOperacija
            // 
            this.groupOperacija.Controls.Add(this.btnOpenOperacije);
            this.groupOperacija.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupOperacija.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupOperacija.Location = new System.Drawing.Point(373, 147);
            this.groupOperacija.Name = "groupOperacija";
            this.groupOperacija.Size = new System.Drawing.Size(160, 161);
            this.groupOperacija.TabIndex = 5;
            this.groupOperacija.TabStop = false;
            this.groupOperacija.Text = "Rad sa operacijama";
            this.groupOperacija.Visible = false;
            // 
            // btnOpenOperacije
            // 
            this.btnOpenOperacije.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpenOperacije.BackgroundImage")));
            this.btnOpenOperacije.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpenOperacije.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenOperacije.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenOperacije.ForeColor = System.Drawing.Color.White;
            this.btnOpenOperacije.Location = new System.Drawing.Point(16, 24);
            this.btnOpenOperacije.Name = "btnOpenOperacije";
            this.btnOpenOperacije.Size = new System.Drawing.Size(128, 128);
            this.btnOpenOperacije.TabIndex = 0;
            this.btnOpenOperacije.UseVisualStyleBackColor = true;
            this.btnOpenOperacije.Visible = false;
            this.btnOpenOperacije.Click += new System.EventHandler(this.btnOpenOperacije_Click);
            // 
            // btnEndSession
            // 
            this.btnEndSession.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnEndSession.Cursor = System.Windows.Forms.Cursors.No;
            this.btnEndSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEndSession.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btnEndSession.Location = new System.Drawing.Point(174, 90);
            this.btnEndSession.Name = "btnEndSession";
            this.btnEndSession.Size = new System.Drawing.Size(200, 30);
            this.btnEndSession.TabIndex = 6;
            this.btnEndSession.Text = "Kraj rada";
            this.btnEndSession.UseVisualStyleBackColor = false;
            this.btnEndSession.Click += new System.EventHandler(this.btnEndSession_Click);
            // 
            // lblStatusOK
            // 
            this.lblStatusOK.AutoSize = true;
            this.lblStatusOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatusOK.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblStatusOK.Location = new System.Drawing.Point(176, 22);
            this.lblStatusOK.Name = "lblStatusOK";
            this.lblStatusOK.Size = new System.Drawing.Size(198, 20);
            this.lblStatusOK.TabIndex = 7;
            this.lblStatusOK.Text = "Povezani ste na sistem.";
            this.lblStatusOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatusOK.Visible = false;
            // 
            // PocetnaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(550, 322);
            this.Controls.Add(this.lblStatusOK);
            this.Controls.Add(this.btnEndSession);
            this.Controls.Add(this.groupOperacija);
            this.Controls.Add(this.groupTim);
            this.Controls.Add(this.groupOsoblje);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnBeginSession);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PocetnaForma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dobrodošli";
            this.groupOsoblje.ResumeLayout(false);
            this.groupTim.ResumeLayout(false);
            this.groupOperacija.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBeginSession;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupOsoblje;
        private System.Windows.Forms.GroupBox groupTim;
        private System.Windows.Forms.GroupBox groupOperacija;
        private System.Windows.Forms.Button btnOpenOperacije;
        private System.Windows.Forms.Button btnEndSession;
        private System.Windows.Forms.Button btnOpenOsoblje;
        private System.Windows.Forms.Button btnOpenTim;
        private System.Windows.Forms.Label lblStatusOK;
    }
}

