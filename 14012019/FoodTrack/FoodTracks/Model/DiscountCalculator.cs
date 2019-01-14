using System;

namespace FoodTracks.Model
{
    public class DiscountCalculator : IDiscountCalculator
    {
        //Before chaning ask Bartek or Żółw :)
        public decimal Calculate()
        {
            if (DateTime.Now == new DateTime(2019, 11, 11))
            {
                return -15;
            }

            return 0;
        }
    }
}