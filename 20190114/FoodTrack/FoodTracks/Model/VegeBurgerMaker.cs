using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            var addons = new List<AddonType>();
            addons.Add(AddonType.None);
            var burger = new Burger(Cheeseness.Single, addons);
            burger.Name = "vegeburger";
            return burger;
        }
    }
}