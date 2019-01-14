using System;

namespace FoodTracks.Model
{
    public class MassiveDiscount
    {
        public int discountForTest;

        public MassiveDiscount(int discountForTest)
        {
            this.discountForTest = discountForTest;
        }

        public decimal CalculateMassiveDiscount(decimal basePrice)
        {
            if(discountForTest != 0 && discountForTest != 1)
            {
                int zeroWins;
                Random random = new Random();
                zeroWins = random.Next(0, 1);

                if (zeroWins == 0)
                {
                    return basePrice / 2;
                }
            }

            if (discountForTest == 0)
            {
                return basePrice / 2;
            }

            return basePrice;
        }
    }
}