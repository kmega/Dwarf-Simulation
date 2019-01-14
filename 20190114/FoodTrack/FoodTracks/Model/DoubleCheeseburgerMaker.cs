using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            var meet = Meet.CreateMeet(6);
            return new Burger(meet, Cheeseness.Double, new List<AddonType>() { AddonType.None });
        }
    }
}