using System;

namespace FoodTracks.Model
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private DateTime discountDateTime;

        public DiscountCalculator()
        {
            this.discountDateTime = discountDateTime;
        }
        //Before chaning ask Bartek or Żółw :)
        public decimal Calculate()
        {
            if (DateTime.Now == new DateTime(2019, 11, 11))
            {
                return -15;
            }

            return 0;
        }

        public int ChanceForWin()
        {
            Random random = new Random();
            return  random.Next(2);
        }
    }
}