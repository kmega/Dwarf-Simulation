using System;
using System.Collections.Generic;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public static class TaxCalculatorFactory
    {
        public static ITaxCalculator Create(string type)
        {

            if (type == "personal first tax level")
            {
                ITaxCalculator personalCalc = new PersonalTaxCalculator
                {
                    Type = type
                };
                return personalCalc;
            }
            else if (type == "linear business")
            {
                ITaxCalculator personalCalc = new LinearTaxCalculator
                {
                    Type = type
                };

                return personalCalc;
            }
            else if (type == "personal second tax level")
            {
                ITaxCalculator personalCalc = new PersonalTaxCalculator
                {
                    Type = type
                };

                return personalCalc;
            }
            else return null;
  
        }

        public static ITaxCalculator Create(CustomerType type)
        {
            if (type == CustomerType.Personal)
            {
                ITaxCalculator personalCalc = new PersonalTaxCalculator
                {
                    Type = "personal first tax level"
                };
                return personalCalc;
            }
            else if (type == CustomerType.BusinessLinear)
            {
                ITaxCalculator personalCalc = new LinearTaxCalculator
                {
                    Type = "linear business"
                };

                return personalCalc;
            }
            else return null;
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            int priceOfGoods = 0;

            foreach (var good in goods)
            {
                priceOfGoods += good.Value;
            }

            if (type == CustomerType.Personal)
            {
                ITaxCalculator personalCalc = new PersonalTaxCalculator
                {
                    Type = "personal first tax level"
                };

                personalCalc.PriceOfGoods = priceOfGoods;
                return personalCalc;
            }
            else if (type == CustomerType.BusinessLinear)
            {
                ITaxCalculator personalCalc = new LinearTaxCalculator
                {
                    Type = "linear business"
                };

                personalCalc.PriceOfGoods = priceOfGoods;

                return personalCalc;
            }
            else return null;
        }


    }
}
