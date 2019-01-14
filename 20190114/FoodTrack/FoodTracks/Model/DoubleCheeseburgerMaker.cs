namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger DoubleCheeseBurger = new Burger(Meet.CreateMeet(6), Cheeseness.Double, AddonType.None);
            return DoubleCheeseBurger;
        }
    }
}