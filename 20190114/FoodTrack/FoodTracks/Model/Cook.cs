using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Cook
    {
        public Burger Create(IBurgerMaker burgerMaker)
        {

            if (burgerMaker != null)
            {
                return burgerMaker.Make();
            }
            var meet = Meet.CreateMeet();
            return new Burger(meet, Cheeseness.None, new List<AddonType>() { AddonType.None });


        }
    }
}