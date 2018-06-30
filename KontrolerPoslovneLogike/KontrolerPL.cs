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
            if(ucitajOsoblje.IzvrsiSO(o))
            {
                //osoblje vec postoji
                return new Tuple<bool, string>(false, "Osoblje već postoji!");
            } else
            {
                OpstaSistemskaOperacija zapamtiOsoblje = new ZapamtiOsobljeSO();
                bool result = zapamtiOsoblje.IzvrsiSO(o);
                if(result)
                {
                    return new Tuple<bool, string>(true, "Uspešno sačuvano medicinsko osoblje.");
                } else
                {
                    return new Tuple<bool, string>(false, "Sistem ne može da sačuva medicinsko osoblje.");
                }
            }
            
        }

        public static Tuple<bool, string> PronadjiOsoblje(Osoblje o, ref List<IOpstiDomenskiObjekat> lista)
        {
            OpstaSistemskaOperacija pronadjiOsoblje = new PronadjiOsobljeSO();
            bool result = pronadjiOsoblje.IzvrsiSO(o);
            if(result)
            {
                lista = (List<IOpstiDomenskiObjekat>)pronadjiOsoblje.Rezultat;
                if(lista.Count > 0)
                {
                    return new Tuple<bool, string>(true, "Pronađena su osoblja za zadatu vrednost.");
                } else
                {
                    return new Tuple<bool, string>(false, "Sistem ne može da pronađe osoblja za zadatu vrednost.");
                }
            } else
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
            if( vratiSveOsoblje.IzvrsiSO(new Osoblje()) )
            {
                result = (List<IOpstiDomenskiObjekat>)vratiSveOsoblje.Rezultat;
                return new Tuple<bool, string>(true, "Uspešno pronađena sva osoblja.");
            } else
            {
                return new Tuple<bool, string>(false, "Sistem ne može da vrati sva osoblja.");
            }
        }

        public static Tuple<bool, string> UcitajTim(Tim tim, ref Tim result)
        {
            OpstaSistemskaOperacija ucitajTim = new UcitajTimSO();
            if(ucitajTim.IzvrsiSO(tim))
            {
                result = (Tim)ucitajTim.Rezultat;
                return new Tuple<bool, string>(true, "Uspešno učitan tim.");

            } else
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
