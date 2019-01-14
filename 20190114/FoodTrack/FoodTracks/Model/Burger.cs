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
            Addons = new List<AddonType>();
            Meet = Meet.CreateMeet();
            //Meet.Type = MeetType.Medium;
            Cheeseness = Cheeseness.None;
            Addons.Add(AddonType.None);
        }
        public Burger(AddonType type, Cheeseness cheese, int time)
        {
            //Burger burger = new Burger(AddonType.None, Cheeseness.Single, 8);
            Addons = new List<AddonType>();
            Meet = Meet.CreateMeet(time);
            Cheeseness = cheese;
            Addons.Add(type);
        }
    }


}