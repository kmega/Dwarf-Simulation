namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger doubleCheeseburger = new Burger(AddonType.None, Cheeseness.Double, 8);
            doubleCheeseburger.Name = "DoubleCheeseburger";
            return doubleCheeseburger;
        }
    }
}