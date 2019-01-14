using System;
using FoodTracks.Model;

namespace Tests
{
    public class TodayIs1111DiscountCalculator : IDiscountCalculator
    {
        public bool ifTodayIs1111;
        public decimal Calculate()
        {
            if (ifTodayIs1111)
            {
                return -15;
            }
            return 0;
        }
    }
}