using System;
namespace DiscountCalcualtorWithMocks
{
    public class CalendarDiscountCalculator : ICalendarDiscountCalculator
    {
        public DateTime SetDiscountByDate()
        {
            return DateTime.Now;
        }
    }
}
