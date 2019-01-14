using FoodTracks.Model;

namespace Tests
{
    public class TestDiscountCalc : IDiscountCalculator
    {
        public TestDiscountCalc(bool is111)
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

        public decimal Calculate(decimal price)
        {
            throw new System.NotImplementedException();
        }
    }
}