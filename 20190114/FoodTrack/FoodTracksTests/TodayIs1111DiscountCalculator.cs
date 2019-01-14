using FoodTracks.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracksTests
{
    public class TodayIs1111DiscountCalculator : IDiscountCalculator
    {
         bool Date = true;

        public TodayIs1111DiscountCalculator (bool date)
        {
            Date = date;
            

        }
        public decimal Calculate()
        {
            if (Date)
            {
                return -15;
            }
            else  return 0;
        }

     
        decimal IDiscountCalculator.RandomBonus()
        {
            return 1;
        }
    }
}