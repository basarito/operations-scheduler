using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broker;
using Domen;

namespace SistemskeOperacije
{
    public class UcitajOperacijuSO : OpstaSistemskaOperacija
    {
        protected override bool Izvrsi(IOpstiDomenskiObjekat odo)
        {
            try
            {
                var rez = (Operacija)BrokerBP.Instance.VratiPrvog(odo);
                if(rez != null)
                {
                    Sala sala = (Sala)BrokerBP.Instance.VratiPrvog(new Sala()
                    {
                        SalaID = rez.SalaID
                    });
                    rez.Sala = sala ?? throw new Exception();
                    Rezultat = rez;
                    return true;
                } else
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
