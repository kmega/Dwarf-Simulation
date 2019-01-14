using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        private MeetType medium;
        private Cheeseness single;
        private int time;

        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }

        public Burger()
        {
            Meet = Meet.CreateMeet();
            Cheeseness = Cheeseness.None;
            Addons = new List<AddonType> { AddonType.None }; 
        }

        public Burger(int time, Cheeseness cheeselevel, List<AddonType> listaddons)
        {
            Meet = Meet.CreateMeet(time);
            Cheeseness = cheeselevel;
            Addons = listaddons;
        }

        public Burger(Cheeseness cheeselevel)
        {
            Meet = Meet.CreateMeet();
            Cheeseness = cheeselevel;
            Addons = new List<AddonType> { AddonType.None };

        }

        public Burger(int time, Cheeseness cheeselevel)
        {
            Meet = Meet.CreateMeet(time);
            Cheeseness = cheeselevel;
            Addons = new List<AddonType> { AddonType.None };
        }

        public Burger Make()
        {
            return new Burger();
        }
    }
}