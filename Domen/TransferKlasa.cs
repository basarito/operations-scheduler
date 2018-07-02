using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class TransferKlasa
    {
        public Akcija Akcija { get; set; }
        public object TransferObjekat { get; set; }
        public bool Signal { get; set; }
        public string Poruka { get; set; }
    }

    public enum Akcija
    {
        KRAJ,
        DODAJ_OSOBLJE,
        PRETRAGA_OSOBLJE,
        UCITAJ_OSOBLJE,
        VRATI_OSOBLJE,
        DODAJ_TIM,
        PRETRAGA_TIM,
        UCITAJ_TIM,
        IZMENI_TIM,
        VRATI_SALE,
        VRATI_TIMOVE,
        DODAJ_OPERACIJU,
        PRETRAGA_OPERACIJA,
        UCITAJ_OPERACIJU
    }
}
