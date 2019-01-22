using System;
using System.Collections.Generic;
using System.Text;

namespace ShopForLearnMock
{
   public  class DiscountCalc : IDiscountCalculator
    {
        public double CalcDiscount(Product product)
        {

            if (product.Type == ProductType.Clothes)
            {
                return 0.3;

            }
            else if (product.Type == ProductType.TortoiseShoes)
            {
                return -0.2;
            }
            return 0;


        }
    }
}
