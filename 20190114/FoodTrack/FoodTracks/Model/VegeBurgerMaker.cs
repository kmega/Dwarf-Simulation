namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger vegeBurger = new Burger(this);
            return vegeBurger;
        }
    }
}