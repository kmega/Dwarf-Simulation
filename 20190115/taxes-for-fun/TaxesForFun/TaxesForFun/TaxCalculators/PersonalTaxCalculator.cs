﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            return (int)((receivedMoney - 8000) * 0.18);
        }
    }
}