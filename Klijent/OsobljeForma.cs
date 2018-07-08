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
    public partial class OsobljeForma : Form
    {
        bool isBtnDetailsEnabled = false;
        public ListBox ListSearchResults
        {
            get { return listSearchResults; }
            set { listSearchResults = value; }
        }

        public OsobljeForma()
        {
            InitializeComponent();
            PocetnaForma.ApplyDisabledStyle(btnDetails);
            isBtnDetailsEnabled = false;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if(isBtnDetailsEnabled)
            {
                KontrolerKI.OpenOsobljePrikazFormu(listSearchResults.SelectedItem);
            } else
            {
                return;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OsobljeForma_Load(object sender, EventArgs e)
        {
            cbPozicija.DataSource = KontrolerKI.VratiListuPozicija();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string imePrezime = txtImePrezime.Text.Trim();
            string jmbg = txtJmbg.Text.Trim();
            var pozicija = cbPozicija.SelectedItem;

            if (!ValidateName(imePrezime))
            {
                MessageBox.Show("Neispravno popunjeno ime i prezime!", "Neispravno polje");
                return;
            }

            if (!ValidateJmbg(jmbg))
            {
                MessageBox.Show("Neispravno popunjen JMBG!", "Neispravno polje");
                return;
            }

            KontrolerKI.SacuvajOsoblje(imePrezime, jmbg, pozicija);
            this.Cursor = Cursors.WaitCursor;
        }

        public void PrikaziRezultatePretrage(int count)
        {
            if(count > 0)
            {
                PocetnaForma.ApplyEnabledStyle(btnDetails);
                isBtnDetailsEnabled = true;
            } else
            {
                PocetnaForma.ApplyDisabledStyle(btnDetails);
                isBtnDetailsEnabled = false;
            }
        }

        public void ResetForm()
        {
            txtImePrezime.Text = "";
            txtJmbg.Text = "";
        }

        private bool ValidateName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            if (name.Any(c => char.IsNumber(c)))
            {
                return false;
            }
            return true;
        }

        private bool ValidateJmbg(string jmbg)
        {
            if (String.IsNullOrWhiteSpace(jmbg))
            {
                return false;
            }
            if (jmbg.Any(c => !char.IsNumber(c)))
            {
                return false;
            }
            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kriterijum = txtSearch.Text.Trim();
            if (String.IsNullOrWhiteSpace(kriterijum))
            {
                MessageBox.Show("Molimo unesite kriterijum pretrage!", "Neispravno polje");
                listSearchResults.DataSource = null;
                PocetnaForma.ApplyDisabledStyle(btnDetails);
                isBtnDetailsEnabled = false;
                return;
            }
            KontrolerKI.PretraziOsoblje(kriterijum);
            this.Cursor = Cursors.WaitCursor;
        }

        private void listSearchResults_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }
    }
}
