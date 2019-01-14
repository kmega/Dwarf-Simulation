namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger cheeseburger = new Burger(AddonType.None, Cheeseness.Single, 8);
            return cheeseburger;
        }
    }
}