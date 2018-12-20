using System;
using SklepOdziezowy.Enum;

namespace SklepOdziezowy.Domena
{
    class Spodnie
    {
        public decimal Cena { get; set; }
        public short Rozmiar { get; set; }
        public FasonSpodni Fason { get; set; }
        public Color Color { get; set; }
        public RodzajeSpodni Typ { get; set; }
    }
}
