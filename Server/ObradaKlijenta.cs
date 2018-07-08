using Domen;
using KontrolerPoslovneLogike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class ObradaKlijenta
    {
        private Socket klijentSoket;
        private NetworkStream tok;
        private BinaryFormatter formater = new BinaryFormatter();
        private List<ObradaKlijenta> klijenti;
        bool isKraj = false;

        public ObradaKlijenta(Socket klijent, List<ObradaKlijenta> klijenti)
        {
            this.klijentSoket = klijent;
            this.klijenti = klijenti;
            tok = new NetworkStream(klijent);
            Thread nit = new Thread(ObradaZahteva);
            nit.Start();
        }

        private void ObradaZahteva()
        {
            try
            {
                isKraj = false;
                while (!isKraj)
                {
                    TransferKlasa zahtevKlijenta = formater.Deserialize(tok) as TransferKlasa;
                    switch (zahtevKlijenta.Akcija)
                    {
                        case Akcija.KRAJ:
                            isKraj = true;
                            klijentSoket.Shutdown(SocketShutdown.Both);
                            klijentSoket.Close();
                            klijenti.Remove(this);
                            break;
                        case Akcija.DODAJ_OSOBLJE:
                            HandleDodajOsoblje(zahtevKlijenta);
                            break;
                        case Akcija.PRETRAGA_OSOBLJE:
                            HandlePretragaOsoblje(zahtevKlijenta);
                            break;
                        case Akcija.UCITAJ_OSOBLJE:
                            HandleUcitajOsoblje(zahtevKlijenta);
                            break;
                        case Akcija.VRATI_OSOBLJE:
                            HandleVratiOsoblje(zahtevKlijenta);
                            break;
                        case Akcija.DODAJ_TIM:
                            HandleDodajTim(zahtevKlijenta);
                            break;
                        case Akcija.PRETRAGA_TIM:
                            HandlePretragaTimova(zahtevKlijenta);
                            break;
                        case Akcija.UCITAJ_TIM:
                            HandleUcitajTim(zahtevKlijenta);
                            break;
                        case Akcija.IZMENI_TIM:
                            HandleIzmeniTim(zahtevKlijenta);
                            break;
                        case Akcija.VRATI_SALE:
                            HandleVratiSale();
                            break;
                        case Akcija.VRATI_TIMOVE:
                            HandleVratiTimove();
                            break;
                        case Akcija.DODAJ_OPERACIJU:
                            HandleDodajOperaciju(zahtevKlijenta);
                            break;
                        case Akcija.PRETRAGA_OPERACIJA:
                            HandlePretragaOperacija(zahtevKlijenta);
                            break;
                        case Akcija.UCITAJ_OPERACIJU:
                            HandleUcitajOperciju(zahtevKlijenta);
                            break;
                        case Akcija.ZAPAMTI_IZVESTAJ:
                            HandleZapamtiIzvestaj(zahtevKlijenta);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Doslo je do greske na serveru.");
            }      
        }

        private void HandleZapamtiIzvestaj(TransferKlasa zahtevKlijenta)
        {
            Operacija result = null;
            Operacija operacija = (Operacija)zahtevKlijenta.TransferObjekat;
            var signalPoruka = KontrolerPL.ZapamtiIzvestaj(operacija, ref result);            

            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.ZAPAMTI_IZVESTAJ,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2,
                TransferObjekat = result
                
            };
            formater.Serialize(tok, response);
        }

        private void HandleUcitajOperciju(TransferKlasa zahtevKlijenta)
        {
            Operacija result = null;
            var signalPoruka = KontrolerPL.UcitajOperaciju((Operacija)zahtevKlijenta.TransferObjekat, ref result);

            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.UCITAJ_OPERACIJU,
                TransferObjekat = result,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2
            };
            formater.Serialize(tok, response);
        }

        private void HandlePretragaOperacija(TransferKlasa zahtevKlijenta)
        {
            Operacija op = (Operacija)zahtevKlijenta.TransferObjekat;
            List<Operacija> result = new List<Operacija>();
            var signalPoruka = KontrolerPL.PronadjiOperacije(op, ref result);
            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.PRETRAGA_OPERACIJA,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2,
                TransferObjekat = result
            };
            formater.Serialize(tok, response);
        }

        private void HandleDodajOperaciju(TransferKlasa zahtevKlijenta)
        {
            Operacija operacija = (Operacija)zahtevKlijenta.TransferObjekat;
            var signalPoruka = KontrolerPL.DodajOperaciju(operacija);
            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.DODAJ_OPERACIJU,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2
            };
            formater.Serialize(tok, response);
        }

        private void HandleVratiTimove()
        {
            List<Tim> result = new List<Tim>();
            var signalPoruka = KontrolerPL.VratiSveTimove(ref result);
            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.VRATI_TIMOVE,
                TransferObjekat = result,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2
            };
            formater.Serialize(tok, response);
        }

        private void HandleVratiSale()
        {
            List<Sala> result = new List<Sala>();
            var signalPoruka = KontrolerPL.VratiSveSale(ref result);
            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.VRATI_SALE,
                TransferObjekat = result,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2
            };
            formater.Serialize(tok, response);
        }

        private void HandleIzmeniTim(TransferKlasa zahtevKlijenta)
        {
            Tim result = null;
            var signalPoruka = KontrolerPL.IzmeniTim((Tim)zahtevKlijenta.TransferObjekat, ref result);     
            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.IZMENI_TIM,
                TransferObjekat = result,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2
            };
            formater.Serialize(tok, response);
        }

        private void HandleUcitajTim(TransferKlasa zahtevKlijenta)
        {
            Tim result = null;
            var signalPoruka = KontrolerPL.UcitajTim((Tim)zahtevKlijenta.TransferObjekat, ref result);

            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.UCITAJ_TIM,
                TransferObjekat = result,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2
            };
            formater.Serialize(tok, response);
        }

        private void HandlePretragaTimova(TransferKlasa zahtev)
        {
            Tim t = (Tim)zahtev.TransferObjekat;
            List<IOpstiDomenskiObjekat> result = new List<IOpstiDomenskiObjekat>();
            var signalPoruka = KontrolerPL.PronadjiTimove(t, ref result);

            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.PRETRAGA_TIM,
                TransferObjekat = result,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2
            };
            formater.Serialize(tok, response);
        }

        private void HandleDodajTim(TransferKlasa zahtev)
        {
            var signalPoruka = KontrolerPL.ZapamtiTim((Tim)zahtev.TransferObjekat);
            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.DODAJ_TIM,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2
            };
            formater.Serialize(tok, response);
        }

        private void HandleVratiOsoblje(TransferKlasa zahtev)
        {
            List<IOpstiDomenskiObjekat> result = new List<IOpstiDomenskiObjekat>();
            var signalPoruka = KontrolerPL.VratiSveOsoblje(ref result);

            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.VRATI_OSOBLJE,
                TransferObjekat = result,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2
            };
            formater.Serialize(tok, response);
        }

        public void HandleUcitajOsoblje(TransferKlasa zahtev)
        {
            Osoblje o = (Osoblje)zahtev.TransferObjekat;
            Osoblje ucitanoOsoblje = new Osoblje();
            var signalPoruka = KontrolerPL.UcitajOsoblje(o, ref ucitanoOsoblje);

            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.UCITAJ_OSOBLJE,
                TransferObjekat = ucitanoOsoblje,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2

            };
            formater.Serialize(tok, response);
        }

        private void HandlePretragaOsoblje(TransferKlasa zahtev)
        {
            Osoblje o = (Osoblje)zahtev.TransferObjekat;
            List<IOpstiDomenskiObjekat> result = new List<IOpstiDomenskiObjekat>();
            var signalPoruka = KontrolerPL.PronadjiOsoblje(o, ref result);

            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.PRETRAGA_OSOBLJE,
                TransferObjekat = result,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2
            };
            formater.Serialize(tok, response);
        }

        public void HandleDodajOsoblje(TransferKlasa zahtev)
        {
            Osoblje o = (Osoblje)zahtev.TransferObjekat;
            var signalPoruka = KontrolerPL.SacuvajOsoblje(o);
           
            TransferKlasa response = new TransferKlasa()
            {
                Akcija = Akcija.DODAJ_OSOBLJE,
                Signal = signalPoruka.Item1,
                Poruka = signalPoruka.Item2

            };
            formater.Serialize(tok, response);
        }

        public void PosaljiKraj()
        {
            try
            {
                TransferKlasa send = new TransferKlasa
                {
                    Akcija = Akcija.KRAJ
                };
                formater.Serialize(tok, send);
                Console.WriteLine("server poslao kraj");
            }
            catch (Exception)
            {
                Console.WriteLine("pukao server kod slanja kraja ");
            } finally
            {
                isKraj = true;
            }
            
        }

    }
}
