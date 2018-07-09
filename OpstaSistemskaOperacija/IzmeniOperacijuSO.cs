using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broker;
using Domen;

namespace SistemskeOperacije
{
    public class IzmeniOperacijuSO : OpstaSistemskaOperacija
    {
        protected override bool Izvrsi(IOpstiDomenskiObjekat odo)
        {
            try
            {
                var rez = (Operacija)BrokerBP.Instance.VratiPrvog(odo);
                if (rez != null)
                {
                    Sala sala = (Sala)BrokerBP.Instance.VratiPrvog(new Sala()
                    {
                        SalaID = rez.SalaID
                    });
                    rez.Sala = sala ?? throw new Exception();

                    //unos izvestaja 
                    //if(!string.IsNullOrWhiteSpace(((Operacija)odo).IzvestajOpis))
                    //{
                    //    BrokerBP.Instance.Izmeni((Operacija)odo);
                    //} else
                    //{
                    //    //update cele operacije
                    //BrokerBP.Instance.Izmeni((Operacija)odo);
                    //}

                    BrokerBP.Instance.Izmeni((Operacija)odo);

                    Rezultat = rez;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
