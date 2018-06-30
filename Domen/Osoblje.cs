using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public enum Pozicija
    {
        Hirurg = 1,
        Stazista = 2,
        Sestra = 3,
        Anesteziolog = 4
    }

    [Serializable]
    public class Osoblje : IOpstiDomenskiObjekat
    {
        public int OsobljeID { get; set; }
        public string ImePrezime { get; set; }
        public string Jmbg { get; set; }
        public Pozicija Pozicija { get; set; }

        public override string ToString()
        {
            return $"{ImePrezime}, {Pozicija}";
        }

        public string VratiImeTabele()
        {
            return "Osoblje";
        }

        public string VratiKljucIUslov()
        {
            if(OsobljeID > 0)
            {
                return $"osobljeID = {OsobljeID}";
            }
            return $"jmbg = '{Jmbg}'";
        }

        public List<IOpstiDomenskiObjekat> VratiListu(OleDbDataReader citac)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();
            while (citac.Read())
            {
                Osoblje o = new Osoblje
                {
                    OsobljeID = Convert.ToInt32(citac["osobljeID"]),
                    ImePrezime = Convert.ToString(citac["imePrezime"]),
                    Jmbg = Convert.ToString(citac["jmbg"]),
                    Pozicija = (Pozicija)(Convert.ToInt32(citac["pozicija"]))
                };
                lista.Add(o);
            }
            return lista;
        }

        public IOpstiDomenskiObjekat VratiObjekat(OleDbDataReader citac)
        {
            IOpstiDomenskiObjekat objekat = null;
            while(citac.Read())
            {
                objekat = new Osoblje
                {
                    OsobljeID = Convert.ToInt32(citac["osobljeID"]),
                    ImePrezime = Convert.ToString(citac["imePrezime"]),
                    Jmbg = Convert.ToString(citac["jmbg"]),
                    Pozicija = (Pozicija)(Convert.ToInt32(citac["pozicija"]))
                };
                break;
            }
            return objekat;
        }

        public string VratiKoloneZaInsert()
        {
            return "imePrezime, jmbg, pozicija";
        }

        public string VratiVrednostiZaInsert()
        {
            return $"'{ImePrezime}', '{Jmbg}', {(int)Pozicija}";
        }

        public string VratiKriterijumPretrage()
        {
            return $"(imePrezime like '%{ImePrezime}%' OR jmbg like '{Jmbg}')";
        }
    }
}
