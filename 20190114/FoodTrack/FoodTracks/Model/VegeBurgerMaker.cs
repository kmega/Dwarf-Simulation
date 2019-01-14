using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            var meet = Meet.CreateMeet();
            return new Burger(meet, Cheeseness.Single, new List<AddonType>() { AddonType.None });
        }
    }
}