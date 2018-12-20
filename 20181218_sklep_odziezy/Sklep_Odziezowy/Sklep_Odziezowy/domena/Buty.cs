using Sklep_Odziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Odziezowy.domena
{
    class Buty : Towar
    {
        public decimal Cena { get; set; }
        public short rozmiar { get; set; }
        public bool Mawiazane { get; set; }
        public bool SaZapinane { get; set; }
        public Kolor Kolor { get; set; }
        public TypyButów Tyo { get; set; }
    }
}
