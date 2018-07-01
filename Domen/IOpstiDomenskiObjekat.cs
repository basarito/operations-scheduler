using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IOpstiDomenskiObjekat
    {
        string VratiImeTabele();
        string VratiKljucIUslov();
        string VratiKoloneZaInsert();
        string VratiVrednostiZaInsert();
        string VratiKriterijumPretrage();
        string VratiZaIzmenu();
        List<IOpstiDomenskiObjekat> VratiListu(OleDbDataReader citac);
        IOpstiDomenskiObjekat VratiObjekat(OleDbDataReader citac);
    }
}
