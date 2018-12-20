using SklepOdziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepOdziezowy.Domena
{
    public class Pants
    {
        public decimal Price { get; set; }
        public EuropeanSize Size { get; set; }
        public Colour Colour { get; set; }
        public PantsType PantsType { get; set; }
        public PantsStyling PantsStyling { get; set; }
    }
}
