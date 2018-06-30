using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broker;
using Domen;

namespace SistemskeOperacije
{
    public class PronadjiOsobljeSO : OpstaSistemskaOperacija
    {
        protected override bool Izvrsi(IOpstiDomenskiObjekat odo)
        {
            try
            {
                Rezultat = BrokerBP.Instance.VratiSveUslov(odo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
