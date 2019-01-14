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

        public decimal RandomBonus()
        {
            Random rand = new Random();
            int option = rand.Next(2);
            if (option == 1)
            {
                return 2;
            }
            else return 1;
        }


    }
}