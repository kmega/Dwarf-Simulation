using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            var meet = Meet.CreateMeet(6);
            return new Burger(meet, Cheeseness.Single, new List<AddonType>() { AddonType.None });
        }
    }
}