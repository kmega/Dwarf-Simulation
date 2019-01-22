using System;
using System.Collections.Generic;
using System.Text;

namespace MockShop
{
    public class ProductTypeDiscountCalculator : ITypeDiscountCalculator
    {
        public double Calculate(ProductType productType)
        {
            if(productType == ProductType.Clothes)
            {
                return 0.2;
            }
            if(productType == ProductType.TurtleOrthopedicShoes)
            {
                return -0.2;
            }
            return 0;
        }
    }
}
