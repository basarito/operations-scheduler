using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Sala : IOpstiDomenskiObjekat
    {
        public int SalaID { get; set; }
        public string NazivSale { get; set; }
        public int Sprat { get; set; }

        public string VratiImeTabele()
        {
            return "Sala";
        }

        public string VratiKljucIUslov()
        {
            throw new NotImplementedException();
        }

        public List<IOpstiDomenskiObjekat> VratiListu(OleDbDataReader citac)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();
            while (citac.Read())
            {
                Sala s = new Sala()
                {
                    SalaID = Convert.ToInt32(citac["salaID"]),
                    NazivSale = Convert.ToString(citac["nazivSale"]),
                    Sprat = Convert.ToInt32(citac["sprat"])
                };               
                lista.Add(s);
            }
            return lista;
        }

        public string VratiKoloneZaInsert()
        {
            return "nazivSale, sprat";
        }

        public string VratiVrednostiZaInsert()
        {
            return $"'{NazivSale}', {Sprat}";
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

        public override string ToString()
        {
            return NazivSale;
        }
    }
}
