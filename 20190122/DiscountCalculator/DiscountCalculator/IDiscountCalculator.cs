using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator
{
    public interface IDiscountCalculator
    {
        double CalculateDiscount(string productType);
    }
}
