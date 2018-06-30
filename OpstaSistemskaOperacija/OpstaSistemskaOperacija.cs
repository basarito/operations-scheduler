using Broker;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public abstract class OpstaSistemskaOperacija
    {
        public object Rezultat { get; set; }

        public bool IzvrsiSO(IOpstiDomenskiObjekat odo)
        {
            bool rezultat = false;

            BrokerBP.Instance.OtvoriKonekciju();
            BrokerBP.Instance.PokreniTransakciju();
            rezultat = Izvrsi(odo);
            if (rezultat)
            {
                BrokerBP.Instance.Commit();
            }
            else
            {
                BrokerBP.Instance.Rollback();
            }
            BrokerBP.Instance.ZatvoriKonekciju();
            return rezultat;
        }

        protected abstract bool Izvrsi(IOpstiDomenskiObjekat odo);

    }
}
