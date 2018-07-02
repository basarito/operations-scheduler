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
        public Tim TimEdit { get; set; }

        public TimForma(Tim t = null)
        {
            InitializeComponent();
            Komunikacija.Instance.VratiSveOsoblje();
            if (t != null)
            {
                TimEdit = t;
                this.Text = "Izmena tima";
            }
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
            if (state)
            {
                PocetnaForma.ApplyEnabledStyle(btnSave);
                PocetnaForma.ApplyEnabledStyle(btnBack);
                this.Cursor = Cursors.Arrow;
            }
            else
            {
                PocetnaForma.ApplyDisabledStyle(btnSave);
                PocetnaForma.ApplyDisabledStyle(btnBack);
                this.Cursor = Cursors.WaitCursor;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (isEnabled)
            {
                this.Dispose();
            }
        }

        public void PopulateListBoxes()
        {
            foreach (Osoblje o in ListaOsoblja)
            {
                switch (o.Pozicija)
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

            //if edit mode:
            if (TimEdit != null)
            {
                CheckExistingMembers(checkListHirurzi);
                CheckExistingMembers(checkListStazisti);
                CheckExistingMembers(checkListSestre);
                CheckExistingMembers(checkListAnesteziolozi);

                txtNazivTima.Text = TimEdit.NazivTima;

                ClanTima odgovoran = TimEdit.ClanoviTima.Find(clan => clan.Odgovoran == true);
                if(odgovoran != null)
                {
                    var osoblje = tim.Where(o => o.OsobljeID == odgovoran.Osoblje.OsobljeID);
                    cbOdgovornoLice.SelectedItem = osoblje.First();
                } else
                {
                    cbOdgovornoLice.SelectedItem = tim.First();
                }
            }
        }

        public void CheckExistingMembers(CheckedListBox list)
        {
            var items = list.Items;
            for (int i = 0; i < items.Count; i++)
            {
                int id = ((Osoblje)items[i]).OsobljeID;
                var find = TimEdit.ClanoviTima.Find(clan => clan.OsobljeID == id);
                if (find != null)
                {
                    list.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    list.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        public delegate void PopulateListDelegate(List<Osoblje> o);
        internal void PopulateList(List<Osoblje> o)
        {
            ListaOsoblja = o;
        }
    
        private void checkListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            {
                tim.Add((Osoblje) ((CheckedListBox)sender).Items[e.Index]);
            } else if(e.NewValue == CheckState.Unchecked)
            {
                tim.Remove((Osoblje)((CheckedListBox)sender).Items[e.Index]);
            }
        }

        public void ShowResponse(TransferKlasa tk)
        {
            MessageBox.Show(tk.Poruka);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isEnabled)
            {
                return;
            }
            if (String.IsNullOrWhiteSpace(txtNazivTima.Text))
            {
                MessageBox.Show("Molimo popunite naziv tima!", "Neispravan unos");
                return;
            }
            if (!tim.Any(t => t.Pozicija == Pozicija.Hirurg))
            {
                MessageBox.Show("Tim mora sadržati bar jednog hirurga", "Neispravan unos");
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
                NazivTima = txtNazivTima.Text.Trim()
            };
            List<Osoblje> clanoviTima = tim.ToList();
            Osoblje odgovoran = (Osoblje)cbOdgovornoLice.SelectedItem;
            if(TimEdit != null)
            {
                noviTim.TimID = TimEdit.TimID;
                Komunikacija.Instance.IzmeniTim(noviTim, clanoviTima, odgovoran);
            } else
            {
                Komunikacija.Instance.DodajTim(noviTim, clanoviTima, odgovoran);
            }
            

        }
    }
}
