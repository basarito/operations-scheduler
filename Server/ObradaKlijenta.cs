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
                    //TransferKlasa odgovor = new TransferKlasa();
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
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Server down.");
            }      
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
            TransferKlasa send = new TransferKlasa
            {
                Akcija = Akcija.KRAJ
            };
            formater.Serialize(tok, send);
            Console.WriteLine("server poslao kraj");
            try
            {

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
