using System;
using System.Collections.Generic;
using System.Text;

namespace MockShop
{
    public interface ITypeDiscountCalculator
    {
        double Calculate(ProductType productType);
    }
}
