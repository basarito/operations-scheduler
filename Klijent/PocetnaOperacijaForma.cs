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
        BindingList<Operacija> searchResults = new BindingList<Operacija>();
        public OperacijaPrikazForma OperacijaPrikazForma { get; set; }
        public PocetnaForma ParentForma { get; set; }

        public OperacijaForma OperacijaForma { get; set; }

        public PocetnaOperacijaForma(PocetnaForma pf)
        {
            InitializeComponent();
            ParentForma = pf;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if(isDetailsEnabled)
            {
                Operacija o = (Operacija)dgvSearchResult.SelectedRows[0].DataBoundItem;
                OperacijaPrikazForma = new OperacijaPrikazForma(o, this);
                OperacijaPrikazForma.ShowDialog();
            }
        }

        private void btnOpenNewOperation_Click(object sender, EventArgs e)
        {
            OperacijaForma = new OperacijaForma();
            OperacijaForma.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime datum = datePickerDatum.Value;
            Operacija op = new Operacija()
            {
                TerminOd = datum
            };
            Komunikacija.Instance.PretragaOperacija(op);
            this.Cursor = Cursors.WaitCursor;
        }

        private void PocetnaOperacijaForma_Load(object sender, EventArgs e)
        {
            PocetnaForma.ApplyDisabledStyle(btnDetails);
            dgvSearchResult.DataSource = searchResults;
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
        }

        internal void ShowResponse(TransferKlasa odgovor)
        {
            MessageBox.Show(odgovor.Poruka);
            this.Cursor = Cursors.Arrow;
            if(!odgovor.Signal)
            {
                searchResults.Clear();
                isDetailsEnabled = false;
                PocetnaForma.ApplyDisabledStyle(btnDetails);
            }
        }

        internal void PrikaziRezultatPretrage(List<Operacija> transferObjekat)
        {
            searchResults.Clear();
            transferObjekat.ForEach(o => searchResults.Add(o));
            isDetailsEnabled = true;
            PocetnaForma.ApplyEnabledStyle(btnDetails);
        }
    }
}
