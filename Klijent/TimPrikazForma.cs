using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;

namespace Klijent
{
    public partial class TimPrikazForma : Form
    {
        public TimPrikazForma(Tim tim)
        {
            InitializeComponent();
            Komunikacija.Instance.UcitajTim(tim);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        internal void ShowResponse(TransferKlasa odgovor)
        {
            if(odgovor.Signal)
            {
                MessageBox.Show(odgovor.Poruka, "Uspesno!");
            } else
            {
                MessageBox.Show(odgovor.Poruka, "Doslo je do greske!");
                this.Dispose();
            }
        }

        internal void PopulateForm(Tim tim)
        {
            txtId.Text = tim.TimID.ToString();
            txtNaziv.Text = tim.NazivTima;
            dgvClanovi.DataSource = tim.ClanoviTima;
        }
    }
}
