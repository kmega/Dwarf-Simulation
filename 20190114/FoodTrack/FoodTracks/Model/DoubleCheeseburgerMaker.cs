namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(Cheeseness.Double, 6);
        }
    }
}