using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broker;
using Domen;

namespace SistemskeOperacije
{
    public class UcitajTimSO : OpstaSistemskaOperacija
    {
        protected override bool Izvrsi(IOpstiDomenskiObjekat odo)
        {
            try
            {
                Tim tim = (Tim)odo;
                Rezultat = BrokerBP.Instance.VratiPrvog(tim);
                if(Rezultat == null)
                {
                    return false;
                } else
                {
                    tim = (Tim)Rezultat;
                    List<ClanTima> clanovi = new List<ClanTima>();
                    ClanTima c = new ClanTima() { TimID = tim.TimID };
                    var result = BrokerBP.Instance.VratiSveUslov(c);
                    if(result.Count > 0)
                    {
                        foreach(var r in result)
                        {
                            c = (ClanTima)r;
                            Osoblje o = new Osoblje() { OsobljeID = c.OsobljeID };
                            var result2 = BrokerBP.Instance.VratiPrvog(o);
                            if(result2 != null)
                            {
                                c.Osoblje = (Osoblje)result2;
                                clanovi.Add(c);
                            } else
                            {
                                throw new Exception();
                            }
                            
                        }                        
                    }
                    tim.ClanoviTima = clanovi;
                    Rezultat = tim;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
