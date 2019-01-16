namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(81, 0, 0, 0);
        }
    }
}