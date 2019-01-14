using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            var addons = new List<AddonType>();
            addons.Add(AddonType.None);
            var burger = new Burger(Cheeseness.Double, 9, addons);
            burger.Name = "dcheeseburger";
            return burger;
        }
    }
}