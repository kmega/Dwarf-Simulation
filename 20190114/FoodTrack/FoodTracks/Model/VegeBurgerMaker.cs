namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger vegeBurger = new Burger(AddonType.None, Cheeseness.Single);
            vegeBurger.Name = "VegeBurger";
            return vegeBurger;
        }
    }
}


