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
        public OsobljePrikazForma(Osoblje o)
        {
            InitializeComponent();
            if(o != null)
            {
                txtId.Text = o.OsobljeID.ToString();
                txtImePrezime.Text = o.ImePrezime;
                txtJmbg.Text = o.Jmbg;
                txtPozicija.Text = o.Pozicija.ToString();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
