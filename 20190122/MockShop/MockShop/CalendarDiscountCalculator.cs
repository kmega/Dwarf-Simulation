using System;
using System.Collections.Generic;
using System.Text;

namespace MockShop
{
    public class CalendarDiscountCalculator : ICalendarDiscountCalculator
    {
        private IDateProvider dateProvider;
        public CalendarDiscountCalculator(IDateProvider dP)
        {
            dateProvider = dP;
        }
        public double Calculate()
        {
            var now = dateProvider.Now();
            if (now.Month == 12)
            {
                if (now.Day >= 19 && now.Day <= 23)
                {
                    return 0.2;
                }
            }
            if(now.Month == 11 && now.Day == 29)
            {
                return 0.5;
            }
            return 0;
        }
    }
}
