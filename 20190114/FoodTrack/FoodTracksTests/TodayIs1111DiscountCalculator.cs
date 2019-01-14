using FoodTracks.Model;

namespace Tests
{
    public class TodayIs1111DiscountCalculator : IDiscountCalculator
    {
        public bool TodayIs1111;
        public decimal Calculate()
        {
            if(TodayIs1111)
                return - 15;
            return 0;
        }
    }
}