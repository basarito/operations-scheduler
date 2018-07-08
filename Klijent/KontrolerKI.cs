using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public class KontrolerKI
    {
        public static String ErrorMessage { get; set; }

        public static PocetnaForma PocetnaForma { get; set; }
        public static OsobljeForma OsobljeForma { get; set; }
        public static PocetnaTimForma PocetnaTimForma { get; set; }
        public static PocetnaOperacijaForma PocetnaOperacijaForma { get; set; }
        public static OsobljePrikazForma OsobljePrikazForma { get; set; }
        public static TimForma TimForma { get; set; }
        public static TimPrikazForma TimPrikazForma { get; set; }
        public static OperacijaForma OperacijaForma { get; set; }
        public static OperacijaPrikazForma OperacijaPrikazForma { get; set; }

        public KontrolerKI(PocetnaForma forma)
        {
            PocetnaForma = forma;
        }

        internal static bool BeginSession()
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
                Komunikacija.Instance.OsluskujOdgovore();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        internal static void PrikaziDetaljeOperacije(object dataBoundItem)
        {
            Operacija o = (Operacija)dataBoundItem;
            OperacijaPrikazForma = new OperacijaPrikazForma(o);
            OperacijaPrikazForma.ShowDialog();
        }

        internal static void PrikaziDetaljeOsoblja(object selectedItem)
        {
            Osoblje o = (Osoblje)selectedItem;
            Komunikacija.Instance.UcitajOsoblje(o);
        }

        internal static void UcitajOperaciju(object o)
        {
            Komunikacija.Instance.UcitajOperaciju((Operacija)o);
        }

        internal static void PretraziOperacije(DateTime datum)
        {
            Operacija op = new Operacija()
            {
                TerminOd = datum
            };
            Komunikacija.Instance.PretragaOperacija(op);
        }

        internal static void OpenOperacijaFormu()
        {
            OperacijaForma = new OperacijaForma();
            OperacijaForma.ShowDialog();
        }

        internal static void OtvoriTimFormu()
        {
            TimForma = new TimForma();
            TimForma.ShowDialog();
        }

        internal static void OpenOsobljePrikazFormu(object selectedItem)
        {
            OsobljePrikazForma = new OsobljePrikazForma(selectedItem);
            OsobljePrikazForma.ShowDialog();
        }

        internal static void PronadjiTimove(string kriterijum)
        {
            Tim tim = new Tim()
            {
                NazivTima = kriterijum
            };
            Komunikacija.Instance.PronadjiTimove(tim);
        }

        internal static bool EndSession()
        {
            try
            {
                Komunikacija.Instance.Kraj();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        internal static void OpenIzmenaTima(object ucitanTim)
        {
            TimForma = new TimForma(ucitanTim, ((Tim)ucitanTim).NazivTima);
            TimForma.ShowDialog();                       
        }

        internal static void UcitajTimZaIzmenu(object ucitanTim)
        {
            Tim tim = (Tim)ucitanTim;
            CheckExistingMembersInCLB(TimForma, TimForma.CheckedListHirurzi, tim);
            CheckExistingMembersInCLB(TimForma, TimForma.CheckedListStazisti, tim);
            CheckExistingMembersInCLB(TimForma, TimForma.CheckedListSestre, tim);
            CheckExistingMembersInCLB(TimForma, TimForma.CheckedListAnesteziolozi, tim);

            ClanTima odgovoran = tim.ClanoviTima.Find(clan => clan.Odgovoran == true);
            if (odgovoran != null)
            {
                var osoblje = TimForma.TimBinding.Where((o => ((Osoblje)o).OsobljeID == odgovoran.Osoblje.OsobljeID));
                TimForma?.Invoke(new Action(() => {
                    TimForma.ComboBoxOdgovornoLice.SelectedItem = osoblje.First();
                }));
            }
            else
            {
                TimForma?.Invoke(new Action(() => {
                    TimForma.ComboBoxOdgovornoLice.SelectedItem = TimForma.TimBinding.First();
                }));
            }

        }

        internal static void DodajNovuOperaciju(object selectedSala, object selectedTim, DateTime terminOd, DateTime terminDo)
        {
            Operacija operacija = new Operacija()
            {
                SalaID = ((Sala)selectedSala).SalaID,
                TimID = ((Tim)selectedTim).TimID,
                TerminOd = terminOd,
                TerminDo = terminDo,
                Status = Status.Zakazana
            };
            Komunikacija.Instance.DodajOperaciju(operacija);
        }

        public static void CheckExistingMembersInCLB(Form forma, CheckedListBox list, Tim tim)
        {
            var items = list.Items;
            for (int i = 0; i < items.Count; i++)
            {
                int id = ((Osoblje)items[i]).OsobljeID;
                var find = tim.ClanoviTima.Find(clan => clan.OsobljeID == id);
                if (find != null)
                {
                    forma?.Invoke(new Action(() => {
                        list.SetItemCheckState(i, CheckState.Checked);
                    }));
                }
                else
                {
                    forma?.Invoke(new Action(() => {
                        list.SetItemCheckState(i, CheckState.Unchecked);
                    }));
                }
            }
        }

        internal static void VratiSveTimove()
        {
            Komunikacija.Instance.VratiSveTimove();
        }

        internal static void PrikaziDetaljeTima(object obj)
        {
            Tim tim = new Tim();
            if(obj is int)
            {
                tim.TimID = Convert.ToInt32(obj);
            } else
            {
                tim = (Tim)obj;
            }
           
            Komunikacija.Instance.UcitajTim(tim);
        }

        internal static void SacuvajOsoblje(string imePrezime, string jmbg, object pozicija)
        {
            Osoblje o = new Osoblje()
            {
                ImePrezime = imePrezime,
                Jmbg = jmbg,
                Pozicija = (Pozicija)pozicija
            };

            Komunikacija.Instance.DodajOsoblje(o);
        }

        internal static void OpenTimPrikazFormu(object selectedItem)
        {
            TimPrikazForma = new TimPrikazForma(selectedItem);
            TimPrikazForma.ShowDialog();
        }

        internal static List<Pozicija> VratiListuPozicija()
        {
            return new List<Pozicija>()
            { Pozicija.Hirurg, Pozicija.Sestra, Pozicija.Stazista, Pozicija.Anesteziolog};
        }

        private static void CloseOpenForms()
        {
            if (Application.OpenForms.Count > 1)
            {
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (Application.OpenForms[i].Name != "PocetnaForma")
                        Application.OpenForms[i]?.Invoke(new Action(Application.OpenForms[i].Dispose));
                }
            }
        }

        internal static void OpenOsobljeFormu()
        {
            OsobljeForma = new OsobljeForma();
            OsobljeForma.ShowDialog();
        }

        internal static void OpenPocetnuTimFormu()
        {
            PocetnaTimForma = new PocetnaTimForma();
            PocetnaTimForma.ShowDialog();
        }

        internal static void OpenPocetnuOperacijaFormu()
        {
            PocetnaOperacijaForma = new PocetnaOperacijaForma();
            PocetnaOperacijaForma.ShowDialog();
        }

        internal static void PrikaziPoruku(bool signal, string poruka, Akcija akcija)
        {
            Form forma = null;

            switch (akcija)
            {
                case Akcija.DODAJ_OSOBLJE:
                    forma = OsobljeForma;
                    OsobljeForma?.Invoke(new Action(OsobljeForma.ResetForm));
                    break;
                case Akcija.PRETRAGA_OSOBLJE:
                    forma = OsobljeForma;
                    break;
                case Akcija.UCITAJ_OSOBLJE:
                    forma = OsobljePrikazForma;
                    break;
                case Akcija.PRETRAGA_TIM:
                    forma = PocetnaTimForma;
                    break;
                case Akcija.UCITAJ_TIM:
                    forma = TimPrikazForma;
                    break;
                case Akcija.VRATI_OSOBLJE:
                    forma = TimForma;
                    break;
                case Akcija.DODAJ_TIM:
                    forma = TimForma;
                    TimForma?.Invoke(new Action(TimForma.ResetForm));                   
                    break;
                case Akcija.IZMENI_TIM:
                    forma = TimForma;                    
                    break;
                case Akcija.VRATI_SALE:
                case Akcija.VRATI_TIMOVE:
                    forma = OperacijaForma;
                    break;
                case Akcija.DODAJ_OPERACIJU:
                    forma = OperacijaForma;
                    break;
                case Akcija.PRETRAGA_OPERACIJA:
                    forma = PocetnaOperacijaForma;
                    break;
                case Akcija.UCITAJ_OPERACIJU:
                    forma = OperacijaPrikazForma;
                    break;
            }
            forma?.Invoke(new Action(
                () =>
                {
                    MessageBox.Show(poruka);
                    forma.Cursor = Cursors.Arrow;
                }
                ));

            if(akcija == Akcija.IZMENI_TIM)
            {
                TimForma?.Invoke(new Action(TimForma.Dispose));
            } else if (akcija == Akcija.DODAJ_OPERACIJU)
            {
                OperacijaForma?.Invoke(new Action(OperacijaForma.Dispose));
            }
        }

        internal static void HandleAlternative(Akcija akcija)
        {
            switch (akcija)
            {
                case Akcija.UCITAJ_OSOBLJE:
                    OsobljePrikazForma?.Invoke(new Action(OsobljePrikazForma.Dispose));
                    OsobljeForma?.Invoke(new Action(() =>
                    {
                        OsobljeForma.Cursor = Cursors.Arrow;
                    }));
                    break;
                case Akcija.UCITAJ_TIM:
                    TimPrikazForma?.Invoke(new Action(TimPrikazForma.Dispose));
                    //todo fix this
                    PocetnaTimForma?.Invoke(new Action(() =>
                    {
                        PocetnaTimForma.Cursor = Cursors.Arrow;
                    }));
                    OperacijaPrikazForma?.Invoke(new Action(() =>
                    {
                        OperacijaPrikazForma.Cursor = Cursors.Arrow;
                    }));
                    break;
                case Akcija.VRATI_OSOBLJE:
                    TimForma?.Invoke(new Action(TimForma.Dispose));
                    break;
                case Akcija.IZMENI_TIM:
                    TimForma?.Invoke(new Action(TimForma.Dispose));
                    break;
                case Akcija.VRATI_SALE:
                case Akcija.VRATI_TIMOVE:
                    OperacijaForma?.Invoke(new Action(OperacijaForma.Dispose));
                    break;
                case Akcija.PRETRAGA_OPERACIJA:
                    PocetnaOperacijaForma?.Invoke(new Action(PocetnaOperacijaForma.NoResultDgv));
                    break;
            }
        }

        internal static void IzmeniTim(object timEdit, string naziv, BindingList<object> timBinding, object odgovornoLice)
        {
            Tim tim = (Tim)timEdit;
            List<ClanTima> clanovi = new List<ClanTima>();
            var clanoviTima = timBinding.ToList();
            Osoblje odgovoran = (Osoblje)odgovornoLice;


            foreach (Osoblje o in clanoviTima)
            {
                clanovi.Add(new ClanTima()
                {
                    OsobljeID = o.OsobljeID,
                    Odgovoran = o.OsobljeID == odgovoran.OsobljeID,
                    Osoblje = o,
                    TimID = tim.TimID
                });
            }

            Tim noviTim = new Tim()
            {
                TimID = tim.TimID,
                NazivTima = naziv,
                ClanoviTima = clanovi
            };
            Komunikacija.Instance.IzmeniTim(noviTim);
        }

        internal static void UcitajRezultat(object transferObjekat, Akcija akcija)
        {
            switch (akcija)
            {
                case (Akcija.UCITAJ_OSOBLJE):
                    Osoblje o = (Osoblje)transferObjekat;
                    OsobljePrikazForma?.Invoke(new Action(() =>
                    {
                        OsobljePrikazForma.PopunuFormu(o.OsobljeID.ToString(), o.ImePrezime, o.Jmbg, o.Pozicija.ToString());
                    }));
                    break;
                case (Akcija.UCITAJ_TIM):
                    Tim t = (Tim)transferObjekat;
                    TimPrikazForma?.Invoke(new Action(() =>
                    {
                        TimPrikazForma.UcitanTim = t;
                        TimPrikazForma.PopunuFormu(t.TimID.ToString(), t.NazivTima);
                        TimPrikazForma.DgvClanovi.DataSource = t.ClanoviTima;
                        TimPrikazForma.DgvClanovi.Columns[0].Width = 80;
                        TimPrikazForma.DgvClanovi.ClearSelection();
                    }));
                    break;
                case (Akcija.VRATI_OSOBLJE):
                    List<Osoblje> listaOsoblja = (List<Osoblje>)TransformList(
                        (List<IOpstiDomenskiObjekat>)transferObjekat, new Osoblje());
                    PopuniTimFormu(listaOsoblja);
                    break;
                case (Akcija.VRATI_SALE):
                    List<Sala> listaSala = (List<Sala>)transferObjekat;
                    OperacijaForma?.Invoke(new Action(()=> {
                        OperacijaForma.CbSale.DataSource = listaSala;
                    }));
                    break;
                case Akcija.VRATI_TIMOVE:
                    List<Tim> listaTimova = (List<Tim>)transferObjekat;
                    OperacijaForma?.Invoke(new Action(() => {
                        OperacijaForma.DgvTimovi.DataSource = listaTimova;
                        OperacijaForma.SetDataGridView();
                    }));
                    break;
                case Akcija.UCITAJ_OPERACIJU:
                    Operacija op = (Operacija)transferObjekat;
                    OperacijaPrikazForma?.Invoke(new Action(()=> {
                        OperacijaPrikazForma.PopulateForm(op.OperacijaID.ToString(), op.Sala.NazivSale,
                                                          op.Sala.Sprat, op.TerminOdFormat,
                                                          op.TerminDoFormat, op.Status.ToString());
                        OperacijaPrikazForma.TimID = op.TimID;
                    }));
                    break;
            }
        }

        internal static void DodajNoviTim(string naziv, BindingList<object> timBinding, object selectedOdgovornoLice)
        {
            List<ClanTima> clanovi = new List<ClanTima>();
            var clanoviTima = timBinding.ToList();
            Osoblje odgovoran = (Osoblje)selectedOdgovornoLice;

            foreach (Osoblje o in clanoviTima)
            {
                clanovi.Add(new ClanTima()
                {
                    OsobljeID = o.OsobljeID,
                    Odgovoran = o.OsobljeID == odgovoran.OsobljeID,
                });
            }

            Tim noviTim = new Tim()
            {
                NazivTima = naziv,
                ClanoviTima = clanovi
            };
            Komunikacija.Instance.DodajTim(noviTim);
        }

        private static void PopuniTimFormu(List<Osoblje> listaOsoblja)
        {
            TimForma?.Invoke(new Action(()=> {
                foreach (Osoblje o in listaOsoblja)
                {
                    switch (o.Pozicija)
                    {
                        case Pozicija.Hirurg:
                            TimForma.CheckedListHirurzi.Items.Add(o);
                            break;
                        case Pozicija.Stazista:
                            TimForma.CheckedListStazisti.Items.Add(o);
                            break;
                        case Pozicija.Sestra:
                            TimForma.CheckedListSestre.Items.Add(o);
                            break;
                        case Pozicija.Anesteziolog:
                            TimForma.CheckedListAnesteziolozi.Items.Add(o);
                            break;
                    }
                }
                TimForma.AfterPopulatedListBoxes();
            }));
        }

        internal static void PretraziOsoblje(string kriterijum)
        {
            Osoblje o = new Osoblje()
            {
                ImePrezime = kriterijum,
                Jmbg = kriterijum
            };
            Komunikacija.Instance.PretragaOsoblja(o);
        }

        internal static void PrikaziRezultatePretrage(object transferObjekat, Akcija akcija)
        {
            dynamic transform = new List<IOpstiDomenskiObjekat>();
            switch (akcija)
            {
                case Akcija.PRETRAGA_OSOBLJE:
                    transform = TransformList((List<IOpstiDomenskiObjekat>)transferObjekat, new Osoblje());
                    OsobljeForma?.Invoke(new Action(() =>
                    {
                        OsobljeForma.ListSearchResults.DataSource = transform;
                        OsobljeForma.PrikaziRezultatePretrage(transform.Count);
                    }));
                    break;
                case Akcija.PRETRAGA_TIM:
                    transform = TransformList((List<IOpstiDomenskiObjekat>)transferObjekat, new Tim());
                    PocetnaTimForma?.Invoke(new Action(() =>
                    {
                        PocetnaTimForma.ListSearchResults.DataSource = transform;
                        PocetnaTimForma.PrikaziRezultatePretrage(transform.Count);
                    }));
                    break;
                case Akcija.PRETRAGA_OPERACIJA:
                    List<Operacija> op = (List <Operacija>)transferObjekat;
                    PocetnaOperacijaForma?.Invoke(new Action(() => {
                        PocetnaOperacijaForma.DgvSearchResult.DataSource = op;
                        PocetnaOperacijaForma.PrikaziRezultatPretrage();
                    }));
                    break;
            }
        }

        private static object TransformList(List<IOpstiDomenskiObjekat> objekti, object cilj)
        {
            dynamic result = null;
            switch (cilj.GetType().Name)
            {
                case "Osoblje":
                    result = new List<Osoblje>();
                    foreach (var obj in objekti)
                    {
                        result.Add((Osoblje)obj);
                    }
                    break;
                case "Tim":
                    result = new List<Tim>();
                    foreach (var obj in objekti)
                    {
                        result.Add((Tim)obj);
                    }
                    break;
            }
            return result;
        }

        internal static void HandleServerEndSession()
        {
            if (Application.OpenForms.Count > 1)
            {
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (Application.OpenForms[i].Name != "PocetnaForma")
                    {
                        Application.OpenForms[i]?.Invoke(new Action(
                       () =>
                       {
                           Application.OpenForms[i].Enabled = false;
                       }
                       ));
                    }
                }
            }
            MessageBox.Show("Doslo je do prekida komunikacije sa serverom. Molimo pokusajte ponovo kasnije.");
            CloseOpenForms();
            PocetnaForma?.Invoke(new Action(PocetnaForma.EndSession));
        }

        internal static void VratiSveOsoblje()
        {
            Komunikacija.Instance.VratiSveOsoblje();
        }

        internal static void VratiSveSale()
        {
            Komunikacija.Instance.VratiSveSale();
        }
    }
}
