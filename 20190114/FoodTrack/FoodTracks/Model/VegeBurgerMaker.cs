namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
			return new Burger(Cheeseness.Single);
		}
    }
}