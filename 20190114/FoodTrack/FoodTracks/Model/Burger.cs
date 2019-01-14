using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }
        public decimal Price = 0;
        public Burger()
        {
            Meet = Meet.CreateMeet();
            Cheeseness = Cheeseness.None;
            Addons = new List<AddonType>() { AddonType.None };
        }
        public Burger(Meet meet) {
            Meet = meet;
            Cheeseness = Cheeseness.None;
            Addons = new List<AddonType>() { AddonType.None };
        }
        public Burger(Meet meet, Cheeseness cheeseness)
        {
            Cheeseness = cheeseness;
            Meet = meet;
            Addons = new List<AddonType>() { AddonType.None };
        }
        public Burger(Meet meet,Cheeseness cheeseness, List<AddonType> addons)
        {
            Cheeseness = cheeseness;
            Meet = meet;
            Addons = addons;
        }
       
    }
}