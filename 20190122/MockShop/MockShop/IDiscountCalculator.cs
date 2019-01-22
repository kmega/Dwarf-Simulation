using System;
using System.Collections.Generic;
using System.Text;

namespace MockShop
{
    public interface IDiscountCalculator
    {
        double Calculate(ProductType productType);
    }
}
