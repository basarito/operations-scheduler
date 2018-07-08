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
        bool isBtnDetailsEnabled = false;

        public ListBox ListSearchResults
        {
            get { return listSearchResults; }
            set { listSearchResults = value; }
        }

        public PocetnaTimForma()
        {
            InitializeComponent();
            PocetnaForma.ApplyDisabledStyle(btnDetails);
            isBtnDetailsEnabled = false;
        }

        private void btnOpenNewTeam_Click(object sender, EventArgs e)
        {
            KontrolerKI.OtvoriTimFormu(); 
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
            string kriterijum = txtSearch.Text.Trim();
            if (String.IsNullOrWhiteSpace(kriterijum))
            {
                MessageBox.Show("Molimo unesite kriterijum pretrage!", "Neispravno polje");
                listSearchResults.DataSource = null;
                PocetnaForma.ApplyDisabledStyle(btnDetails);
                isBtnDetailsEnabled = false;
                return;
            }
            KontrolerKI.PronadjiTimove(kriterijum);
            this.Cursor = Cursors.WaitCursor;
        }

        public void PrikaziRezultatePretrage(int count)
        {
            if (count > 0)
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
                KontrolerKI.OpenTimPrikazFormu(listSearchResults.SelectedItem);
            }
        }
    }
}
