using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }

        public Burger()
        {
            Meet = Meet.CreateMeet();
            Cheeseness = Cheeseness.None;
            Addons = new List<AddonType>() { AddonType.None };
        }

        public Burger(Cheeseness cheeseness)
        {
            Meet = Meet.CreateMeet();
            Cheeseness = cheeseness;
            Addons = new List<AddonType>() { AddonType.None };
        }

        public Burger(Cheeseness cheeseness, List<AddonType> addons)
        {
            Meet = Meet.CreateMeet();
            Cheeseness = cheeseness;
            Addons = addons;
        }

        public Burger(int meatCookingTime, Cheeseness cheeseness)
        {
            Meet = Meet.CreateMeet(meatCookingTime);
            Cheeseness = cheeseness;
            Addons = new List<AddonType>() { AddonType.None };
        }

        public Burger(int meatCookingTime, Cheeseness cheeseness, List<AddonType> addons)
        {
            Meet = Meet.CreateMeet(meatCookingTime);
            Cheeseness = cheeseness;
            Addons = addons;
        }
    }
}