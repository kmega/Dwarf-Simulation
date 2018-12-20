using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy.Domena
{
    class Buty
    {

        public decimal Cena { get; set; }
        public short Rozmiar { get; set; }
        public bool MaWiazania { get; set; }
        public bool SaZapinane { get; set; }
        public Kolor Kolor  { get; set; }
        public TypButow Typ { get; set; }



    }
}
