using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Cook
    {
        public Burger Create(IBurgerMaker burgerMaker)
        {
            if (burgerMaker == null)
            {
                return new Burger(Meet.CreateMeet(), Cheeseness.None, new List<AddonType> { AddonType.None });
            }

            return burgerMaker.Make();
        }
    }
}