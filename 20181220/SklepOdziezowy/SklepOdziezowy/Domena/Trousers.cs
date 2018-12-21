using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SklepOdziezowy.Enums;
using SklepOdziezowy.Domena;
namespace SklepOdziezowy
{
    class Trousers : Product
    {
        public TrousersType trousersType { get; private set; }
        public FashionTrousers fashionTrousers { get; private set; }
        public Color color { get; private set; }
        public Size size { get; private set; }
        public decimal price { get; private set; }
        public Trousers(TrousersType trousersType, decimal price,FashionTrousers fashionTrousers,Color color,Size size)
        {
            this.trousersType = trousersType;
            this.fashionTrousers = fashionTrousers;
            this.color = color;
            this.size = size;
            this.price = price;
        }
    }
}
