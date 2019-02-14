using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Locations.Canteens
{
    public class Canteen
    {
		private int _foodRations { get; set; }

		public Canteen()
		{
			_foodRations = 200;
		}

        public void ServeMultipleRations(int count)
        {
            for(int i = count; i > 0; i--)
			{
				ServeSingleRation();
			}
			if (_foodRations <= 10)
			{
				OrderFoodRations();
			}
        }

		private void ServeSingleRation()
		{
			_foodRations--;
		}

		private void OrderFoodRations()
		{
			_foodRations += 30;
		}

		public int GetAmountOfRations()
		{
			return _foodRations;
		}
    }
}
