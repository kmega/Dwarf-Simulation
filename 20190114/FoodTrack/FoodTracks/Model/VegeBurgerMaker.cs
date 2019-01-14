namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger CheeseBurger = new Burger(Meet.CreateMeet(), Cheeseness.Single, AddonType.None);
            return CheeseBurger;
        }
    }
}