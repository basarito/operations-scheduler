using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class ClanTima : IOpstiDomenskiObjekat
    {
        public int OsobljeID { get; set; }
        public int TimID { get; set; }
        public bool Odgovoran { get; set; }
        public DateTime DatumPristupa { get; set; }
        public Osoblje Osoblje { get; set; }

        public string VratiImeTabele()
        {
            return "ClanTima";
        }

        public string VratiKljucIUslov()
        {
            if(OsobljeID > 0)
            {
                return $"osobljeID = {OsobljeID}";
            } else if(TimID > 0)
            {
                return $"timID = {TimID}";
            }
            return "1=1";
        }

        public List<IOpstiDomenskiObjekat> VratiListu(OleDbDataReader citac)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();
            while (citac.Read())
            {
                ClanTima clan = new ClanTima()
                {
                    TimID = Convert.ToInt32(citac["timID"]),
                    OsobljeID = Convert.ToInt32(citac["osobljeID"]),
                    Odgovoran = Convert.ToBoolean(citac["odgovoran"]),
                    DatumPristupa = Convert.ToDateTime(citac["datumPristupa"])
                };
                lista.Add(clan);
            }
            return lista;
        }

        public string VratiKoloneZaInsert()
        {
            return "osobljeID, timID, odgovoran, datumPristupa";
        }

        public string VratiVrednostiZaInsert()
        {
            return $"{OsobljeID}, {TimID}, {Odgovoran}, Now()";
        }

        public IOpstiDomenskiObjekat VratiObjekat(OleDbDataReader citac)
        {
            throw new NotImplementedException();
        }

        public string VratiKriterijumPretrage()
        {
            throw new NotImplementedException();
        }
    }
}
