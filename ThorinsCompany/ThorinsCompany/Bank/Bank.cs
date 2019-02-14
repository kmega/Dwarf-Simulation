using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class Bank : IBank
    {
        private decimal _bankMoney = 0;

        public void ExchangeMaterialsForMoney(BankAccount bankAccount, List<Material> materials)
        {
            decimal moneyEarned = 0;

            foreach (var material in materials)
            {
                //deciaml moneyEarned = Randomizer.MaterialToGold(material);
                bankAccount.TopUp(moneyEarned);
            }
        }

        public void MakeTransaction(BankAccount accountForAddition, BankAccount accountForSubstraction, decimal moneyForTransaction)
        {
            if (accountForSubstraction.CanGetMoneyFromAccount(moneyForTransaction))
                accountForAddition.TopUp(moneyForTransaction);
        }
    }
}
