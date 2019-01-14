namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            int cookingtime = 5;
            int a = 0;
            return new Burger(cookingtime,a);
        }
    }
}