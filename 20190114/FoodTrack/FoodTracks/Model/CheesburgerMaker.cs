using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            var meet = Meet.CreateMeet(7);
            List<AddonType> addons = new List<AddonType>()
            {
                AddonType.None
            };
            return new Burger(meet, Cheeseness.Single, addons);
        }
    }
}