using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Klijent
{
    public class Komunikacija
    {
        private PocetnaForma Forma { get; set; }
        bool isKraj = false;

        #region singleton
        private static Komunikacija instance;

        TcpClient klijent;
        NetworkStream tok;
        BinaryFormatter formater = new BinaryFormatter();

        private Komunikacija()
        {

        }

        public static Komunikacija Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Komunikacija();
                }
                return instance;
            }
        }
        #endregion

        public void PoveziSe()
        {
            try
            {
                this.klijent = new TcpClient("127.0.0.1", 9000);
                this.tok = klijent.GetStream();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Kraj()
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.KRAJ,
            };
            formater.Serialize(tok, transfer);
            klijent.Close();
        }

        public void OsluskujOdgovore(PocetnaForma forma)
        {
            Forma = forma;
            new Thread(Osluskuj).Start();
        }

        public void Osluskuj()
        {
            try
            {
                isKraj = false;
                while(!isKraj)
                {
                    TransferKlasa odgovor = formater.Deserialize(tok) as TransferKlasa;
                    switch(odgovor.Akcija)
                    {
                        case Akcija.KRAJ:
                            isKraj = true;
                            HandleServerExit();                          
                            break;
                        case Akcija.DODAJ_OSOBLJE:
                            Forma.OsobljeForma.HandleResponse(odgovor);
                            break;
                        case Akcija.PRETRAGA_OSOBLJE:
                            Forma.OsobljeForma.HandleResponse(odgovor);
                            Forma.OsobljeForma.PrikaziRezultatePretragePoziv(odgovor);
                            break;
                        case Akcija.UCITAJ_OSOBLJE:
                            Forma.OsobljeForma.HandleResponse(odgovor);
                            Forma.OsobljeForma.PrikaziDetaljePoziv(odgovor);
                            break;
                        case Akcija.VRATI_OSOBLJE:                          
                            HandleVratiSveOsoblje(odgovor);
                            break;
                        case Akcija.DODAJ_TIM:
                            HandleDodajTim(odgovor);
                            break;
                        case Akcija.PRETRAGA_TIM:
                            HandePretragaTimova(odgovor);
                            break;
                        case Akcija.UCITAJ_TIM:
                            HandleUcitajTim(odgovor);
                            break;
                        
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void HandleUcitajTim(TransferKlasa odgovor)
        {
            Forma.PocetnaTimForma.TimPrikazForma.Invoke(new Action(
                () => { Forma.PocetnaTimForma.TimPrikazForma.ShowResponse(odgovor); }
                ));
            if(odgovor.Signal)
            {
                Forma.PocetnaTimForma.TimPrikazForma.Invoke(new Action(
                   () => { Forma.PocetnaTimForma.TimPrikazForma.PopulateForm((Tim)odgovor.TransferObjekat); } 
                    ));
            }
        }

        internal void UcitajTim(Tim tim)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.UCITAJ_TIM,
                TransferObjekat = tim
            };
            formater.Serialize(tok, transfer);
        }

        private void HandePretragaTimova(TransferKlasa odgovor)
        {
            var lista = (IList<IOpstiDomenskiObjekat>)odgovor.TransferObjekat;
            List<Tim> lista2 = new List<Tim>();
            foreach (var odo in lista)
            {
                lista2.Add((Tim)odo);
            }
            Forma.PocetnaTimForma.Invoke(new Action(
                () =>
                {
                    Forma.PocetnaTimForma.PrikaziRezultatePretrage(lista2);
                }
                ));
        }

        private void HandleDodajTim(TransferKlasa odgovor)
        {
            Forma.PocetnaTimForma.TimForma.Invoke(new Action(
                () => {
                    Forma.PocetnaTimForma.TimForma.ShowResponse(odgovor);
                }
                ));
            Forma.PocetnaTimForma.TimForma.Invoke(new Action(
                () =>
                {
                    Forma.PocetnaTimForma.TimForma.ResetForm();
                }
                ));
        }

        private void HandleVratiSveOsoblje(TransferKlasa odgovor)
        {
            Forma.PocetnaTimForma.TimForma.Invoke(new Action(
                () => {
                    Forma.PocetnaTimForma.TimForma.ShowResponse(odgovor);
                }
                ));
            if(odgovor.Signal)
            {
                //System.Windows.Forms.MessageBox.Show(odgovor.Poruka, "Uspesno!");
                var odoList = (List<IOpstiDomenskiObjekat>)odgovor.TransferObjekat;
                List<Osoblje> listaSvihOsoblja = new List<Osoblje>();
                foreach(var o in odoList)
                {
                    listaSvihOsoblja.Add((Osoblje)o);
                }
                
                Forma.PocetnaTimForma.TimForma.Invoke(new Action(
                    () =>
                    {
                        Forma.PocetnaTimForma.TimForma.ListaOsoblja = listaSvihOsoblja;
                    }
                    ));
                Forma.PocetnaTimForma.TimForma.Invoke(new Action(
                    Forma.PocetnaTimForma.TimForma.PopulateListBoxes));
            } else
            {
                //System.Windows.Forms.MessageBox.Show(odgovor.Poruka, "Doslo je do greske!");             
                Forma.PocetnaTimForma.TimForma.Invoke(new Action(
                    () =>
                    {
                        Forma.PocetnaTimForma.TimForma.Dispose();
                    }
                    ));
            }
        }

        public void HandleServerExit()
        {
            System.Windows.Forms.MessageBox.Show("Server više ne radi. Molimo vas pokušajte ponovo kasnije.", "Došlo je do greške!");
            //todo dodati mozda retry
            Forma.Invoke(new Action(Forma.EndSession));
        }

        public void DodajOsoblje(Osoblje osoblje)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.DODAJ_OSOBLJE,
                TransferObjekat = osoblje
            };
            formater.Serialize(tok, transfer);
        }

        public void PretragaOsoblja(Osoblje osoblje)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.PRETRAGA_OSOBLJE,
                TransferObjekat = osoblje
            };
            formater.Serialize(tok, transfer);
        }

        public void UcitajOsoblje(Osoblje osoblje)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.UCITAJ_OSOBLJE,
                TransferObjekat = osoblje
            };
            formater.Serialize(tok, transfer);
        }

        public void VratiSveOsoblje()
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.VRATI_OSOBLJE
            };
            formater.Serialize(tok, transfer);
        }

        public void DodajTim(Tim tim, List<Osoblje> clanoviTima, Osoblje odgovoran)
        {
            List<ClanTima> clanovi = new List<ClanTima>();
            foreach(Osoblje o in clanoviTima)
            {
                clanovi.Add(new ClanTima()
                {
                    OsobljeID = o.OsobljeID,
                    Odgovoran = o.OsobljeID == odgovoran.OsobljeID
                });
            }
            tim.ClanoviTima = clanovi;
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.DODAJ_TIM,
                TransferObjekat = tim
            };
            formater.Serialize(tok, transfer);
        }

        internal void PronadjiTimove(string kriterijum)
        {
            Tim tim = new Tim()
            {
                NazivTima = kriterijum
            };
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.PRETRAGA_TIM,
                TransferObjekat = tim
            };
            formater.Serialize(tok, transfer);
        }

    }
}
