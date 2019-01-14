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
		public Burger(Meet meet)
		{
			Meet = meet;
			Cheeseness = Cheeseness.None;
			Addons = new List<AddonType>() { AddonType.None };
		}

		public Burger(Cheeseness cheeseness)
		{
			Meet = Meet.CreateMeet();
			Cheeseness = cheeseness;
			Addons = new List<AddonType>() { AddonType.None };
		}

		public Burger(Meet meet, Cheeseness cheeseness)
		{
			Meet = meet;
			Cheeseness = cheeseness;
			Addons = new List<AddonType>() { AddonType.None };
		}

		public Burger(Meet meet, Cheeseness cheeseness, List<AddonType> addons)
		{
			Meet = meet;
			Cheeseness = cheeseness;
			Addons = addons;
		}


	}
}