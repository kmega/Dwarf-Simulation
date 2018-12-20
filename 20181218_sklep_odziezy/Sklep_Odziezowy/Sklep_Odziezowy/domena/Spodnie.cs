using Sklep_Odziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Odziezowy.domena
{
    class Spodnie
    {
        public TypSpodni TypSpodni { get; set; }
        public Fason Fason { get; set; }
        public Kolor Kolor { get; set; }
        public short rozmiar { get; set; }
        public decimal Cena { get; set; }
    }
}
