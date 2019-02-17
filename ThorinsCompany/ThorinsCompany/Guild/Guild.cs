using System;
using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Guild
    {
        public readonly int accountID;
        private BankAccount _bankAccount;
        public decimal TaxesValue { get; private set; }

        public Guild()
        {
            TaxesValue = 0.20m;
            accountID = IDCreator.GetUniqueID();
            _bankAccount = AccountCreator.CreateNewAccount(accountID);
        }
        //after Bank
        public void GetTaxesFromDwarvesThatWorked(List<Dwarf> dwarves)
        {
            foreach (var dwarf in dwarves)
            {
                var dailyIncomeOfDwarf = dwarf.GetBankAccount().CheckYourDailyIncome();
                    dwarf.GetBankAccount().MakeTransaction(_bankAccount,dailyIncomeOfDwarf*TaxesValue);
                
            }
        }

        public BankAccount GetBankAccount() => _bankAccount;
    }
}