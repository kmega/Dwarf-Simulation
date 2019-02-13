using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Bank;
using DwarfLifeSimulation.Dwarves;

namespace DwarfLifeSimulation.Locations.Shop
{
    public class Shop
    {
		public Dictionary<ProductType, decimal> _shopState = new Dictionary<ProductType, decimal>();

		public Shop()
		{
			_shopState.Add(ProductType.Food, 0);
			_shopState.Add(ProductType.Alcohol, 0);
		}

		public void ServeAllCustomers(List<IBuy> customers)
		{
			foreach (IBuy customer in customers)
			{
				ServeSingleCustomer(customer);
			}
			//Bank.PayTax();
		}

		private void ServeSingleCustomer(IBuy customer)
		{
			//var product = customer.Buy();
			//decimal recipe = product._amount;
			//ProductType productType = product._productType;
			
			//_shopState[productType] += recipe;
		}
	}
}
