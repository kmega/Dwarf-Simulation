using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator
{
    public interface ICalendarDiscountCalculator
    {
        double CalculateDiscount(DateTime date);
    }
}
