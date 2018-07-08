using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public enum Status
    {
        Zakazana = 1,
        Odrzana = 2,
        Otkazana = 3
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
        public DateTime? IzvestajDatum { get; set; }

        public Sala Sala { get; set; }
        public Tim Tim { get; set; }

        [DisplayName("Termin od")]
        public string TerminOdFormat => String.Format("{0:d. MMMM yyyy. HH:mm}h", TerminOd);

        [DisplayName("Termin do")]
        public string TerminDoFormat => String.Format("{0:d. MMMM yyyy. HH:mm}h", TerminDo);

        private string format = "dd/MM/yyyy HH:mm";

        public string VratiImeTabele()
        {
            return "Operacija";
        }

        public string VratiKljucIUslov()
        {
            return $"operacijaID = {OperacijaID}";
        }

        public List<IOpstiDomenskiObjekat> VratiListu(OleDbDataReader citac)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();
            while (citac.Read())
            {
                dynamic datum = null;
                if(citac["izvestajDatum"] != DBNull.Value)
                {
                    datum = Convert.ToDateTime(citac["izvestajDatum"]);
                } 
                Operacija o = new Operacija()
                {
                    OperacijaID = Convert.ToInt32(citac["operacijaID"]),
                    SalaID = Convert.ToInt32(citac["salaID"]),
                    TimID = Convert.ToInt32(citac["timID"]),
                    Status = (Status)(Convert.ToInt32(citac["status"])),
                    TerminOd = Convert.ToDateTime(citac["terminOd"]),
                    TerminDo = Convert.ToDateTime(citac["terminDo"]),
                    IzvestajOpis = Convert.ToString(citac["izvestajOpis"]),
                    IzvestajDatum = datum
                };
                lista.Add(o);
            }
            return lista;
        }

        public string VratiKoloneZaInsert()
        {
            return "timID, salaID, terminOd, terminDo, status, izvestajOpis, izvestajDatum";
        }

        public string VratiVrednostiZaInsert()
        {
            return $"{TimID}, {SalaID},'{TerminOd.ToString(format)}', '{TerminDo.ToString(format)}', {(int)Status}, '', null";
        }

        public IOpstiDomenskiObjekat VratiObjekat(OleDbDataReader citac)
        {
            IOpstiDomenskiObjekat objekat = null;
            while (citac.Read())
            {
                dynamic datum = null;
                if (citac["izvestajDatum"] != DBNull.Value)
                {
                    datum = Convert.ToDateTime(citac["izvestajDatum"]);
                }
                Operacija o = new Operacija()
                {
                    OperacijaID = Convert.ToInt32(citac["operacijaID"]),
                    SalaID = Convert.ToInt32(citac["salaID"]),
                    TimID = Convert.ToInt32(citac["timID"]),
                    Status = (Status)(Convert.ToInt32(citac["status"])),
                    TerminOd = Convert.ToDateTime(citac["terminOd"]),
                    TerminDo = Convert.ToDateTime(citac["terminDo"]),
                    IzvestajOpis = Convert.ToString(citac["izvestajOpis"]),
                    IzvestajDatum = datum
                };
                objekat = o;
            }
            return objekat;
        }

        public string VratiKriterijumPretrage()
        {
            if(SalaID == 0 && TimID == 0)
            {
                int year = TerminOd.Year;
                int month = TerminOd.Month;
                int day = TerminOd.Day;

                return $"Year(terminOd)={year} AND Month(terminOd)={month} AND Day(terminOd)={day}";
            } else
            {
                return $"salaID = {SalaID} OR timID = {TimID}";
            }
            
        }

        public string VratiZaIzmenu()
        {
            if(!string.IsNullOrWhiteSpace(IzvestajOpis))
            {
                return $"izvestajOpis = '{IzvestajOpis}', izvestajDatum = Date()";
            } else
            {
                //todo
                return "";
            }
        }
    }
}
