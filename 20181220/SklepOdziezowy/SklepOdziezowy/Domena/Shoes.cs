using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SklepOdziezowy.Enums;
namespace SklepOdziezowy.Domena
{
    class Shoes : Product
    {
        public ShoesType shoesType { get; private set; }
        public short shoeSize { get; private set; }
        public Color color { get; private set; }
        public bool isLaceUp { get; private set; }
        public bool isButtonUp { get; private set; }
        public Shoes(ShoesType shoesType,short shoeSize,decimal price, Color color,bool isLaceUp,bool isButtonUp)
        {
            this.shoesType = shoesType;
            this.shoeSize = shoeSize;
            this.price = price;
            this.color = color;
            this.isLaceUp = isLaceUp;
            this.isButtonUp = isButtonUp;
        }
    }
}
