using System.Collections.Generic;
using System.Linq;
using TaxesForFun.Business;
using TaxesForFun.TaxCalculators;

namespace TaxesForFun
{
    public class ComplexCalculator
    {
        public int ProcessCustomer(Customer customer)
        {
            if (customer.Type == CustomerType.Personal)
            {
                int TaxReduction = 0;
                if(customer.HouseGoods.Any())
                {
                    TaxReduction = CalculateTotalHouseTaxReduction(customer.HouseGoods);
                }
                return new TotalPersonalTaxCalculator().CalculateTax(customer.Money-TaxReduction);
            }
            else if(customer.Type == CustomerType.BusinessLinear)
            {
                return new LinearTaxCalculator(customer.HouseGoods).CalculateTax(customer.Money);
            }
            else return 0;
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            int sum=0;
           foreach(Customer customer in customers)
            {
                sum += ProcessCustomer(customer);
            }
            return sum;
        }
        public static int CalculateTotalHouseTaxReduction(List<Goods> goods)
        {
            int taxReduction = 0;
            foreach(Goods goodie in goods)
            {
                taxReduction += goodie.Value;
            }
            return taxReduction;
        }
    }
}
