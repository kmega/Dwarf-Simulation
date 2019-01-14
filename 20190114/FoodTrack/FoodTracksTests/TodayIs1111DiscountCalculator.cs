using FoodTracks.Model;
using System;

namespace Tests
{
    public class TodayIs1111DiscountCalculator : IDiscountCalculator
    {
        public bool Is1111Date { get; set; }

        public decimal Calculate()
        {
            if(Is1111Date)
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