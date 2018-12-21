using System;
using SklepOdziezowy.Enum;

namespace SklepOdziezowy.Domena
{
    class Spodnie : Towar //wskazujemy ze dziedziczymy po TOWAR
    {
        public Spodnie(decimal cena, Color color, RozmiarSpodni rozmiar, FasonSpodni fason)
        {
            if(WalidujDane(cena))
            {
                Cena = cena;
                Color = color;
                Rozmiar = rozmiar;
                Fason = fason;

                uzywane = false;
            }
        }

        private bool WalidujDane(decimal cena)
        {
            return cena > 0;
        }

        private bool uzywane;
        public decimal Cena { get; private set; }
        public RozmiarSpodni Rozmiar { get; private set; }
        public FasonSpodni Fason { get; private set; }
        public Color Color { get; private set; }
        //public bool Uzywane => uzywane; //pole
    }
}
