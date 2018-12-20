using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy.Domena
{
    class Spodnie:Towar
    {

        public Spodnie(decimal cena, Kolor kolor, Rozmiar rozmiar, TypSpodni typ)
        {

            if (WalidujDane(cena))
            {

                Cena = cena;
                Rozmiar = rozmiar;
                Kolor = kolor;
                Typ = typ;
                uzywane = false;
            }
        

        }
        private bool uzywane;
        public decimal Cena { get; private set; }
        public Rozmiar Rozmiar { get; private set; }
        public Kolor Kolor { get; private set; }
        public TypSpodni Typ { get; private set; }
        public Fason Fason { get; private set; }

        private bool WalidujDane(decimal cena)
        {
            return cena > 0;
        }
        

    }
}
