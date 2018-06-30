using Broker;
using Domen;
using SistemskeOperacije;
using System;

namespace KontrolerPoslovneLogike
{
    public class PronadjiTimoveSO : OpstaSistemskaOperacija
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