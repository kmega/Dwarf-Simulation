using SklepOdziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepOdziezowy.Domena
{
    class Pants : Cargo
    {
        public Pants(decimal price, EuropeanSize size, Colour colour, 
                     PantsType type, PantsStyling styling)
        {
            if(ValidateData(price))
            {
                Price = price;
                Size = size;
                Colour = colour;
                Type = type;
                Styling = styling;
                Used = false;
            }      
        }

        private bool Used;
        public decimal Price { get; private set; }
        public EuropeanSize Size { get; private set; }
        public Colour Colour { get; private set; }
        public PantsType Type { get; private set; }
        public PantsStyling Styling { get; private set; }

        private bool ValidateData(decimal price)
        {
            return price >= 0;
        }
    }
}
