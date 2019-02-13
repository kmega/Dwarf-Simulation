﻿using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;
using Banks = DwarfLifeSimulation.Locations.Bank.Bank;
using DwarfLifeSimulation.Dwarves;


namespace DwarfLifeSimulation.Locations.Shop
{
    public class Shop
    {
		private int _bankAccountId;

		public Dictionary<ProductType, decimal> _shopState = new Dictionary<ProductType, decimal>();
		
		public Shop()
		{
			_shopState.Add(ProductType.Food, 0);
			_shopState.Add(ProductType.Alcohol, 0);
			_bankAccountId = Banks.Instance.CreateAccount();
		}

		public void ServeAllCustomers(List<IBuy> customers)
		{
			foreach (IBuy customer in customers)
			{
				ServeSingleCustomer(customer);
			}
			Banks.Instance.PayTax(_bankAccountId);
		}

		private void ServeSingleCustomer(IBuy customer)
		{
			var product = customer.Buy(_bankAccountId);
			decimal recipe = product._amount;
			ProductType productType = product._productType;
			
			_shopState[productType] += recipe;
		}
	}
}
