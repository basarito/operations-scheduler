namespace Klijent
{
    partial class OperacijaForma
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperacijaForma));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datePickerTerminDoVreme = new System.Windows.Forms.DateTimePicker();
            this.datePickerTerminOdVreme = new System.Windows.Forms.DateTimePicker();
            this.cbSale = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datePickerTerminDoDatum = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickerTerminOdDatum = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvTimovi = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimovi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datePickerTerminDoVreme);
            this.groupBox1.Controls.Add(this.datePickerTerminOdVreme);
            this.groupBox1.Controls.Add(this.cbSale);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.datePickerTerminDoDatum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.datePickerTerminOdDatum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalji operacije";
            // 
            // datePickerTerminDoVreme
            // 
            this.datePickerTerminDoVreme.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.datePickerTerminDoVreme.CalendarTitleBackColor = System.Drawing.Color.MediumTurquoise;
            this.datePickerTerminDoVreme.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.datePickerTerminDoVreme.CalendarTrailingForeColor = System.Drawing.Color.IndianRed;
            this.datePickerTerminDoVreme.CustomFormat = "HH:mm";
            this.datePickerTerminDoVreme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datePickerTerminDoVreme.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerTerminDoVreme.Location = new System.Drawing.Point(284, 130);
            this.datePickerTerminDoVreme.Name = "datePickerTerminDoVreme";
            this.datePickerTerminDoVreme.ShowUpDown = true;
            this.datePickerTerminDoVreme.Size = new System.Drawing.Size(124, 22);
            this.datePickerTerminDoVreme.TabIndex = 19;
            // 
            // datePickerTerminOdVreme
            // 
            this.datePickerTerminOdVreme.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.datePickerTerminOdVreme.CalendarTitleBackColor = System.Drawing.Color.MediumTurquoise;
            this.datePickerTerminOdVreme.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.datePickerTerminOdVreme.CalendarTrailingForeColor = System.Drawing.Color.IndianRed;
            this.datePickerTerminOdVreme.CustomFormat = "HH:mm";
            this.datePickerTerminOdVreme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datePickerTerminOdVreme.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerTerminOdVreme.Location = new System.Drawing.Point(284, 85);
            this.datePickerTerminOdVreme.Name = "datePickerTerminOdVreme";
            this.datePickerTerminOdVreme.ShowUpDown = true;
            this.datePickerTerminOdVreme.Size = new System.Drawing.Size(124, 22);
            this.datePickerTerminOdVreme.TabIndex = 18;
            // 
            // cbSale
            // 
            this.cbSale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbSale.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cbSale.FormattingEnabled = true;
            this.cbSale.Location = new System.Drawing.Point(16, 38);
            this.cbSale.Name = "cbSale";
            this.cbSale.Size = new System.Drawing.Size(392, 24);
            this.cbSale.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(13, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Termin do";
            // 
            // datePickerTerminDoDatum
            // 
            this.datePickerTerminDoDatum.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.datePickerTerminDoDatum.CalendarTitleBackColor = System.Drawing.Color.MediumTurquoise;
            this.datePickerTerminDoDatum.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.datePickerTerminDoDatum.CalendarTrailingForeColor = System.Drawing.Color.IndianRed;
            this.datePickerTerminDoDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datePickerTerminDoDatum.Location = new System.Drawing.Point(16, 130);
            this.datePickerTerminDoDatum.Name = "datePickerTerminDoDatum";
            this.datePickerTerminDoDatum.Size = new System.Drawing.Size(244, 22);
            this.datePickerTerminDoDatum.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Termin od";
            // 
            // datePickerTerminOdDatum
            // 
            this.datePickerTerminOdDatum.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.datePickerTerminOdDatum.CalendarTitleBackColor = System.Drawing.Color.MediumTurquoise;
            this.datePickerTerminOdDatum.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.datePickerTerminOdDatum.CalendarTrailingForeColor = System.Drawing.Color.IndianRed;
            this.datePickerTerminOdDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datePickerTerminOdDatum.Location = new System.Drawing.Point(16, 85);
            this.datePickerTerminOdDatum.Name = "datePickerTerminOdDatum";
            this.datePickerTerminOdDatum.Size = new System.Drawing.Size(244, 22);
            this.datePickerTerminOdDatum.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(13, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sala";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTimovi);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox2.Location = new System.Drawing.Point(12, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 292);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operativni tim";
            // 
            // dgvTimovi
            // 
            this.dgvTimovi.AllowUserToAddRows = false;
            this.dgvTimovi.AllowUserToDeleteRows = false;
            this.dgvTimovi.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.dgvTimovi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTimovi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimovi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvTimovi.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimovi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTimovi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTimovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTimovi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTimovi.EnableHeadersVisualStyles = false;
            this.dgvTimovi.GridColor = System.Drawing.Color.CadetBlue;
            this.dgvTimovi.Location = new System.Drawing.Point(16, 23);
            this.dgvTimovi.Name = "dgvTimovi";
            this.dgvTimovi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTimovi.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.dgvTimovi.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTimovi.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvTimovi.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dgvTimovi.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.dgvTimovi.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            this.dgvTimovi.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            this.dgvTimovi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTimovi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimovi.Size = new System.Drawing.Size(392, 255);
            this.dgvTimovi.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnBack.Location = new System.Drawing.Point(12, 488);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(139, 30);
            this.btnBack.TabIndex = 18;
            this.btnBack.Text = "Nazad";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.Location = new System.Drawing.Point(296, 488);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 30);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Zakaži";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // OperacijaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(447, 530);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OperacijaForma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zakazivanje operacije";
            this.Load += new System.EventHandler(this.OperacijaForma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimovi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePickerTerminDoDatum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerTerminOdDatum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvTimovi;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbSale;
        private System.Windows.Forms.DateTimePicker datePickerTerminDoVreme;
        private System.Windows.Forms.DateTimePicker datePickerTerminOdVreme;
    }
}