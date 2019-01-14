using FoodTracks.Model;
using System;

namespace Tests
{
    public class TodayIs1111DiscountCalculator : IDiscountCalculator
    {
		public bool TodayIsDiscountDay;
        public decimal Calculate()
        {
			if (TodayIsDiscountDay)
			{
				return -15;
			}
			return 0;
		}
    }
}