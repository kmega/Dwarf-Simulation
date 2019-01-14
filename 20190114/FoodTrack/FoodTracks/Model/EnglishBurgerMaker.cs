namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger englishBurger = new Burger(AddonType.Halapenio, Cheeseness.Single, 11);
            englishBurger.Addons.Add(AddonType.Egg);
            return englishBurger;
        }
    }
}