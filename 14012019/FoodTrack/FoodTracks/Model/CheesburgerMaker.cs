using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(Meet.CreateMeet(5), Cheeseness.Single, new List<AddonType> { AddonType.None });
        }
    }
}