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
    public partial class PocetnaOperacijaForma : Form
    {
        bool isDetailsEnabled = false;
        public DataGridView DgvSearchResult { get { return dgvSearchResult; } }

        public PocetnaOperacijaForma()
        {
            InitializeComponent(); 
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if(isDetailsEnabled)
            {
                KontrolerKI.PrikaziDetaljeOperacije(dgvSearchResult.SelectedRows[0].DataBoundItem);
            }
        }

        private void btnOpenNewOperation_Click(object sender, EventArgs e)
        {
            KontrolerKI.OpenOperacijaFormu();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime datum = datePickerDatum.Value;
            KontrolerKI.PretraziOperacije(datum);
            this.Cursor = Cursors.WaitCursor;
        }

        private void PocetnaOperacijaForma_Load(object sender, EventArgs e)
        {
            PocetnaForma.ApplyDisabledStyle(btnDetails);

        }

        private void PostaviDGView()
        {
            dgvSearchResult.Columns["OperacijaID"].Visible = false;
            dgvSearchResult.Columns["SalaID"].Visible = false;
            dgvSearchResult.Columns["TimID"].Visible = false;
            dgvSearchResult.Columns["IzvestajOpis"].Visible = false;
            dgvSearchResult.Columns["IzvestajDatum"].Visible = false;
            dgvSearchResult.Columns["Tim"].Visible = false;
            dgvSearchResult.Columns["TerminOd"].Visible = false;
            dgvSearchResult.Columns["TerminDo"].Visible = false;
            dgvSearchResult.Columns["Sala"].DisplayIndex = 0;
            dgvSearchResult.Columns["TerminOdFormat"].DisplayIndex = 1;
            dgvSearchResult.Columns["TerminDoFormat"].DisplayIndex = 2;
            dgvSearchResult.Columns["Sala"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSearchResult.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSearchResult.MultiSelect = false;
            if(dgvSearchResult.Rows.Count > 0)
            {
                dgvSearchResult.Rows[0].Selected = true;
            }
        }

        internal void NoResultDgv()
        {
                isDetailsEnabled = false;
                PocetnaForma.ApplyDisabledStyle(btnDetails);
        }

        internal void PrikaziRezultatPretrage()
        {
            PostaviDGView();
            isDetailsEnabled = true;
            PocetnaForma.ApplyEnabledStyle(btnDetails);
            
        }
    }
}
