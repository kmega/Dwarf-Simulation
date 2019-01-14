using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            List<AddonType> addons = new List<AddonType>() 
            {   
                AddonType.Halapenio, 
                AddonType.Egg
            };

            return new Burger(11, Cheeseness.Single, addons);
        }
    }
}