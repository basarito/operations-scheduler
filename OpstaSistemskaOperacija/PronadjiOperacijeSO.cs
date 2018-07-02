using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broker;
using Domen;

namespace SistemskeOperacije
{
    public class PronadjiOperacijeSO : OpstaSistemskaOperacija
    {
        protected override bool Izvrsi(IOpstiDomenskiObjekat odo)
        {
            try
            {
                var rez = BrokerBP.Instance.VratiSveUslov(odo);
                if(rez.Count > 0)
                {
                    List<Operacija> operacije = new List<Operacija>();
                    foreach(var r in rez)
                    {
                        Operacija o = (Operacija)r;
                        var sala = BrokerBP.Instance.VratiPrvog(new Sala()
                        {
                            SalaID = (o).SalaID
                        });
                        if(sala == null)
                        {
                            throw new Exception();
                        }
                        o.Sala = (Sala)sala;
                        operacije.Add(o);
                    }
                    Rezultat = operacije;
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
