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
    public partial class OsobljePrikazForma : Form
    {
        public OsobljePrikazForma(object o)
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            KontrolerKI.PrikaziDetaljeOsoblja(o);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        internal void PopunuFormu(string id, string imePrezime, string jmbg, string pozicija)
        {
            txtId.Text = id;
            txtImePrezime.Text = imePrezime;
            txtJmbg.Text = jmbg;
            txtPozicija.Text = pozicija;
        }
    }
}
