using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public string Name { get; set; }
        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }


        
        public Burger()
        {
            Addons = new List<AddonType>();
            Meet = Meet.CreateMeet();
            Cheeseness = Cheeseness.None;
            Addons.Add(AddonType.None);
          
        }

        public Burger(AddonType type, Cheeseness cheese, int time)
        {
            Addons = new List<AddonType>();
            Meet = Meet.CreateMeet(time);
            Cheeseness = cheese;
            Addons.Add(type);

        }

        public Burger(AddonType type, Cheeseness cheese)
        {
            Addons = new List<AddonType>();
            Meet = Meet.CreateMeet();
            Cheeseness = cheese;
            Addons.Add(type);

        }
    }
}