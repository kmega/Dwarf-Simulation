namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(Cheeseness.Single, 5 );
        }
    }
}