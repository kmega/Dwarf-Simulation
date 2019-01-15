using FoodTracks.Model;
using System;

namespace Tests
{
    public class TodayIs1111DiscountCalculator : IDiscountCalculator
    {

        public decimal Calculate()
        {
            //zrobic to bez uzywania klasy daty klasa z nowa data
            DateTime dateTime = new DateTime();
            DateTime value = new DateTime(2019, 11, 12);
            if (value == new DateTime(2019, 11, 12))
            {
                return 0;
            }
            else
            {
                return -15;
            }
        }
    }
}