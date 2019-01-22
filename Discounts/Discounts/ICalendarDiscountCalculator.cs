using System;
using System.Collections.Generic;
using System.Text;

namespace Discounts
{
    public interface ICalendarDiscountCalculator
    {
        decimal Calculate(string Day);
    }
}
