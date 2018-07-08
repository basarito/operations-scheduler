using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class PocetnaForma : Form
    {
        private bool isStartEnabled = true;
        private bool isEndEnabled = false;

        public OsobljeForma OsobljeForma { get; set; }
        public PocetnaTimForma PocetnaTimForma { get; set; }
        public PocetnaOperacijaForma PocetnaOperacijaForma { get; set; }

        public PocetnaForma()
        {
            KontrolerKI kontrolerKI = new KontrolerKI(this);
            InitializeComponent();
        }

        private void btnOpenOsoblje_Click(object sender, EventArgs e)
        {
            KontrolerKI.OpenOsobljeFormu();
        }

        private void btnOpenTim_Click(object sender, EventArgs e)
        {
            KontrolerKI.OpenPocetnuTimFormu();
        }

        private void btnBeginSession_Click(object sender, EventArgs e)
        {
            if (isStartEnabled)
            {
                if (!KontrolerKI.BeginSession())
                {
                    MessageBox.Show("Doslo je do greske pri povezivanju na server. Molimo pokusajte kasnije.");
                    return;
                }

                ShowControls();
                ApplyDisabledStyle(btnBeginSession);
                isStartEnabled = false;

                ApplyEnabledStyle(btnEndSession);
                isEndEnabled = true;

                lblStatus.Visible = false;
                lblStatusOK.Visible = true;
            }
            else
            {
                return;
            }

        }

        static public void ApplyEnabledStyle(Button btn)
        {
            btn.BackColor = System.Drawing.Color.MediumTurquoise;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            btn.ForeColor = System.Drawing.Color.DarkSlateGray;
        }

        static public void ApplyDisabledStyle(Button btn)
        {
            btn.BackColor = System.Drawing.Color.PaleTurquoise;
            btn.Cursor = System.Windows.Forms.Cursors.No;
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            btn.ForeColor = System.Drawing.Color.MediumTurquoise;
        }

        private void ShowControls()
        {
            groupOsoblje.Visible = true;
            groupTim.Visible = true;
            groupOperacija.Visible = true;
            btnOpenOsoblje.Visible = true;
            btnOpenTim.Visible = true;
            btnOpenOperacije.Visible = true;
        }

        private void HideControls()
        {
            groupOsoblje.Visible = false;
            groupTim.Visible = false;
            groupOperacija.Visible = false;
            btnOpenOsoblje.Visible = false;
            btnOpenTim.Visible = false;
            btnOpenOperacije.Visible = false;
        }

        private void btnEndSession_Click(object sender, EventArgs e)
        {
            if (isEndEnabled)
            {
                if (!KontrolerKI.EndSession())
                {
                    MessageBox.Show("Doslo je do greske!" + KontrolerKI.ErrorMessage);
                    return;
                }
                EndSession();
            }
            else
            {
                return;
            }
        }

        public void EndSession()
        {
            HideControls();

            ApplyDisabledStyle(btnEndSession);
            isEndEnabled = false;

            ApplyEnabledStyle(btnBeginSession);
            isStartEnabled = true;

            lblStatus.Visible = true;
            lblStatusOK.Visible = false;
        }

        private void btnOpenOperacije_Click(object sender, EventArgs e)
        {
            KontrolerKI.OpenPocetnuOperacijaFormu();
        }

    }
}
