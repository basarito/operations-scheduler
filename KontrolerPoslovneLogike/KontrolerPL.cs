using Domen;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolerPoslovneLogike
{
    public class KontrolerPL
    {
        public static Tuple<bool, string> SacuvajOsoblje(Osoblje o)
        {
            OpstaSistemskaOperacija ucitajOsoblje = new UcitajOsobljeSO();
            if (ucitajOsoblje.IzvrsiSO(o))
            {
                //osoblje vec postoji
                return new Tuple<bool, string>(false, "Osoblje već postoji!");
            }
            else
            {
                OpstaSistemskaOperacija zapamtiOsoblje = new ZapamtiOsobljeSO();
                bool result = zapamtiOsoblje.IzvrsiSO(o);
                if (result)
                {
                    return new Tuple<bool, string>(true, "Uspešno sačuvano medicinsko osoblje.");
                }
                else
                {
                    return new Tuple<bool, string>(false, "Sistem ne može da sačuva medicinsko osoblje.");
                }
            }

        }

        public static Tuple<bool, string> PronadjiOsoblje(Osoblje o, ref List<IOpstiDomenskiObjekat> lista)
        {
            OpstaSistemskaOperacija pronadjiOsoblje = new PronadjiOsobljeSO();
            bool result = pronadjiOsoblje.IzvrsiSO(o);
            if (result)
            {
                lista = (List<IOpstiDomenskiObjekat>)pronadjiOsoblje.Rezultat;
                if (lista.Count > 0)
                {
                    return new Tuple<bool, string>(true, "Pronađena su osoblja za zadatu vrednost.");
                }
                else
                {
                    return new Tuple<bool, string>(false, "Sistem ne može da pronađe osoblja za zadatu vrednost.");
                }
            }
            else
            {
                return new Tuple<bool, string>(false, "Sistem ne može da pronađe osoblja za zadatu vrednost.");
            }
        }

        public static Tuple<bool, string> UcitajOsoblje(Osoblje o, ref Osoblje o2)
        {
            OpstaSistemskaOperacija ucitajOsoblje = new UcitajOsobljeSO();
            var result = ucitajOsoblje.IzvrsiSO(o);
            if (result)
            {
                o2 = (Osoblje)ucitajOsoblje.Rezultat;
                return new Tuple<bool, string>(true, "Pronađeni su podaci za izabrano osoblje.");
            }
            else
            {
                return new Tuple<bool, string>(false, "Sistem ne može da pronađe podatke za dato osoblje.");
            }
        }

        public static Tuple<bool, string> VratiSveOsoblje(ref List<IOpstiDomenskiObjekat> result)
        {
            OpstaSistemskaOperacija vratiSveOsoblje = new VratiSveOsobljeSO();
            if (vratiSveOsoblje.IzvrsiSO(new Osoblje()))
            {
                result = (List<IOpstiDomenskiObjekat>)vratiSveOsoblje.Rezultat;
                return new Tuple<bool, string>(true, "Uspešno pronađena sva osoblja.");
            }
            else
            {
                return new Tuple<bool, string>(false, "Sistem ne može da vrati sva osoblja.");
            }
        }

        public static Tuple<bool, string> IzmeniTim(Tim tim, ref Tim result)
        {
            OpstaSistemskaOperacija izmeniTim = new IzmeniTimSO();
            if (izmeniTim.IzvrsiSO(tim))
            {
                OpstaSistemskaOperacija ucitajTim = new UcitajTimSO();
                if (ucitajTim.IzvrsiSO(tim))
                {
                    result = (Tim)ucitajTim.Rezultat;
                }
                return new Tuple<bool, string>(true, "Uspešno sačuvan tim.");
            }
            else
            {
                return new Tuple<bool, string>(false, "Sistem ne može da sačuva tim.");
            }
        }

        public static Tuple<bool, string> UcitajOperaciju(Operacija operacija, ref Operacija result)
        {
            OpstaSistemskaOperacija ucitajOperaciju = new UcitajOperacijuSO();
            if (ucitajOperaciju.IzvrsiSO(operacija))
            {
                if (ucitajOperaciju.Rezultat != null)
                {
                    result = (Operacija)ucitajOperaciju.Rezultat;
                    return new Tuple<bool, string>(true, "Uspešno učitana operacija.");
                }
                else
                {
                    return new Tuple<bool, string>(false, "Sistem ne može da učita operaciju.");
                }
            }
            else
            {
                return new Tuple<bool, string>(false, "Sistem ne može da učita operaciju.");
            }
        }

        public static Tuple<bool, string> ZapamtiIzvestaj(Operacija operacija, ref Operacija result)
        {
            OpstaSistemskaOperacija izmeniOperaciju = new IzmeniOperacijuSO();
            if (izmeniOperaciju.IzvrsiSO(operacija))
            {
                OpstaSistemskaOperacija ucitajOperaciju = new UcitajOperacijuSO();
                if (ucitajOperaciju.IzvrsiSO(operacija))
                {
                    result = (Operacija)ucitajOperaciju.Rezultat;
                }
                return new Tuple<bool, string>(true, "Uspešno sačuvana operacija.");
            }
            else
            {
                return new Tuple<bool, string>(false, "Sistem ne može da sačuva operaciju.");
            }
        }

        public static Tuple<bool, string> PronadjiOperacije(Operacija op, ref List<Operacija> result)
        {
            OpstaSistemskaOperacija pronadjiOperacije = new PronadjiOperacijeSO();
            if (pronadjiOperacije.IzvrsiSO(op))
            {
                var rez = (List<Operacija>)pronadjiOperacije.Rezultat;
                if (rez.Count > 0)
                {
                    result = rez;
                    return new Tuple<bool, string>(true, "Uspešno pronađene operacije za zadatu vrednost.");
                }
                else
                {
                    return new Tuple<bool, string>(false, "Sistem ne može da pronađe operacije za zadatu vrednost.");
                }

            }
            else
            {
                return new Tuple<bool, string>(false, "Sistem ne može da pronađe operacije za zadatu vrednost.");
            }
        }

        public static Tuple<bool, string> DodajOperaciju(Operacija operacija)
        {
            OpstaSistemskaOperacija dodajOperaciju = new DodajOperacijuSO();
            if (dodajOperaciju.IzvrsiSO(operacija))
            {
                return new Tuple<bool, string>(true, "Uspešno sačuvana operacija.");
            }
            else
            {
                return new Tuple<bool, string>(false, "Sistem ne može da sačuva operaciju.");
            }
        }

        public static Tuple<bool, string> VratiSveTimove(ref List<Tim> result)
        {
            OpstaSistemskaOperacija vratiSveTimove = new VratiSveTimoveSO();
            if (vratiSveTimove.IzvrsiSO(new Tim()))
            {
                var timovi = (List<IOpstiDomenskiObjekat>)vratiSveTimove.Rezultat;
                OpstaSistemskaOperacija ucitajTim = new UcitajTimSO();
                List<Tim> konacan = new List<Tim>();
                foreach (var tim in timovi)
                {
                    if (ucitajTim.IzvrsiSO(tim))
                    {
                        konacan.Add((Tim)ucitajTim.Rezultat);
                    }
                    else
                    {
                        return new Tuple<bool, string>(true, "Sistem ne moze da ucita sve timove.");
                    }
                }
                result = konacan;
                return new Tuple<bool, string>(true, "Uspesno ucitane sve timove.");
            }
            else
            {
                return new Tuple<bool, string>(true, "Sistem ne moze da ucita sve timove.");
            }
        }

        public static Tuple<bool, string> VratiSveSale(ref List<Sala> result)
        {
            OpstaSistemskaOperacija vratiSveSale = new VratiSveSaleSO();
            if (vratiSveSale.IzvrsiSO(new Sala()))
            {
                var rez = (List<IOpstiDomenskiObjekat>)vratiSveSale.Rezultat;
                List<Sala> sale = new List<Sala>();
                foreach (var r in rez)
                {
                    sale.Add((Sala)r);
                }
                result = sale;
                return new Tuple<bool, string>(true, "Uspesno ucitane sve sale.");
            }
            else
            {
                return new Tuple<bool, string>(true, "Sistem ne moze da ucita sve sale.");
            }
        }

        public static Tuple<bool, string> UcitajTim(Tim tim, ref Tim result)
        {
            OpstaSistemskaOperacija ucitajTim = new UcitajTimSO();
            if (ucitajTim.IzvrsiSO(tim))
            {
                result = (Tim)ucitajTim.Rezultat;
                return new Tuple<bool, string>(true, "Uspešno učitan tim.");

            }
            else
            {
                return new Tuple<bool, string>(false, "Sistem ne može da učita tim.");
            }

        }

        public static Tuple<bool, string> PronadjiTimove(Tim t, ref List<IOpstiDomenskiObjekat> result)
        {
            OpstaSistemskaOperacija pronadjiTimove = new PronadjiTimoveSO();
            if (pronadjiTimove.IzvrsiSO(t))
            {
                result = (List<IOpstiDomenskiObjekat>)pronadjiTimove.Rezultat;
                if (result.Count > 0)
                {
                    return new Tuple<bool, string>(true, "Pronađeni su timovi za zadatu vrednost.");
                }
                else
                {
                    return new Tuple<bool, string>(false, "Sistem ne može da pronađe timove za zadatu vrednost.");
                }
            }
            else
            {
                return new Tuple<bool, string>(false, "Sistem ne može da pronađe timove za zadatu vrednost.");
            }
        }

        public static Tuple<bool, string> ZapamtiTim(Tim tim)
        {
            OpstaSistemskaOperacija ucitajTim = new UcitajTimSO();
            if (ucitajTim.IzvrsiSO(tim))
            {
                //tim vec postoji
                return new Tuple<bool, string>(false, "Tim već postoji!");
            }
            else
            {
                OpstaSistemskaOperacija zapamtiTim = new ZapamtiTimSO();
                bool result = zapamtiTim.IzvrsiSO(tim);
                if (result)
                {
                    return new Tuple<bool, string>(true, "Uspešno sačuvan tim.");
                }
                else
                {
                    return new Tuple<bool, string>(false, "Sistem ne može da sačuva tim.");
                }
            }
        }
    }
}
