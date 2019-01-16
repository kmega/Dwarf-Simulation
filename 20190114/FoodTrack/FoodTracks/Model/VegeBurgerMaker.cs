namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(0, 0, 0);
        }
    }
}