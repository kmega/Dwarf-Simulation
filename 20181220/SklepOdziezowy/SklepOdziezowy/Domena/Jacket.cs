using SklepOdziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepOdziezowy.Domena
{
    class Jacket : Cargo
    {
        public decimal Price { get; set; }
        public EuropeanSize Size { get; set; }
        public Colour Colour { get; set; }
        public bool HasHood { get; set; }
        public bool IsWaterproof { get; set; }
        public bool IsLeather { get; set; }
    }
}
