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

        public PocetnaForma()
        {
            InitializeComponent();
        }

        private void btnOpenOsoblje_Click(object sender, EventArgs e)
        {
            OsobljeForma = new OsobljeForma();
            OsobljeForma.ShowDialog();
        }

        private void btnOpenTim_Click(object sender, EventArgs e)
        {
            PocetnaTimForma = new PocetnaTimForma();
            PocetnaTimForma.ShowDialog();
        }

        private void btnBeginSession_Click(object sender, EventArgs e)
        {
            if(isStartEnabled)
            {
                try
                {
                    Komunikacija.Instance.PoveziSe();
                    Komunikacija.Instance.OsluskujOdgovore(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške! \n" + ex.Message);
                    return;
                }

                ShowControls();
                ApplyDisabledStyle(btnBeginSession);
                isStartEnabled = false;

                ApplyEnabledStyle(btnEndSession);
                isEndEnabled = true;

                lblStatus.Visible = false;
                lblStatusOK.Visible = true;
            } else
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
           if(isEndEnabled)
            {
                try
                {
                    Komunikacija.Instance.Kraj();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške! \n" + ex.Message);
                    return;
                }

                EndSession();
                
            } else
            {
                return;
            }
        }

        public void EndSession()
        {
            if(Application.OpenForms.Count > 1)
            {
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (Application.OpenForms[i].Name != "PocetnaForma")
                        Application.OpenForms[i].Dispose();
                }
            }

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
            new PocetnaOperacijaForma().ShowDialog();
        }

        
    }
}
