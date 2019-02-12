﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Bank
{
    public class BankAccount
    {
        public decimal OverallAccount { get; private set; }
        public decimal LastInput { get; private set; }

        public BankAccount()
        {
            OverallAccount = 0.0m;
            LastInput = 0.0m;
        }

        public void ReceivedMoney(decimal income)
        {
            LastInput += income;
        }
        public void SendLastIncomeToYourAccount()
        {
            OverallAccount += LastInput;
            LastInput = 0;
        }

        public void Withdraw(decimal value)
        {
            LastInput -= value;
        }
    }
}