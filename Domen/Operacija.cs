using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public enum Status
    {
        Zakazana = 1,
        Otkazana = 2,
        Odrzana = 3
    }

    [Serializable]
    public class Operacija : IOpstiDomenskiObjekat
    {
        public int OperacijaID { get; set; }
        public int TimID { get; set; }
        public int SalaID { get; set; }
        public DateTime TerminOd { get; set; }
        public DateTime TerminDo { get; set; }
        public Status Status { get; set; }
        public string IzvestajOpis { get; set; }
        public DateTime IzvestajDatum { get; set; }

        public string VratiImeTabele()
        {
            return "Operacija";
        }

        public string VratiKljucIUslov()
        {
            throw new NotImplementedException();
        }

        public List<IOpstiDomenskiObjekat> VratiListu(OleDbDataReader citac)
        {
            throw new NotImplementedException();
        }

        public string VratiKoloneZaInsert()
        {
            return "timID, salaID, terminOd, terminDo, status, izvestajOpis, izvestajDatum";
        }

        public string VratiVrednostiZaInsert()
        {
            return $"{TimID}, {SalaID}, '{TerminOd}', '{TerminDo}', {(int)Status}, '{IzvestajOpis}', '{IzvestajDatum}'";
        }

        public IOpstiDomenskiObjekat VratiObjekat(OleDbDataReader citac)
        {
            throw new NotImplementedException();
        }

        public string VratiKriterijumPretrage()
        {
            throw new NotImplementedException();
        }

        public string VratiZaIzmenu()
        {
            throw new NotImplementedException();
        }
    }
}
