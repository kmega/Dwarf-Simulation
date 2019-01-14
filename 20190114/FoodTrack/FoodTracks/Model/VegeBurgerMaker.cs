namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            int cookingtime = 5;
            int a = 0; int b = 0;
            return new Burger(cookingtime,a,b);
        }
    }
}