using SklepOdziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepOdziezowy.Domena
{
    public class Shoes
    {
        public decimal Price { get; set; }
        public short Size { get; set; }
        public bool HasKnots { get; set; }
        public bool HasVelcro { get; set; }
        public Colour Colour { get; set; }
        public ShoeType ShoeType { get; set; }
    }
}
