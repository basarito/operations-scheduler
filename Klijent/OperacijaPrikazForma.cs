using Domen;
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
    public partial class OperacijaPrikazForma : Form
    {
        public Operacija UcitanaOperacija { get; set; }
        public PocetnaOperacijaForma ParentForma { get; set; }
        public TimPrikazForma TimPrikazForma { get; set; }

        bool isStateEnabled = false;

        public OperacijaPrikazForma(Operacija operacija, PocetnaOperacijaForma parentForm)
        {
            InitializeComponent();
            ParentForma = parentForm;
            Komunikacija.Instance.UcitajOperaciju(operacija);
            this.Cursor = Cursors.WaitCursor;
        }

        internal void ShowResponse(TransferKlasa odgovor)
        {
            if (odgovor.Signal)
            {
                MessageBox.Show(odgovor.Poruka, "Uspesno!");
            }
            else
            {
                MessageBox.Show(odgovor.Poruka, "Doslo je do greske!");
                GoBack();
            }
        }

        private void GoBack()
        {
            if (TimPrikazForma != null)
            {
                TimPrikazForma.Dispose();
            }
            this.Dispose();
        }

        internal void PopulateForm(Operacija o)
        {
            UcitanaOperacija = o;
            txtId.Text = UcitanaOperacija.OperacijaID.ToString();
            txtSala.Text = UcitanaOperacija.Sala.NazivSale;
            txtSprat.Text = $"{UcitanaOperacija.Sala.Sprat}. sprat";
            txtTerminOd.Text = UcitanaOperacija.TerminOdFormat;
            txtTerminDo.Text = UcitanaOperacija.TerminDoFormat;
            txtStatus.Text = UcitanaOperacija.Status.ToString();
            this.Cursor = Cursors.Arrow;
            isStateEnabled = true;
        }

        private void btnOpenTim_Click(object sender, EventArgs e)
        {
            if(isStateEnabled)
            {
                Tim tim = new Tim()
                {
                    TimID = UcitanaOperacija.TimID
                };
                TimPrikazForma = new TimPrikazForma(tim, new PocetnaTimForma());
                TimPrikazForma.ButtonEdit.Visible = false;
                TimPrikazForma.ShowDialog();
            }
        }

        private void btnIzvestaj_Click(object sender, EventArgs e)
        {
            if(UcitanaOperacija.Status != Status.Odrzana)
            {
                MessageBox.Show("Nije moguće uneti izveštaj za operaciju koja nije održana.");
                return;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(isStateEnabled)
            {
                GoBack();
            }
        }
    }
}
