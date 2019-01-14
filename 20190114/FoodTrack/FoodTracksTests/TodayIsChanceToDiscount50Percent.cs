using FoodTracks.Model;
using System;

namespace Tests
{
    public class TodayIsChanceToDiscount50Percent : IDiscountCalculator
    {
        public decimal Calculate()
        {
            Random random = new Random();
            int chance = random.Next(1, 2);

            //chance is true
            if(chance == 1)
            {
                return 0.5M;
            }
            //chance is false
            else if(chance == 2)
            {
                return 0;
            }
            throw new NotImplementedException();
        }
    }
}