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
        public BindingList<object> TimBinding { get; set; }

        bool isEnabled = false;
        public Object TimEdit { get; set; }

        public CheckedListBox CheckedListHirurzi { get { return checkListHirurzi; } }
        public CheckedListBox CheckedListStazisti { get { return checkListStazisti; } }
        public CheckedListBox CheckedListSestre { get { return checkListSestre; } }
        public CheckedListBox CheckedListAnesteziolozi { get { return checkListAnesteziolozi; } }

        public ComboBox ComboBoxOdgovornoLice { get { return cbOdgovornoLice; } }

        public TimForma(object tim = null, string naziv = "")
        {
            InitializeComponent();
            TimBinding = new BindingList<object>();
            KontrolerKI.VratiSveOsoblje();
            if(tim != null)
            {
                TimEdit = tim;
                this.Text = "Izmena tima";
                txtNazivTima.Text = naziv;
            }
        }

        private void TimForma_Load(object sender, EventArgs e)
        {
            SetControlEnable(false);
            cbOdgovornoLice.DataSource = TimBinding;
            
        }

        public void ResetForm()
        {
            SetControlEnable(true);
            TimBinding.Clear();
            txtNazivTima.Clear();

            UncheckAll(checkListHirurzi);
            UncheckAll(checkListStazisti);
            UncheckAll(checkListSestre);
            UncheckAll(checkListAnesteziolozi);
        }

        private void UncheckAll(CheckedListBox clb)
        {
            foreach (int i in clb.CheckedIndices)
            {
                clb.SetItemCheckState(i, CheckState.Unchecked);
            }
            clb.ClearSelected();
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

        public void AfterPopulatedListBoxes()
        {
            checkListHirurzi.DisplayMember = "ImePrezime";
            checkListStazisti.DisplayMember = "ImePrezime";
            checkListSestre.DisplayMember = "ImePrezime";
            checkListAnesteziolozi.DisplayMember = "ImePrezime";
            SetControlEnable(true);


            //if edit mode:
            if(TimEdit != null)
            {
                KontrolerKI.UcitajTimZaIzmenu(TimEdit);
            }
        }

        private void checkListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {               
                TimBinding.Add(((CheckedListBox)sender).Items[e.Index]);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                TimBinding.Remove(((CheckedListBox)sender).Items[e.Index]);
            }
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
 
            if (checkListHirurzi.CheckedItems.Count == 0)
            {
                MessageBox.Show("Tim mora sadržati bar jednog hirurga", "Neispravan unos");
                return;
            }
            if (checkListSestre.CheckedItems.Count == 0)
            {
                MessageBox.Show("Tim mora sadržati bar jednu sestru", "Neispravan unos");
                return;
            }
            if (checkListAnesteziolozi.CheckedItems.Count == 0)
            {
                MessageBox.Show("Tim mora sadržati bar jednog anesteziologa", "Neispravan unos");
                return;
            }

            SetControlEnable(false);

            if (TimEdit != null)
            {
                KontrolerKI.IzmeniTim(TimEdit, txtNazivTima.Text.Trim(), TimBinding, cbOdgovornoLice.SelectedItem);
            }
            else
            {
                KontrolerKI.DodajNoviTim(txtNazivTima.Text.Trim(), TimBinding, cbOdgovornoLice.SelectedItem);
            }
        }
    }
}
