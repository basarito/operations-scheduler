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
        public OperacijaForma OperacijaForma { get; set; }

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

        }

        private void btnOpenNewOperation_Click(object sender, EventArgs e)
        {
            OperacijaForma = new OperacijaForma();
            OperacijaForma.ShowDialog();
        }
    }
}
