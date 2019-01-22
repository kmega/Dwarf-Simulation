using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCalc
{
    public class CalendarDiscountCalculator : ICalendarDiscountCalculator
    {
        public decimal SetDiscountBasedOnCurrentDate()
        {
            DateTime currentDate = DateTime.Now;

            if(currentDate.Month == 11 && currentDate.Day == 29)
            {
                return 0.5m;
            }

            if(currentDate.Day >= 19 && currentDate.Day <= 24 && currentDate.Month == 12)
            {
                return 0.2m;
            }

            return 0m;
        }
    }
}
