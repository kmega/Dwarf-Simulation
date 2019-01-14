namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger CheeseBurger = new Burger(Meet.CreateMeet(6), Cheeseness.Single, AddonType.None);
            return CheeseBurger;
        }
    }
}