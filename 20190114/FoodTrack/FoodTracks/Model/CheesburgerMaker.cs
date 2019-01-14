namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger cheesburger = new Burger(this);
            return cheesburger;
        }
    }
}