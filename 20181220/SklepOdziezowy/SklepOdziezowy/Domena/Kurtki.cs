using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy.Domena
{
    class Kurtki :Towar
    {


        public decimal Cena { get; set; }
        public short Rozmiar { get; set; }
        public bool MaKaptur { get; set; }
        public bool Wodoodprona { get; set; }
        public bool Skorzana { get; set; }
        public Kolor Kolor { get; set; }
       
    }
}
