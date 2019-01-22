using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCalc
{
    public class ProductDiscountCalculator : IProductDiscountCalculator
    {
        public decimal SetDiscountBasedOnProductType(IProduct product)
        {
            if(product.GetProductType() == EProductType.Buty)
            {
                return 0.15m;
            }

            if (product.GetProductType() == EProductType.Odziez)
            {
                return 0.3m;
            }

            return 0;
        }
    }
}
