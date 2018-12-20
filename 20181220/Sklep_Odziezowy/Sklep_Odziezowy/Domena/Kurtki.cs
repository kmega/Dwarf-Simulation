using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_Odziezowy.Enums;

namespace Sklep_Odziezowy.Domena
{
    class Kurtki
    {
        public Kolor Kolor { get; set; }
        public bool Ma_kaptur { get; set; }
        public bool Wodoodporna { get; set; }
        public bool Skorzana { get; set; }
        public decimal Cena { get; set; }
        public short Rozmiar { get; set; }
    }
}
