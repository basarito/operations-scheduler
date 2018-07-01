using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broker;
using Domen;

namespace SistemskeOperacije
{
    public class DodajOperacijuSO : OpstaSistemskaOperacija
    {
        protected override bool Izvrsi(IOpstiDomenskiObjekat odo)
        {
            try
            {
                var result = BrokerBP.Instance.VratiSveUslov(odo);
                if (result.Count == 0)
                {
                    BrokerBP.Instance.Ubaci(odo);
                    return true;
                }
                else
                {
                    Operacija novaOp = (Operacija)odo;
                    foreach (var r in result)
                    {
                        Operacija op = (Operacija)r;
                        if ((op.TerminOd <= novaOp.TerminDo && op.TerminDo >= novaOp.TerminOd) ||
                            (op.TerminOd >= novaOp.TerminDo && op.TerminDo <= novaOp.TerminOd) )
                        {
                            if (op.SalaID == novaOp.SalaID && op.TimID == novaOp.TimID)
                            {
                                throw new Exception("Operacija je vec zakazana!");
                            } else if (op.TimID == novaOp.TimID)
                            {
                                throw new Exception("Tim je zauzet!");
                            } else if (op.SalaID == novaOp.SalaID)
                            {
                                throw new Exception("Sala je zauzeta!");
                            }
                        }
                    }
                    BrokerBP.Instance.Ubaci(odo);
                    return true;

                }
                
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
