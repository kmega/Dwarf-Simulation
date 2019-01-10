using Sklep_Odziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Odziezowy.domena
{
    class Spodnie : Towar
    {
        public Spodnie(decimal cena, Kolor kolor, TypSpodni typ, RozmiarSpodni rozmiar)
        {
            if (WalidujDane(cena))
            {
                Cena = cena;
                Kolor = Kolor;
                rozmiar = RozmiarSpodni;
                typ = TypSpodni;
            }

        }
        public TypSpodni TypSpodni { get;  private set; }
        public Fason Fason { get; private set; }
        public Kolor Kolor { get; private set; }
        public RozmiarSpodni RozmiarSpodni { get; private set; }
        public decimal Cena { get; private set; }

        private bool WalidujDane(decimal cena)
        {
            return cena > 0;
        }
    }
}
