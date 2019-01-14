using FoodTracks.Model;

namespace Tests
{
    public class TestDiscoutnCalc : IDiscountCalculator
    {
        public TestDiscoutnCalc(bool is111)
        {
            Is111 = is111;
        }

        public bool Is111 { get; }

        public decimal Calculate()
        {
            if (Is111)
                return -15;
            else
                return 0;
        }
    }
}