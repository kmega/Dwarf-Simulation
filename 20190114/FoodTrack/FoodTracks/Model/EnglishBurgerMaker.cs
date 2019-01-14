using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        { 
            List<AddonType> addons = new List<AddonType>();
            addons.Add(AddonType.Egg);
            addons.Add(AddonType.Halapenio);

            Burger burger = new Burger(Meet.CreateMeet(10),Cheeseness.Single,addons);
            burger.Price = 25;
            return burger;  
        }
    }
}