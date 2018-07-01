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

        public OperacijaForma()
        {
            InitializeComponent();
            SetEnableControls(false);
            Komunikacija.Instance.VratiSveSale();
            
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
                PocetnaForma.ApplyEnabledStyle(btnBack);
                PocetnaForma.ApplyEnabledStyle(btnSave);
                this.Cursor = Cursors.Arrow;
            } else
            {
                PocetnaForma.ApplyDisabledStyle(btnBack);
                PocetnaForma.ApplyDisabledStyle(btnSave);
                this.Cursor = Cursors.WaitCursor;
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        internal void PopulateComboBox(List<Sala> sale)
        {
            cbSale.DataSource = sale;
            Komunikacija.Instance.VratiSveTimove();
        }

        internal void PopulateDataGridView(List<Tim> timovi)
        {
            dgvTimovi.DataSource = timovi;
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

            } catch (Exception)
            {
                MessageBox.Show("Pogresno unesen datum!");
                return;
            }

            //todo provera datuma

            Operacija operacija = new Operacija()
            {
                SalaID = ((Sala)cbSale.SelectedItem).SalaID,
                TimID = ((Tim)dgvTimovi.SelectedRows[0].DataBoundItem).TimID,
                TerminOd = terminOd,
                TerminDo = terminDo,
                Status = Status.Zakazana
            };
            Komunikacija.Instance.DodajOperaciju(operacija);
        }

        internal void ShowResponse(TransferKlasa odgovor)
        {
            MessageBox.Show(odgovor.Poruka);
            this.Dispose();
        }
    }
}
