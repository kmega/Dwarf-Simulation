using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class BankAssistant
    {
        private static Bank _bank;
        public BankAssistant(Bank bank)
        {
            _bank = bank;
        }
        public static void MakeTransaction(int accountIDForAddition, int accountIDForSubtraction, decimal moneyForTransaction)
        {
            _bank.MakeTransaction(accountIDForAddition,accountIDForSubtraction,moneyForTransaction);
        }
        public static decimal CheckMoneyOnAccount(int accountID)
        {
            return _bank.CheckMoneyOnAccount(accountID);
        }
        public static void TopUpYourAccount(int ID, decimal moneyToTopUpAccount)
        {
            _bank.TopUpYourAccount(ID, moneyToTopUpAccount);
        }
    }
}
