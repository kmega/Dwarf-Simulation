using FoodTracks.Model;
using System;

namespace Tests
{
    public class TodayIs1111DiscountCalculator : IDiscountCalculator
    {
        public decimal Calculate()
        {
            var specificDate = new DateTime(2019, 11, 11);
            var currentDate = DateTime.Now;
            if(specificDate == currentDate.Date)
            {
                return -15;
            }
            else
            {
                return 0;
            }           
        }
    }
}