namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(6, Cheeseness.Single);
        }
    }
}