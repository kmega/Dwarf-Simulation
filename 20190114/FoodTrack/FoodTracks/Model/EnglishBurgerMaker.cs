using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            var addons = new List<AddonType>();
            addons.Add(AddonType.Halapenio);
            addons.Add(AddonType.Egg);
            var burger = new Burger(Cheeseness.Single,10, addons);
            burger.Name = "englishburger";
            return burger;
        }
    }
}