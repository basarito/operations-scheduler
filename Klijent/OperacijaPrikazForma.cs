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
        bool isStateEnabled = false;
        public int TimID { get; set; }

        public OperacijaPrikazForma(Object o)
        {
            InitializeComponent();
            KontrolerKI.UcitajOperaciju(o);
            this.Cursor = Cursors.WaitCursor;
        }

        private void GoBack()
        {
            //if (TimPrikazForma != null)
            //{
            //    TimPrikazForma.Dispose();
            //}
            this.Dispose();
        }

        private void btnOpenTim_Click(object sender, EventArgs e)
        {
            if(isStateEnabled)
            {
                KontrolerKI.OpenTimPrikazFormu(TimID);
            }
        }

        private void btnIzvestaj_Click(object sender, EventArgs e)
        {
            if(txtStatus.Text != Status.Odrzana.ToString())
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

        internal void PopulateForm(string id, string nazivSale, int sprat, string terminOdFormat,
            string terminDoFormat, string status)
        {
            txtId.Text = id;
            txtSala.Text = nazivSale;
            txtSprat.Text = $"{sprat}. sprat";
            txtTerminOd.Text = terminOdFormat;
            txtTerminDo.Text = terminDoFormat;
            txtStatus.Text = status;
            this.Cursor = Cursors.Arrow;
            isStateEnabled = true;
        }
    }
}
