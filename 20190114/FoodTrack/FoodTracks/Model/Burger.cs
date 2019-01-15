using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger 
    {
        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }
		public decimal Price { get; }

		public Burger()
		{
			Price = 0;
			Meet = Meet.CreateMeet();
			Cheeseness = Cheeseness.None;
			Addons = new List<AddonType>() { AddonType.None };
		}

		public Burger(Cheeseness cheeseness, decimal price)
		{
			Price = price;
			Meet = Meet.CreateMeet();
			Cheeseness = cheeseness;
			Addons = new List<AddonType>() { AddonType.None };
		}

		public Burger(Meet meet, Cheeseness cheeseness, decimal price)
		{
			Price = price;
			Meet = meet;
			Cheeseness = cheeseness;
			Addons = new List<AddonType>() { AddonType.None };
		}

		public Burger(Meet meet, Cheeseness cheeseness, List<AddonType> addons, decimal price)
		{
			Price = price;
			Meet = meet;
			Cheeseness = cheeseness;
			Addons = addons;
		}


	}
}