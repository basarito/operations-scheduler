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
    public partial class OperacijaForma : Form
    {
        bool stateEnabled = false;
        public ComboBox CbSale { get { return cbSale; } }
        public DataGridView DgvTimovi { get { return dgvTimovi; } }
        public bool EditMode { get; set; }

        public OperacijaForma(bool edit = false)
        {
            InitializeComponent();
            SetEnableControls(false);
            KontrolerKI.VratiSveSale();
            cbStatus.DataSource = KontrolerKI.VratiStatuseOperacija();
            cbStatus.Enabled = false;
            EditMode = false;
            if (edit)
            {
                EditMode = true;
                this.Text = "Izmena operacije";
                btnSave.Text = "Sačuvaj";
            }
        }

        public void SetEnableControls(bool state)
        {
            stateEnabled = state;
            cbSale.Enabled = state;
            datePickerTerminOdDatum.Enabled = state;
            datePickerTerminDoDatum.Enabled = state;
            datePickerTerminOdVreme.Enabled = state;
            datePickerTerminDoVreme.Enabled = state;
            dgvTimovi.Enabled = state;
            if(state)
            {
                PocetnaForma.ApplyEnabledStyle(btnSave);
                this.Cursor = Cursors.Arrow;
            } else
            {
                PocetnaForma.ApplyDisabledStyle(btnSave);
                this.Cursor = Cursors.WaitCursor;
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            KontrolerKI.OperacijaForma = null;
            this.Dispose();
        }

        internal void SetDataGridView()
        {
            dgvTimovi.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTimovi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTimovi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTimovi.ClearSelection();
            dgvTimovi.MultiSelect = false;
            SetEnableControls(true);
        }

        private void OperacijaForma_Load(object sender, EventArgs e)
        {
            datePickerTerminOdDatum.MinDate = DateTime.Now;
            datePickerTerminDoDatum.MinDate = datePickerTerminOdDatum.Value;
            datePickerTerminOdVreme.Value = DateTime.Now;
            datePickerTerminDoVreme.Value = DateTime.Now.AddHours(1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!stateEnabled)
            {
                return;
            }
            if(dgvTimovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite operativni tim!");
                return;
            }

            DateTime terminOd = DateTime.Now;
            DateTime terminDo = DateTime.Now;
            try
            {
                string datePart = (datePickerTerminOdDatum.Value.Date).ToString().Split(' ')[0];
                string timePart = (datePickerTerminOdVreme.Value.TimeOfDay).ToString();
                terminOd = DateTime.Parse($"{datePart} {timePart}");

                datePart = (datePickerTerminDoDatum.Value.Date).ToString().Split(' ')[0];
                timePart = (datePickerTerminDoVreme.Value.TimeOfDay).ToString();
                terminDo = DateTime.Parse($"{datePart} {timePart}");

                if(terminDo <= terminOd)
                {
                    throw new Exception();
                }

            } catch (Exception)
            {
                MessageBox.Show("Pogresno unesen datum!");
                return;
            }

            if(EditMode)
            {
                KontrolerKI.IzmeniOperaciju(cbStatus.SelectedItem, cbSale.SelectedItem,
                    dgvTimovi.SelectedRows[0].DataBoundItem, terminOd, terminDo);
            } else
            {
                KontrolerKI.DodajNovuOperaciju(cbSale.SelectedItem,
                    dgvTimovi.SelectedRows[0].DataBoundItem, terminOd, terminDo);
            }
        }

        internal void ShowResponse(TransferKlasa odgovor)
        {
            MessageBox.Show(odgovor.Poruka);
            this.Dispose();
        }

        private void cbSale_DataSourceChanged(object sender, EventArgs e)
        {
            KontrolerKI.VratiSveTimove();        
        
        }

        internal void PopuniFormu(DateTime terminOd, DateTime terminDo)
        {
            datePickerTerminOdDatum.MinDate = DateTimePicker.MinimumDateTime;
            datePickerTerminDoDatum.MinDate = DateTimePicker.MinimumDateTime;

            datePickerTerminOdDatum.Value = terminOd.Date;
            datePickerTerminOdVreme.Value = terminOd;
            datePickerTerminDoDatum.Value = terminDo.Date;
            datePickerTerminDoVreme.Value = terminDo;
            cbStatus.Enabled = true;
        }

        private void datePicker_DropDown(object sender, EventArgs e)
        {
            if(EditMode)
            {
                datePickerTerminOdDatum.MinDate = DateTime.Now;
                datePickerTerminDoDatum.MinDate = datePickerTerminOdDatum.Value;
                datePickerTerminOdVreme.Value = DateTime.Now;
                datePickerTerminDoVreme.Value = DateTime.Now.AddHours(1);
            }
        }

    }
}
