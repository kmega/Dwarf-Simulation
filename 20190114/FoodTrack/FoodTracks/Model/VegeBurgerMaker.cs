using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            var meet = Meet.CreateMeet();
            List<AddonType> addonTypes = new List<AddonType>()
            {
                AddonType.None
            };
            return new Burger(meet, Cheeseness.Single, addonTypes);
        }
    }
}