using System;
using System.Collections.Generic;
using System.Text;
using TaxesForFun.Business;
using TaxesForFun.TaxCalculators;

namespace TaxesForFun
{
    public class ComplexCalculator 
    {
        public int ProcessCustomer(Customer customer)
        {
            if(customer.Type == CustomerType.Personal)
			{
				return new TotalPersonalTaxCalculator().CalculateTax(customer.Money);
			}else if (customer.Type == CustomerType.BusinessLinear)
			{
				return new LinearTaxCalculator().CalculateTax(customer.Money);
			}
			throw new NotImplementedException("Wrong customer type for calculate tax!");
		}

        public int ProcessCustomers(List<Customer> customers)
        {
			int result = 0;
			foreach(var customer in customers)
			{
				result += ProcessCustomer(customer);
			}
			return result;
        }
    }
}
