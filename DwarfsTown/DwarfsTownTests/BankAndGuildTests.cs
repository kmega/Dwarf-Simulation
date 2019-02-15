using DwarfsTown;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTownTests

{   [TestClass]
    public class BankAndGuildTests
    {
        
        Bank bank = new Bank();
        [TestMethod]
        public void IsAddToAccount20ForGold()
        {
            List<Dwarf> dwarfs = new List<Dwarf> { new Dwarf(TypeEnum.Father)};
            dwarfs[0].Backpack.Materials.Add(Materials.Gold); 
            //dwarf 0 have a gold in backpack

            decimal expected = 15;
            bank.ExtractRawMaterialFromBackpack(dwarfs[0]);
            decimal result = bank.SalaryPerDay;
            Assert.AreEqual(expected, result);
        }
        Guild guild = new Guild();

        [TestMethod]
        public void IsTaxesGetFromDwarfAccount()
        {
            List<Dwarf> dwarfs = new List<Dwarf> { new Dwarf(TypeEnum.Father) };
            dwarfs[0].BankAccount.Moneys = 20;
            guild.GetTaxesFromDwarfsAccounts(dwarfs);
            decimal expected = 15;

            decimal result = dwarfs[0].BankAccount.Moneys;
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void IsGuildEarnMoney()
        {
            List<Dwarf> dwarfs = new List<Dwarf> { new Dwarf(TypeEnum.Father) };
            dwarfs[0].BankAccount.Moneys = 20;
            guild.GuildMoney += 0.25m * dwarfs[0].BankAccount.Moneys;
            decimal expected = 5;

            decimal result = guild.GuildMoney;
            Assert.AreEqual(expected, result);
        }
    }
}
