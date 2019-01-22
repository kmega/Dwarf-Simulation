using System;
using System.Collections.Generic;
using System.Text;

namespace Discounts
{
    public interface IDiscountCalc
    {
        decimal GiveMeDiscount(string Type);
    }
}
