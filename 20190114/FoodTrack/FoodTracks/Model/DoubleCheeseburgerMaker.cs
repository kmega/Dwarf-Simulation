namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger doublecheesburger = new Burger(this);
            return doublecheesburger;
        }
    }
}