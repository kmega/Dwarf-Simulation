using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_Odziezowy.Enums;

namespace Sklep_Odziezowy.Domena
{
    class Buty : Towar
    {
        public decimal Cena {get; set;}
        public short Rozmiar { get; set; }
        public bool Ma_wiazania { get; set; }
        public bool Sa_Zapinane { get; set; }
        public Kolor Kolor { get; set; }
        public Typ_Butow Typ { get; set; }

    }
}
