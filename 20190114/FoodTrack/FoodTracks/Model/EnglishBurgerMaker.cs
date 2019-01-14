using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            var meet = Meet.CreateMeet(10);
            return new Burger(meet, Cheeseness.Single, new List<AddonType>() { AddonType.Egg, AddonType.Halapenio });
        }
    }
}