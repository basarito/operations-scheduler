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
        public Tim UcitanTim { get; set; }
        public PocetnaTimForma ParentForma { get; set; }

        public TimPrikazForma(Tim tim, PocetnaTimForma parentForm)
        {
            InitializeComponent();
            Komunikacija.Instance.UcitajTim(tim);
            PocetnaForma.ApplyDisabledStyle(btnBack);
            PocetnaForma.ApplyDisabledStyle(btnEdit);
            this.Cursor = Cursors.WaitCursor;
            ParentForma = parentForm;
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
            UcitanTim = tim;

            txtId.Text = tim.TimID.ToString();
            txtNaziv.Text = tim.NazivTima;
            dgvClanovi.DataSource = tim.ClanoviTima;
            dgvClanovi.Columns[0].Width = 80;
            dgvClanovi.ClearSelection();


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
            ParentForma.Invoke(new Action(
                () => {
                    ParentForma.TimForma = new TimForma(UcitanTim);
                    ParentForma.TimForma.ShowDialog();
                }
                ));
        }

        //internal void RefreshData(Tim izmenjenTim)
        //{
        //    txtNaziv.Text = izmenjenTim.NazivTima;
        //    dgvClanovi.DataSource = izmenjenTim.ClanoviTima;

        //}
    }
}
