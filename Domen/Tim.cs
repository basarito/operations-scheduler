using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Tim : IOpstiDomenskiObjekat
    {
        public int TimID { get; set; }
        public string NazivTima { get; set; }
        public List<ClanTima> ClanoviTima { get; set; }

        public string VratiImeTabele()
        {
            return "Tim";
        }

        public string VratiKljucIUslov()
        {
            return $"timID = {TimID}";
        }

        public List<IOpstiDomenskiObjekat> VratiListu(OleDbDataReader citac)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();
            while (citac.Read())
            {
                Tim t = new Tim()
                {
                    TimID = Convert.ToInt32(citac["timID"]),
                    NazivTima = Convert.ToString(citac["nazivTima"])
                };
                lista.Add(t);
            }
            return lista;
        }

        public string VratiKoloneZaInsert()
        {
            return "nazivTima";
        }

        public string VratiVrednostiZaInsert()
        {
            return $"'{NazivTima}'";
        }

        public IOpstiDomenskiObjekat VratiObjekat(OleDbDataReader citac)
        {
            IOpstiDomenskiObjekat objekat = null;
            while (citac.Read())
            {
                objekat = new Tim
                {
                    TimID = Convert.ToInt32(citac["timID"]),
                    NazivTima = Convert.ToString(citac["nazivTima"]),
                    ClanoviTima = new List<ClanTima>()
                };
                break;
            }
            return objekat;
        }

        public string VratiKriterijumPretrage()
        {
            return $"nazivTima like '%{NazivTima}%'";
        }

        public override string ToString()
        {
            return $"{NazivTima}";
        }

        public string VratiZaIzmenu()
        {
            return $"nazivTima = '{NazivTima}'";
        }
    }
}
