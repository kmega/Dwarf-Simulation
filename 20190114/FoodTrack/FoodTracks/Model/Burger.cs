using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Meat Meat { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }
        public string Name;


        public Burger()
        {
            Meat = Meat.CreateMeet();
            Cheeseness = Cheeseness.None;
            Addons = new List<AddonType>() { AddonType.None };
        }

        public Burger(Cheeseness chees, int cookingTime, List<AddonType> addons)
        {
            Cheeseness = chees;
            Meat = Meat.CreateMeet(cookingTime);
            Addons = addons;
        }

        public Burger(Cheeseness chees, List<AddonType> addons)
        {
            Cheeseness = chees;
            Meat = Meat.CreateMeet();
            Addons = addons;
        }


    }
}