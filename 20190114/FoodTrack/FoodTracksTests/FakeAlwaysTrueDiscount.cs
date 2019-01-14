using FoodTracks.Model;

namespace Tests
{
    internal class FakeAlwaysTrueDiscount : IRandomDiscount
    {
        public FakeAlwaysTrueDiscount()
        {
        }

        public bool DrawDiscount()
        {
            return true;
        }
    }
}