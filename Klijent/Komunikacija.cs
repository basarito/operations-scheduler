using Domen;
using System;
using System.Collections.Generic;
using System.IO;
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
        Thread OsluskujNit = null;

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
            isKraj = true;
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.KRAJ,
            };
            formater.Serialize(tok, transfer);

            klijent.Close();
        }

        public void OsluskujOdgovore()
        {
            OsluskujNit = new Thread(Osluskuj);
            OsluskujNit.Start();
        }

        public void Osluskuj()
        {
            try
            {
                isKraj = false;
                while (!isKraj)
                {
                    TransferKlasa odgovor = formater.Deserialize(tok) as TransferKlasa;
                    switch (odgovor.Akcija)
                    {
                        case Akcija.KRAJ:
                            isKraj = true;
                            HandleServerExit();
                            break;
                        case Akcija.DODAJ_OSOBLJE:
                            HandleDodajOsoblje(odgovor);
                            break;
                        case Akcija.PRETRAGA_OSOBLJE:
                            HandlePretragaOsoblja(odgovor);
                            break;
                        case Akcija.UCITAJ_OSOBLJE:
                            HandleUcitajOsoblje(odgovor);
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
                        case Akcija.IZMENI_TIM:
                            HandleIzmeniTim(odgovor);
                            break;
                        case Akcija.VRATI_SALE:
                            HandleVratiSveSale(odgovor);
                            break;
                        case Akcija.VRATI_TIMOVE:
                            HandleVratiSveTimove(odgovor);
                            break;
                        case Akcija.DODAJ_OPERACIJU:
                            HandleDodajOperaciju(odgovor);
                            break;
                        case Akcija.PRETRAGA_OPERACIJA:
                            HandlePretragaOperacija(odgovor);
                            break;
                        case Akcija.UCITAJ_OPERACIJU:
                            HandleUcitajOperaciju(odgovor);
                            break;
                        case Akcija.ZAPAMTI_IZVESTAJ:
                            HandleZapamtiIzvestaj(odgovor);
                            break;
                        case Akcija.IZMENI_OPERACIJU:
                            HandleIzmeniOperaciju(odgovor);
                            break;
                    }
                }

            }
            catch (Exception)
            {
                
            }
        }

        //RESPONSE HANDLERS

        private void HandleIzmeniOperaciju(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.IZMENI_OPERACIJU);
            if (odgovor.Signal)
            {
                KontrolerKI.UcitajRezultat(odgovor.TransferObjekat, Akcija.IZMENI_OPERACIJU);
            }
        }

        private void HandleZapamtiIzvestaj(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.ZAPAMTI_IZVESTAJ);
            if(odgovor.Signal)
            {
                KontrolerKI.UcitajRezultat(odgovor.TransferObjekat, Akcija.ZAPAMTI_IZVESTAJ);
            }
            //else
            //{
            //    KontrolerKI.HandleAlternative(Akcija.ZAPAMTI_IZVESTAJ);
            //}
        }

        private void HandleUcitajOsoblje(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.UCITAJ_OSOBLJE);
            if (odgovor.Signal)
            {
                KontrolerKI.UcitajRezultat(odgovor.TransferObjekat, Akcija.UCITAJ_OSOBLJE);
            }
            else
            {
                KontrolerKI.HandleAlternative(Akcija.UCITAJ_OSOBLJE);
            }
        }

        private void HandlePretragaOsoblja(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.PRETRAGA_OSOBLJE);
            KontrolerKI.PrikaziRezultatePretrage(odgovor.TransferObjekat, Akcija.PRETRAGA_OSOBLJE);
        }

        private void HandleDodajOsoblje(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.DODAJ_OSOBLJE);
        }

        private void HandleUcitajOperaciju(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.UCITAJ_OPERACIJU);
            if(odgovor.Signal)
            {
                KontrolerKI.UcitajRezultat(odgovor.TransferObjekat, Akcija.UCITAJ_OPERACIJU);
            } else
            {
                KontrolerKI.HandleAlternative(Akcija.UCITAJ_OPERACIJU);
            }
        }

        private void HandlePretragaOperacija(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.PRETRAGA_OPERACIJA);
            KontrolerKI.PrikaziRezultatePretrage(odgovor.TransferObjekat, Akcija.PRETRAGA_OPERACIJA);
            if(!odgovor.Signal)
            {
                KontrolerKI.HandleAlternative(Akcija.PRETRAGA_OPERACIJA);
            }
        }

        private void HandleDodajOperaciju(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.DODAJ_OPERACIJU);
        }

        private void HandleVratiSveTimove(TransferKlasa odgovor)
        {
            if (!odgovor.Signal)
            {
                KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.VRATI_TIMOVE);
                KontrolerKI.HandleAlternative(Akcija.VRATI_TIMOVE);
            }
            else
            {
                KontrolerKI.UcitajRezultat(odgovor.TransferObjekat, Akcija.VRATI_TIMOVE);
            }
        }

        private void HandleVratiSveSale(TransferKlasa odgovor)
        {
            if (!odgovor.Signal)
            {
                KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.VRATI_SALE);
                KontrolerKI.HandleAlternative(Akcija.VRATI_SALE);
            } else
            {
                KontrolerKI.UcitajRezultat(odgovor.TransferObjekat, Akcija.VRATI_SALE);
            }
        }

        private void HandleIzmeniTim(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.IZMENI_TIM);
            if (odgovor.Signal)
            {
                KontrolerKI.UcitajRezultat(odgovor.TransferObjekat, Akcija.UCITAJ_TIM);
            }
            else
            {
                KontrolerKI.HandleAlternative(Akcija.IZMENI_TIM);
            }
        }

        private void HandleUcitajTim(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.UCITAJ_TIM);
            if (odgovor.Signal)
            {
                KontrolerKI.UcitajRezultat(odgovor.TransferObjekat, Akcija.UCITAJ_TIM);
            }
            else
            {
                KontrolerKI.HandleAlternative(Akcija.UCITAJ_TIM);
            }
        }

        private void HandePretragaTimova(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.PRETRAGA_TIM);
            KontrolerKI.PrikaziRezultatePretrage(odgovor.TransferObjekat, Akcija.PRETRAGA_TIM);
        }

        private void HandleDodajTim(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.DODAJ_TIM);
        }

        private void HandleVratiSveOsoblje(TransferKlasa odgovor)
        {
            KontrolerKI.PrikaziPoruku(odgovor.Signal, odgovor.Poruka, Akcija.VRATI_OSOBLJE);
            if(odgovor.Signal)
            {
                KontrolerKI.UcitajRezultat(odgovor.TransferObjekat, Akcija.VRATI_OSOBLJE);
            } else
            {
                KontrolerKI.HandleAlternative(Akcija.VRATI_OSOBLJE);
            }
        }

        public void HandleServerExit()
        {
            KontrolerKI.HandleServerEndSession();
        }

        //REQUEST HANDLERS

        internal void UcitajTim(Tim tim)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.UCITAJ_TIM,
                TransferObjekat = tim
            };
            formater.Serialize(tok, transfer);
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

        public void DodajTim(Tim tim)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.DODAJ_TIM,
                TransferObjekat = tim
            };
            formater.Serialize(tok, transfer);
        }

        public void IzmeniTim(Tim tim)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.IZMENI_TIM,
                TransferObjekat = tim
            };
            formater.Serialize(tok, transfer);
        }

        internal void PronadjiTimove(Tim tim)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.PRETRAGA_TIM,
                TransferObjekat = tim
            };
            formater.Serialize(tok, transfer);
        }

        internal void VratiSveSale()
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.VRATI_SALE
            };
            formater.Serialize(tok, transfer);
        }

        internal void VratiSveTimove()
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.VRATI_TIMOVE
            };
            formater.Serialize(tok, transfer);
        }

        internal void DodajOperaciju(Operacija operacija)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.DODAJ_OPERACIJU,
                TransferObjekat = operacija
            };
            formater.Serialize(tok, transfer);
        }

        internal void IzmeniOperaciju(Operacija operacija)
        {
            TransferKlasa transfer = new TransferKlasa()
            {
                Akcija = Akcija.IZMENI_OPERACIJU,
                TransferObjekat = operacija
            };
            formater.Serialize(tok, transfer);
        }

        internal void PretragaOperacija(Operacija op)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.PRETRAGA_OPERACIJA,
                TransferObjekat = op
            };
            formater.Serialize(tok, transfer);
        }

        internal void UcitajOperaciju(Operacija operacija)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.UCITAJ_OPERACIJU,
                TransferObjekat = operacija
            };
            formater.Serialize(tok, transfer);
        }

        internal void ZapamtiIzvestaj(Operacija o)
        {
            TransferKlasa transfer = new TransferKlasa
            {
                Akcija = Akcija.ZAPAMTI_IZVESTAJ,
                TransferObjekat = o
            };
            formater.Serialize(tok, transfer);
        }


    }
}
