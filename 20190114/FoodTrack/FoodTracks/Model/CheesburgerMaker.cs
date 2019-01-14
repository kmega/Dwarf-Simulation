using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            var addons = new List<AddonType>();
            addons.Add(AddonType.None);
            var burger = new Burger(Cheeseness.Single, 9,addons);
            burger.Name = "cheeseburger";
            return burger;
        }
    }
}