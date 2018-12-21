using Sklep_odziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_odziezowy.Domena
{
    class Spodnie : Towar
    {
        public Spodnie(decimal cena, Kolor kolor, TypSpodni typ, RozmiarSpodni rozmiar)
        {

            if (WalidujDane(cena))
            {
                Cena = cena;
                Kolor = kolor;
                Typ = typ;
                Rozmiar = rozmiar;

                uzywane = false;
            }

        }
        private bool uzywane;
        public TypSpodni Typ { get; private set; }
        public FasonSpodni Fason { get; private set; }
        public Kolor Kolor { get; private set; }
        public RozmiarSpodni Rozmiar { get; private set; }
        public decimal Cena { get; private set; }

        private bool WalidujDane(decimal cena)
        {
            return cena > 0;
        }
    }
}
