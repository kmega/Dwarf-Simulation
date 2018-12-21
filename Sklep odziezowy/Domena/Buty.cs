using Sklep_odziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_odziezowy.Domena
{
    class Buty : Towar
    {
        public Buty()
        {

        }
        public decimal Cena { get; set; }
        public short RozmiarButow { get; set; }
        public bool MaWiazanie { get; set; }
        public bool SaZapinane { get; set; }
        public Kolor Kolor { get; set; }
        public TypButow Typ { get; set; }


    }
}
