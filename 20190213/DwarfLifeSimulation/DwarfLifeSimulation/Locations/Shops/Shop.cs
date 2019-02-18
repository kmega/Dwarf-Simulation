using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Banks;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Loggers;

namespace DwarfLifeSimulation.Locations.Shops
{
    public class Shop
    {
		public int _bankAccountId;
        private ILog _logger;

		public Dictionary<ProductType, decimal> _shopState = new Dictionary<ProductType, decimal>();
		
		public Shop(ILog logger = null)
		{
			_shopState.Add(ProductType.Food, 0);
			_shopState.Add(ProductType.Alcohol, 0);
			_shopState.Add(ProductType.None, 0);
			_bankAccountId = Bank.Instance.CreateAccount();
            _logger = (logger != null) ? logger : new Logger();
        }

		public void ServeAllCustomers(List<IBuy> customers)
		{
			foreach (IBuy customer in customers)
			{
				ServeSingleCustomer(customer);
			}
			Bank.Instance.PayTax(_bankAccountId);
		}

		public void ServeSingleCustomer(IBuy customer)
		{
			var product = customer.Buy(_bankAccountId);
			decimal recipe = product._amount;
			ProductType productType = product._productType;
			_shopState[productType] += recipe;
            if (product._productType != ProductType.None)
            {
                _logger.AddLog($"Shop sold {product._amount} {product._productType}");
            }            
		}
	}
}
