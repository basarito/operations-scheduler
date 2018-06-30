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
                Osoblje o = (Osoblje)listSearchResults.SelectedItem;
                Komunikacija.Instance.UcitajOsoblje(o);
                this.Cursor = Cursors.WaitCursor;
                PocetnaForma.ApplyDisabledStyle(btnDetails);
                isBtnDetailsEnabled = false;
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
            cbPozicija.DataSource = new List<Pozicija>()
            { Pozicija.Hirurg, Pozicija.Sestra, Pozicija.Stazista, Pozicija.Anesteziolog};
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string imePrezime = txtImePrezime.Text;
            string jmbg = txtJmbg.Text;
            Pozicija pozicija = (Pozicija)cbPozicija.SelectedItem;

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
            Osoblje o = new Osoblje()
            {
                ImePrezime = imePrezime,
                Jmbg = jmbg,
                Pozicija = pozicija
            };

            Komunikacija.Instance.DodajOsoblje(o);
        }

        delegate void HandleResponseDelegate(TransferKlasa tk);

        public void HandleResponse(TransferKlasa response)
        {
            Invoke(new HandleResponseDelegate(ShowMessageBox), response);
            
        }

        public void ShowMessageBox(TransferKlasa response)
        {
            if (response.Signal)
            {
                MessageBox.Show(response.Poruka, "Uspešno!");
                ResetForm();
            }
            else
            {
                MessageBox.Show(response.Poruka, "Došlo je do greške!");
            }
        }


        public void PrikaziRezultatePretragePoziv(TransferKlasa tk)
        {
            Invoke(new HandleResponseDelegate(PrikaziRezultatePretrage), tk);
        }
        public void PrikaziRezultatePretrage(TransferKlasa tk)
        {
            var lista = (IList<IOpstiDomenskiObjekat>)tk.TransferObjekat;
            List<Osoblje> lista2 = new List<Osoblje>();
            foreach (var odo in lista)
            {
                lista2.Add((Osoblje)odo);
            }
            listSearchResults.DataSource = lista2;
            if(lista2.Count > 0)
            {
                PocetnaForma.ApplyEnabledStyle(btnDetails);
                isBtnDetailsEnabled = true;
            } else
            {
                PocetnaForma.ApplyDisabledStyle(btnDetails);
                isBtnDetailsEnabled = false;
            }
        }

        public void PrikaziDetaljePoziv(TransferKlasa tk)
        {
            Invoke(new HandleResponseDelegate(UcitajOsoblje), tk);
        }

        public void UcitajOsoblje(TransferKlasa tk)
        {
            Osoblje o = (Osoblje)tk.TransferObjekat;            
            if(tk.Signal)
            {
                new OsobljePrikazForma(o).ShowDialog();             
            }
            this.Cursor = Cursors.Default;
            PocetnaForma.ApplyEnabledStyle(btnDetails);
            isBtnDetailsEnabled = true;
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
            string kriterijum = txtSearch.Text;
            if (String.IsNullOrWhiteSpace(kriterijum))
            {
                MessageBox.Show("Molimo unesite kriterijum pretrage!", "Neispravno polje");
                listSearchResults.DataSource = null;
                PocetnaForma.ApplyDisabledStyle(btnDetails);
                isBtnDetailsEnabled = false;
                return;
            }
            Osoblje o = new Osoblje()
            {
                ImePrezime = kriterijum,
                Jmbg = kriterijum
            };
            Komunikacija.Instance.PretragaOsoblja(o);
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
