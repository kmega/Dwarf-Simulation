using SklepOdziezowy.Enum;

namespace SklepOdziezowy.Domena
{
    class Buty
    {
        public decimal Cena { get; set; }
        public short Rozmiar { get; set; }
        public bool MaWiazanie { get; set; }
        public bool SaZapinane { get; set; }
        public Color Color { get; set; }
        public RodzajeButow Typ { get; set; }
    }
}
