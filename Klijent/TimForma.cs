using Domen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class TimForma : Form
    {
        public List<Osoblje> ListaOsoblja { get; set; }
        public BindingList<Osoblje> tim = new BindingList<Osoblje>();
        bool isEnabled = false;
 
        public TimForma()
        {
            
            InitializeComponent();          
            Komunikacija.Instance.VratiSveOsoblje();
        }

        private void TimForma_Load(object sender, EventArgs e)
        {
            SetControlEnable(false);
            //this.Enabled = false;
            //this.Cursor = Cursors.WaitCursor;
            cbOdgovornoLice.DataSource = tim;           
        }

        public void ResetForm()
        {           
            tim.Clear();
            txtNazivTima.Clear();
            checkListHirurzi.Items.Clear();
            checkListStazisti.Items.Clear();
            checkListSestre.Items.Clear();
            checkListAnesteziolozi.Items.Clear();
            PopulateListBoxes();
        }

        public void SetControlEnable(bool state)
        {
            isEnabled = state;
            txtNazivTima.Enabled = state;
            checkListHirurzi.Enabled = state;
            checkListStazisti.Enabled = state;
            checkListSestre.Enabled = state;
            checkListAnesteziolozi.Enabled = state;
            cbOdgovornoLice.Enabled = state;
            if(state)
            {
                PocetnaForma.ApplyEnabledStyle(btnSave);
                PocetnaForma.ApplyEnabledStyle(btnBack);
                this.Cursor = Cursors.Arrow;
            } else
            {
                PocetnaForma.ApplyDisabledStyle(btnSave);
                PocetnaForma.ApplyDisabledStyle(btnBack);
                this.Cursor = Cursors.WaitCursor;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(isEnabled)
            {
                this.Dispose();
            }
        }

        public void PopulateListBoxes()
        {
            foreach(Osoblje o in ListaOsoblja)
            {
                switch(o.Pozicija)
                {
                    case Pozicija.Hirurg:
                        checkListHirurzi.Items.Add(o);
                        break;
                    case Pozicija.Stazista:
                        checkListStazisti.Items.Add(o);
                        break;
                    case Pozicija.Sestra:
                        checkListSestre.Items.Add(o);
                        break;
                    case Pozicija.Anesteziolog:
                        checkListAnesteziolozi.Items.Add(o);
                        break;
                }
            }
            checkListHirurzi.DisplayMember = "ImePrezime";
            checkListStazisti.DisplayMember = "ImePrezime";
            checkListSestre.DisplayMember = "ImePrezime";
            checkListAnesteziolozi.DisplayMember = "ImePrezime";
            SetControlEnable(true);
            //this.Enabled = true;
            //this.Cursor = Cursors.Arrow;
        }

        public delegate void PopulateListDelegate(List<Osoblje> o);
        internal void PopulateList(List<Osoblje> o)
        {
            ListaOsoblja = o;
        }

        private void checkListHirurzi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            {
                tim.Add((Osoblje)checkListHirurzi.SelectedItem);
            } else if (e.NewValue == CheckState.Unchecked)
            {
                tim.Remove((Osoblje)checkListHirurzi.SelectedItem);
            }
        }

        private void checkListStazisti_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                tim.Add((Osoblje)checkListStazisti.SelectedItem);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                tim.Remove((Osoblje)checkListStazisti.SelectedItem);
            }
        }

        private void checkListSestre_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                tim.Add((Osoblje)checkListSestre.SelectedItem);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                tim.Remove((Osoblje)checkListSestre.SelectedItem);
            }
        }

        private void checkListAnesteziolozi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                tim.Add((Osoblje)checkListAnesteziolozi.SelectedItem);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                tim.Remove((Osoblje)checkListAnesteziolozi.SelectedItem);
            }
        }

        public void ShowResponse(TransferKlasa tk)
        {
            MessageBox.Show(tk.Poruka);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!isEnabled)
            {
                return;
            }
            if(String.IsNullOrWhiteSpace(txtNazivTima.Text))
            {
                MessageBox.Show("Molimo popunite naziv tima!", "Neispravan unos");
                return;
            }
            if(!tim.Any(t => t.Pozicija==Pozicija.Hirurg))
            {
                MessageBox.Show("Tim mora sadržati bar jednog hirurga","Neispravan unos");
                return;
            }
            if (!tim.Any(t => t.Pozicija == Pozicija.Sestra))
            {
                MessageBox.Show("Tim mora sadržati bar jednu sestru", "Neispravan unos");
                return;
            }
            if (!tim.Any(t => t.Pozicija == Pozicija.Anesteziolog))
            {
                MessageBox.Show("Tim mora sadržati bar jednog anesteziologa", "Neispravan unos");
                return;
            }

            SetControlEnable(false);          
            Tim noviTim = new Tim()
            {               
                NazivTima = txtNazivTima.Text
            };
            List<Osoblje> clanoviTima = tim.ToList();
            Osoblje odgovoran = (Osoblje)cbOdgovornoLice.SelectedItem;
            Komunikacija.Instance.DodajTim(noviTim, clanoviTima, odgovoran);

        }
    }
}
