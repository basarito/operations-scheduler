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
    public partial class PocetnaTimForma : Form
    {
        public TimForma TimForma { get; set; }
        public TimPrikazForma TimPrikazForma { get; set; }
        bool isBtnDetailsEnabled = false;

        public PocetnaTimForma()
        {
            InitializeComponent();
            PocetnaForma.ApplyDisabledStyle(btnDetails);
            isBtnDetailsEnabled = false;
        }

        private void btnOpenNewTeam_Click(object sender, EventArgs e)
        {
            TimForma = new TimForma();
            //Komunikacija.Instance.VratiSveOsoblje();
            TimForma.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kriterijum = txtSearch.Text;
            if (String.IsNullOrWhiteSpace(kriterijum))
            {
                MessageBox.Show("Molimo unesite kriterijum pretrage!", "Neispravno polje");
                listSearchResults.DataSource = null;
                PocetnaForma.ApplyDisabledStyle(btnDetails);
                isBtnDetailsEnabled = false;
                return;
            }
            Komunikacija.Instance.PronadjiTimove(kriterijum);
        }

        public void PrikaziRezultatePretrage(List<Tim> result)
        {
            listSearchResults.DataSource = result;
            if (result.Count > 0)
            {
                PocetnaForma.ApplyEnabledStyle(btnDetails);
                isBtnDetailsEnabled = true;
            }
            else
            {
                PocetnaForma.ApplyDisabledStyle(btnDetails);
                isBtnDetailsEnabled = false;
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if(isBtnDetailsEnabled)
            {
                TimPrikazForma = new TimPrikazForma((Tim)listSearchResults.SelectedItem, this);
                TimPrikazForma.ShowDialog();
            }
        }

        internal void ShowResponse(TransferKlasa odgovor)
        {
            MessageBox.Show(odgovor.Poruka);
            if(!odgovor.Signal)
            {
                //txtSearch.Clear();
                listSearchResults.DataSource = null;
                PocetnaForma.ApplyDisabledStyle(btnDetails);
                isBtnDetailsEnabled = false;
            }
        }
    }
}
