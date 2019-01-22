using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocki
{
	public class CalendarDiscount : ICalendarDiscountCalculator
	{
		public decimal Calculate()
		{
			decimal discount = 0.0m;
			if(DateTime.Now.Month == 11 && DateTime.Now.Day == 29)
			{
				discount = 0.5m;
			} else if (DateTime.Now.Month == 12 
				&& DateTime.Now.Day >= 19 && DateTime.Now.Day <= 24)
			{
				discount = 0.2m;
			}

			return discount;
		}
	}
}
