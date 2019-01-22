using System;
using System.Collections.Generic;
using System.Text;

namespace Mock
{
    public interface ICalendarDiscountCalculator
    {
        decimal GiveDiscount(DateTime date);
    }
}
