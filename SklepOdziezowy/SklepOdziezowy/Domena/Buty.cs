using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy.Domena
{
    class Buty : Towar
    {
        public decimal Cena { get; set; }
        public short Rozmiar { get; set; }
        public bool MaWiazanie { get; set; }
        public bool SaZapisane { get; set; }
        public Kolor Kolor { get; set; }
        public TypButow Typ { get; set; }

    }
}
