using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    public interface ICalendarDiscountCalculator
    {
        double Calculate(DateTime date);
    }
}
