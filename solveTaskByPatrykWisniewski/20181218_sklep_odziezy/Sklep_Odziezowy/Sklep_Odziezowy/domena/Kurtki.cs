using Sklep_Odziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Odziezowy.domena
{
    class Kurtki
    {
        public Kolor Kolor { get; set; }
        public bool PosiadaKaptur { get; set; }
        public bool WodoOdporna { get; set; }
        public bool CzySkorzana { get; set; }
        public decimal Cena { get; set; }
        public short rozmiar { get; set; }
        
    }
}
