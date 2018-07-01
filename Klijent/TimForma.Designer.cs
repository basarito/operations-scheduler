namespace Klijent
{
    partial class TimForma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimForma));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNazivTima = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkListStazisti = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkListAnesteziolozi = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkListSestre = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkListHirurzi = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOdgovornoLice = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Naziv tima";
            // 
            // txtNazivTima
            // 
            this.txtNazivTima.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNazivTima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtNazivTima.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtNazivTima.Location = new System.Drawing.Point(12, 30);
            this.txtNazivTima.Name = "txtNazivTima";
            this.txtNazivTima.Size = new System.Drawing.Size(397, 22);
            this.txtNazivTima.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkListStazisti);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkListAnesteziolozi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.checkListSestre);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkListHirurzi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 292);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Članovi tima";
            // 
            // checkListStazisti
            // 
            this.checkListStazisti.CheckOnClick = true;
            this.checkListStazisti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkListStazisti.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkListStazisti.FormattingEnabled = true;
            this.checkListStazisti.Location = new System.Drawing.Point(208, 39);
            this.checkListStazisti.Name = "checkListStazisti";
            this.checkListStazisti.Size = new System.Drawing.Size(177, 100);
            this.checkListStazisti.TabIndex = 15;
            this.checkListStazisti.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListBox_ItemCheck);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(205, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Anesteziolozi";
            // 
            // checkListAnesteziolozi
            // 
            this.checkListAnesteziolozi.CheckOnClick = true;
            this.checkListAnesteziolozi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkListAnesteziolozi.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkListAnesteziolozi.FormattingEnabled = true;
            this.checkListAnesteziolozi.Location = new System.Drawing.Point(208, 172);
            this.checkListAnesteziolozi.Name = "checkListAnesteziolozi";
            this.checkListAnesteziolozi.Size = new System.Drawing.Size(177, 100);
            this.checkListAnesteziolozi.TabIndex = 13;
            this.checkListAnesteziolozi.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListBox_ItemCheck);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(8, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sestre";
            // 
            // checkListSestre
            // 
            this.checkListSestre.CheckOnClick = true;
            this.checkListSestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkListSestre.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkListSestre.FormattingEnabled = true;
            this.checkListSestre.Location = new System.Drawing.Point(11, 172);
            this.checkListSestre.Name = "checkListSestre";
            this.checkListSestre.Size = new System.Drawing.Size(177, 100);
            this.checkListSestre.TabIndex = 11;
            this.checkListSestre.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListBox_ItemCheck);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(205, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stažisti";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Hirurzi";
            // 
            // checkListHirurzi
            // 
            this.checkListHirurzi.CheckOnClick = true;
            this.checkListHirurzi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkListHirurzi.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkListHirurzi.FormattingEnabled = true;
            this.checkListHirurzi.Location = new System.Drawing.Point(11, 39);
            this.checkListHirurzi.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.checkListHirurzi.Name = "checkListHirurzi";
            this.checkListHirurzi.Size = new System.Drawing.Size(177, 100);
            this.checkListHirurzi.Sorted = true;
            this.checkListHirurzi.TabIndex = 0;
            this.checkListHirurzi.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListBox_ItemCheck);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.Location = new System.Drawing.Point(270, 424);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(11, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Odgovorno lice";
            // 
            // cbOdgovornoLice
            // 
            this.cbOdgovornoLice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOdgovornoLice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbOdgovornoLice.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cbOdgovornoLice.FormattingEnabled = true;
            this.cbOdgovornoLice.Location = new System.Drawing.Point(14, 382);
            this.cbOdgovornoLice.Name = "cbOdgovornoLice";
            this.cbOdgovornoLice.Size = new System.Drawing.Size(395, 24);
            this.cbOdgovornoLice.TabIndex = 4;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnBack.Location = new System.Drawing.Point(12, 424);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(139, 30);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Nazad";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // TimForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(422, 466);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbOdgovornoLice);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNazivTima);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimForma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Novi tim";
            this.Load += new System.EventHandler(this.TimForma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNazivTima;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOdgovornoLice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox checkListAnesteziolozi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox checkListSestre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkListHirurzi;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.CheckedListBox checkListStazisti;
    }
}