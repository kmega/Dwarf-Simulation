namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger vegeBurger = new Burger(AddonType.None, Cheeseness.Single, 0);
            return vegeBurger;
        }
    }
}