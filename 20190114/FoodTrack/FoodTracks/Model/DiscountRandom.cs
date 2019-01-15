using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracks.Model
{
	public class DiscountRandom : IDiscountRandom
	{
		public bool discount()
		{
			Random rnd = new Random();
			int randomNumber = rnd.Next(0, 2);
			if(randomNumber == 0)
			{
				return false;
			}
			return true;
		}
	}
}
