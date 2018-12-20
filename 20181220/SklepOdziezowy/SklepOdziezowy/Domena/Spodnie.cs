using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy.Domena
{
    class Spodnie
    {

        public decimal Cena { get; set; }
        public short Rozmiar { get; set; }
        public Kolor Kolor { get; set; }
        public TypSpodni Typ { get; set;}
        public Fason Fason { get; set; } 

    }
}
