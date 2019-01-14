namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(6, Cheeseness.Double);
        }
    }
}