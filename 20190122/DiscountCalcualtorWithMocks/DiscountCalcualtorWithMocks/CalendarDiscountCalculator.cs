using System;
namespace DiscountCalcualtorWithMocks
{
    public class CalendarDiscountCalculator : ICalendarDiscountCalculator
    {
        public decimal SetDiscountByDate()
        {
            var date = DateTime.Now;

            if (date.Month == 12 && date.Day >= 19 && date.Day <= 24)
            {
                return 0.2m;
            }
            if (date.Month == 11 && date.Day == 29)
            {
                return 0.5m;
            }

            return 1m;
        }
    }
}
