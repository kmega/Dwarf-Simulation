using System;
using System.Collections.Generic;
using System.Text;

namespace ShopForLearnMock
{
    public class CalendarDiscount : ICalendarDiscountCalculator
    {

       

        public double CalcDiscountDate(DateTime date)
        {
            if (date.Month==12 && date.Day>=19 && date.Day <= 24)
            {
                return 0.2;

            }
            else if (date.Month==11 && date.Day>22 && date.DayOfWeek == DayOfWeek.Friday)
            {
                return 0.5;

            }
            else
            {
                return 0;
            }
        }
    }
}
