using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Cook
    {
        public Burger Create(IBurgerMaker burgerMaker)
        {
            if(burgerMaker != null)
            {
                return burgerMaker.Make();
            }
            else
            {
                List<AddonType> addons = new List<AddonType>()
                {
                    AddonType.None
                };
                var meet = Meet.CreateMeet();
                return new Burger(meet, Cheeseness.None, addons);
            }
        }
    }
}