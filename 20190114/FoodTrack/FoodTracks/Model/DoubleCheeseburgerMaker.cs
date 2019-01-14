namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
			return new Burger(Meet.CreateMeet(7), Cheeseness.Double, 20);
		}
    }
}