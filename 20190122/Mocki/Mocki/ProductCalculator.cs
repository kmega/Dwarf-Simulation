using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocki
{
	public class ProductCalculator 
	{
		private IDiscountCalculator _dc;
		private ICalendarDiscountCalculator _cdl;
		public ProductCalculator(IDiscountCalculator dc, ICalendarDiscountCalculator cdl)
		{
			_dc = dc;
			_cdl = cdl;
		}
		public decimal CalculatePrice(decimal price, string typ) {

			decimal totalPrice = 0.0m;
			if(_dc.Calculate(price,typ) > 1)
			{
				totalPrice = price * (_dc.Calculate(price, typ) + _cdl.Calculate());
			}
			else
			{
				totalPrice = price * (1 - (_dc.Calculate(price, typ) + _cdl.Calculate()));
			}
			
			return totalPrice;
		}
	}
}
