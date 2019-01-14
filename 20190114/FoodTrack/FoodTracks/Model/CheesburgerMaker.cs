namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            int time = 5;
            return new Burger(time, Cheeseness.Single);
        }
    }
}