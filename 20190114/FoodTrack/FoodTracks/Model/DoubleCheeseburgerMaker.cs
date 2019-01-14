namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {

            int perfecttime = 5;
            return new Burger(perfecttime, Cheeseness.Double);
        }
    }
}