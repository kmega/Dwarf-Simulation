using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger CheeseBurger =
                new Burger(Meet.CreateMeet(10), Cheeseness.Single,
                new List<AddonType>() {AddonType.Halapenio, AddonType.Egg });

            return CheeseBurger;
        }
    }
}