using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy.Domena
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
        //getter -> uzyskanie wartosci pola, setter -> nadanie wartosci pola
        public TypSpodni Typ { get; private set; }
        public FasonSpodni Fason { get; private set; }
        public Kolor Kolor { get; private set; }
        public RozmiarSpodni Rozmiar { get; private set; } 
        public decimal Cena { get; private set; }
        /* inny sposob dodania wlasciwosci to np: */
        private bool uzywane;
        public bool Uzywane => uzywane;

        private bool WalidujDane(decimal cena)
        {
            return cena > 0;
        }
        
    }
}
