using System;
using System.Text;
using NUnit.Framework;
using System.Collections.Generic;
using ThorinsCompany;

namespace ThorinsCompanyTests
{
    public class GuildTests
    {
        Bank bank = new Bank();

        [Test]
        public void GetTaxesFromDwarves_GuildHas200OnBankAccountAfterTakingTaxes()
        {
            //given
            Guild guild = new Guild();
            List<Dwarf> dwarves = new Hospital().CreateDwarves(10);
            decimal moneyToTpUp = 100;
            foreach (var dwarf in dwarves)
            {
                dwarf.GetBankAccount().TopUp(moneyToTpUp);
            }

            //when
            guild.GetTaxesFromDwarvesThatWorked(dwarves);

            //then
            foreach (var dwarf in dwarves)
            {
                Assert.AreEqual(80, dwarf.GetBankAccount().CheckMoneyOnAccount());
            }

            Assert.AreEqual(200, guild.GetBankAccount().CheckMoneyOnAccount());

        }
        

    }
}
