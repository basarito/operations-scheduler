using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class ClanTima : IOpstiDomenskiObjekat
    {
        [Browsable(false)]
        public int OsobljeID { get; set; }
        [Browsable(false)]
        public int TimID { get; set; }
        public bool Odgovoran { get; set; }
        [Browsable(false)]
        public Osoblje Osoblje { get; set; }

        [DisplayName("Ime i prezime")]
        public string ImePrezimeOsoblja
        {
            get { return Osoblje.ImePrezime; }
        }

        [DisplayName("Pozicija")]
        public string PozicijaOsoblja
        {
            get { return Osoblje.Pozicija.ToString(); }
        }

        [DisplayName("Datum pristupa")]
        public DateTime DatumPristupa { get; set; }

        public string VratiImeTabele()
        {
            return "ClanTima";
        }

        public string VratiKljucIUslov()
        {

            return $"osobljeID = {OsobljeID} AND timID = {TimID}";

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
            if(OsobljeID > 0)
            {
                return $"osobljeID = {OsobljeID}";
            } else if(TimID > 0)
            {
                return $"timID = {TimID}";
            } else
            {
                return "1 = 1";
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ClanTima clan = obj as ClanTima;

            return clan.OsobljeID == this.OsobljeID && clan.TimID == this.TimID;
        }

        public override int GetHashCode()
        {
            return OsobljeID.GetHashCode() + TimID.GetHashCode();
        }

        public string VratiZaIzmenu()
        {
            throw new NotImplementedException();
        }
    }
}
