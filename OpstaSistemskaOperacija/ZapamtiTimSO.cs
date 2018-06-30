using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broker;
using Domen;

namespace SistemskeOperacije
{
    public class ZapamtiTimSO : OpstaSistemskaOperacija
    {
        protected override bool Izvrsi(IOpstiDomenskiObjekat odo)
        {
            try
            {
                Tim tim = (Tim)odo;
                int id = Convert.ToInt32(BrokerBP.Instance.Ubaci(tim));
                //DateTime datumPristupa = DateTime.Now;
                foreach (ClanTima clan in tim.ClanoviTima)
                {
                    clan.TimID = id;
                    //clan.DatumPristupa = datumPristupa;
                    BrokerBP.Instance.Ubaci(clan);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
