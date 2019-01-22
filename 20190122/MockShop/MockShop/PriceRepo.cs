using System;
using System.Collections.Generic;
using System.Text;

namespace MockShop
{
    public class PriceRepo : IPriceRepo
    {
        public double GetProductPrice(ProductType productType)
        {
            if(productType == ProductType.Clothes)
            {
                return 10.0;
            }
            if(productType == ProductType.TurtleOrthopedicShoes)
            {
                return 15.0;
            }
            return 0;
        }
    }
}
