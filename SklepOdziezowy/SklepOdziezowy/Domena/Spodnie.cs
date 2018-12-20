using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy.Domena
{
    class Spodnie
    {
        public TypSpodni Typ { get; set; }
        public FasonSpodni Fason { get; set; }
        public Kolor Kolor { get; set; }
        public short Rozmiar { get; set; }
        public decimal Cena { get; set; }
    }
}
