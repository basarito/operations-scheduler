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
        public Object UcitanTim { get; set; }
        public Button ButtonEdit { get; set; }

        public DataGridView DgvClanovi
        {
            get { return dgvClanovi; }
            set { dgvClanovi = value; }
        }

        public TimPrikazForma(object o)
        {
            InitializeComponent();
            ButtonEdit = btnEdit;
            KontrolerKI.PrikaziDetaljeTima(o);
            PocetnaForma.ApplyDisabledStyle(btnEdit);
            this.Cursor = Cursors.WaitCursor;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        internal void PopunuFormu(string id, string naziv)
        {
            txtId.Text = id;
            txtNaziv.Text = naziv;

            PocetnaForma.ApplyEnabledStyle(btnBack);
            PocetnaForma.ApplyEnabledStyle(btnEdit);
            this.Cursor = Cursors.Arrow;
        }

        private void TimPrikazForma_Load(object sender, EventArgs e)
        {
            dgvClanovi.RowHeadersVisible = false;
        }

        private void dgvClanovi_SelectionChanged(Object sender, EventArgs e)
        {
            dgvClanovi.ClearSelection();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            KontrolerKI.OpenIzmenaTima(UcitanTim);
        }
    }
}
