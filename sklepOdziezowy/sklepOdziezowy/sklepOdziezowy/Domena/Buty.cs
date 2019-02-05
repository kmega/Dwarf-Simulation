using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sklepOdziezowy.Enums;

namespace sklepOdziezowy.Domena
{
    class Buty
    {
       public decimal Cena { get; set; }
       public short Rozmiar { get; set; }
       public bool MaWiazanie { get; set; }
       public bool SaZapnane { get; set; }
       public Kolory Color { get; set; }
       public TypyButow Typ { get; set; }

    }
}
