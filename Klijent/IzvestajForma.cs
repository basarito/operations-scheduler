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
    public partial class IzvestajForma : Form
    {
        public IzvestajForma(string izvestaj, DateTime datum)
        {
            InitializeComponent();
            if(string.IsNullOrWhiteSpace(izvestaj))
            {
                NewIzvestajSetup();
            } else
            {
                ExistingIzvestajSetup(izvestaj, datum);
            }
        }

        private void ExistingIzvestajSetup(string izvestaj, DateTime datum)
        {
            string formattedDate = String.Format("{0:d. MMMM yyyy.}", datum);
            lblDate.Text = formattedDate;
            lblDate.Visible = true;
            lblTitleExisting.Visible = true;
            lblTitleNew.Visible = false;
            btnSave.Visible = false;
            Point p = new Point(147, 393);
            btnBack.Location = p;
            txtBoxIzvestaj.ReadOnly = true;
            txtBoxIzvestaj.Text = izvestaj;
        }

        private void NewIzvestajSetup()
        {
            //string formattedDate = String.Format("{0:d. MMMM yyyy.}", datum);
            //lblDate.Text = formattedDate;
            lblDate.Visible = false;
            lblTitleExisting.Visible = false;
            lblTitleNew.Visible = true;
            btnSave.Visible = true;
            Point p = new Point(24, 393);
            btnBack.Location = p;
            txtBoxIzvestaj.ReadOnly = false;
            //txtBoxIzvestaj.Text = izvestaj;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtBoxIzvestaj.Text))
            {
                MessageBox.Show("Molimo unesite izvestaj!");
                return;
            }
            KontrolerKI.SacuvajIzvestaj(txtBoxIzvestaj.Text);
        }

        //private void DisplayHtml(string html)
        //{
        //    webBrowser.Navigate("about:blank");

        //    if (webBrowser.Document != null)

        //    {
        //        webBrowser.Document.Write(string.Empty);
        //    }

        //    webBrowser.DocumentText = html;

        //}
    }
}
