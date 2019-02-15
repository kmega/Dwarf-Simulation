using DwarfMineSimulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class Bank
    {
        private decimal _bankMoney = 0;
        private decimal _taxesValue = 0.20m;
        private Dictionary<int, BankAccount> _bankAccounts = new Dictionary<int, BankAccount>();
        RandomizerThorins _randomizer = new RandomizerThorins();

        public Bank()
        {
            new BankAssistant(this);
            new AccountCreator(this);
        }
        public void ExchangeMaterialsForMoney(int ID, List<Material> materials)
        {
            decimal moneyEarned = 0;

            foreach (var material in materials)
            {
               moneyEarned = _randomizer.ReturnPriceMaterials(material);

                _bankAccounts[ID].TopUp(GetTaxesFromExchangeAndReturnLeftMoney(moneyEarned));
            }
        }

        internal void ExchangeMaterialsForMoneyFromAllDwarves(List<Dwarf> dwarves)
        {
            throw new NotImplementedException();
        }

        public void MakeTransaction(int accountIDForAddition, int accountIDForSubtraction, decimal moneyForTransaction)
        {
            if (_bankAccounts[accountIDForSubtraction].CanGetMoneyFromAccount(moneyForTransaction))
                _bankAccounts[accountIDForAddition].TopUp(moneyForTransaction);
        }

        public void CreateAccount(BankAccount newAccount, int ID)
        {
            _bankAccounts.Add(ID,newAccount);
        }

        public void ResetDailyIncomeOfAccounts()
        {
            foreach (var account in _bankAccounts.Keys)
            {
                _bankAccounts[account].ResetDailyIncome();
            }
        }

        public void TopUpYourAccount(int ID, decimal moneyToTopUpAccount)
        {
            _bankAccounts[ID].TopUp(moneyToTopUpAccount);
        }

        public decimal CheckYourDailyIncome(int ID)
        {
            return _bankAccounts[ID].GetDailyIncome();
        }

        public decimal CheckMoneyOnAccount(int ID)
        {
            return _bankAccounts[ID].GetMoney();
        }

        private decimal GetTaxesFromExchangeAndReturnLeftMoney(decimal amount)
        {
            _bankMoney += _taxesValue * amount;
            return ((1 - _taxesValue) * amount);
        }

    }
}
