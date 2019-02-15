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

        public void ExchangeMaterialsForMoney(int ID, Material material, int numberOfMaterial)
        {
            decimal moneyEarned = 0;

            for (int i = 0; i < numberOfMaterial; i++)
            {
                moneyEarned = _randomizer.ReturnPriceMaterials(material);

                _bankAccounts[ID].TopUp(GetTaxesFromExchangeAndReturnLeftMoney(moneyEarned));
            }
        }

        public void ExchangeMaterialsForMoneyFromAllDwarves(List<Dwarf> dwarves)
        {
            foreach (var dwarf in dwarves)
            {
                var dwarfDiggedMaterials = dwarf.ShowDiggedMaterials().Keys;

                foreach (var material in dwarfDiggedMaterials)
                {
                    ExchangeMaterialsForMoney(dwarf.accountID, material, dwarf.ShowDiggedMaterials()[material]);
                }
               
            }
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

        private decimal GetTaxesFromExchangeAndReturnLeftMoney(decimal amount)
        {
            _bankMoney += _taxesValue * amount;
            return ((1 - _taxesValue) * amount);
        }



    }
}
