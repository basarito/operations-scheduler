using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broker;
using Domen;

namespace SistemskeOperacije
{
    public class IzmeniTimSO : OpstaSistemskaOperacija
    {
        protected override bool Izvrsi(IOpstiDomenskiObjekat odo)
        {
            try
            {
                Tim dobijeniTim = (Tim)odo;
                Rezultat = BrokerBP.Instance.VratiPrvog(dobijeniTim);
                if (Rezultat == null)
                {
                    return false;
                }
                else
                {
                    Tim ucitaniTim = (Tim)Rezultat;

                    List<ClanTima> clanovi = new List<ClanTima>();
                    ClanTima c = new ClanTima() { TimID = dobijeniTim.TimID };
                    var result = BrokerBP.Instance.VratiSveUslov(c);
                    if (result.Count > 0)
                    {
                        foreach (var r in result)
                        {
                            c = (ClanTima)r;
                            Osoblje o = new Osoblje() { OsobljeID = c.OsobljeID };
                            var result2 = BrokerBP.Instance.VratiPrvog(o);
                            if (result2 != null)
                            {
                                c.Osoblje = (Osoblje)result2;
                                clanovi.Add(c);
                            }
                            else
                            {
                                throw new Exception();
                            }

                        }
                    }
                    ucitaniTim.ClanoviTima = clanovi;

                    List<ClanTima> istiClanovi = ucitaniTim.ClanoviTima.Intersect(dobijeniTim.ClanoviTima).ToList();                
                    List<ClanTima> noviClanovi = dobijeniTim.ClanoviTima.Except(istiClanovi).ToList();
                    List<ClanTima> brisanjeClanovi = ucitaniTim.ClanoviTima.Except(istiClanovi).ToList();

                    //update samog tima
                    BrokerBP.Instance.Izmeni(dobijeniTim);

                    //dodavanje novih clanova
                    foreach (ClanTima clan in noviClanovi)
                    {
                        //clan.TimID = dobijeniTim.TimID;
                        BrokerBP.Instance.Ubaci(clan);
                    }

                    //brisanje starih clanova
                    foreach(ClanTima clan in brisanjeClanovi)
                    {
                        BrokerBP.Instance.Obrisi(clan);
                    }

                    return true;
                }
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
