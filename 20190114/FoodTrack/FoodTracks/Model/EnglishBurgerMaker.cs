namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger burger = new Burger(this);
            return burger;
        }
    }
}