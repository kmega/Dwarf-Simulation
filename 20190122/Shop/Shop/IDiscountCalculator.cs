using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    public interface IDiscountCalculator
    {
        double Calculate(ProductType type);
    }
}
