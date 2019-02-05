using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sklepOdziezowy.Enums;


namespace sklepOdziezowy.Domena
{
    class Spodnie:Towar
    {
        public Spodnie(decimal cena, Kolory kolor, TypySpodni typ, Rozmiar rozmiar, FasonySpodni fason)
        {
            WalidujDane(cena);

            if (WalidujDane(cena))
            {
                Cena = cena;
                Kolor = kolor;
                Rozmiar = rozmiar;
                Typ = typ;
                Fason = fason;

                uzywane = false;
            }

        }
        private bool uzywane;
        public decimal Cena { get; private set; }
        public Rozmiar Rozmiar { get; private set; }
        public Kolory Kolor { get; private set; }
        public FasonySpodni Fason { get; private set; }
        public TypySpodni Typ { get; private set; }

        private bool WalidujDane(decimal cena)
        {
            return cena >= 0;
        }
    }
}
