using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            var meet = Meet.CreateMeet(12);
            List<AddonType> addonTypes = new List<AddonType>()
            {
                AddonType.Egg,
                AddonType.Halapenio
            };
            return new Burger(meet, Cheeseness.Single, addonTypes);
        }
    }
}