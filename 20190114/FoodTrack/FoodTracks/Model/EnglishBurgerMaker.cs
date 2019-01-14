using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            int time = 10;
            List<AddonType> listaddons = new List<AddonType> { AddonType.Egg, AddonType.Halapenio };

            return new Burger(time, Cheeseness.Single, listaddons);
        }
    }
}