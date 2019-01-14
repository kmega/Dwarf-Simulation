using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Burger()
        {
            Meet = Meet.CreateMeet();
            Cheeseness = Cheeseness.None;
            Addons = new List<AddonType> { AddonType.None };
        }

        public Burger(Cheeseness cheeseness)
        {
            Meet = Meet.CreateMeet();
            Cheeseness = Cheeseness.Single;
            Addons = new List<AddonType> { AddonType.None };
        }

        public Burger(Cheeseness cheeseness, int cookingTime)
        {
            Meet = Meet.CreateMeet(cookingTime);
            if(cheeseness == Cheeseness.Single)
            {
                Cheeseness = Cheeseness.Single;
            }
            if (cheeseness == Cheeseness.Double)
            {
                Cheeseness = Cheeseness.Double;
            }
            Addons = new List<AddonType> { AddonType.None };
        }

        public Burger(Cheeseness cheeseness, int cookingTime, List<AddonType> toppings)
        {
            Meet = Meet.CreateMeet(cookingTime);
            Cheeseness = cheeseness;
            Addons = toppings;
        }

        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }
    }
}