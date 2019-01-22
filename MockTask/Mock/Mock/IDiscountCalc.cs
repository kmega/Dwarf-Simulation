using System;
using System.Collections.Generic;
using System.Text;

namespace Mock
{
    public interface IDiscountCalc
    {
        decimal GiveDiscount(string type);
    }
}
