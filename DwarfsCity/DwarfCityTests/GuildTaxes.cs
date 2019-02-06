using DwarfsCity;
using DwarfsCity.DwarfContener;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfCityTests
{
    [TestClass]
    public class GuildTaxes
    {
        [TestMethod]
        public void ShouldReturnTaxesForOneDwarf()
        {
            List<Dwarf> Dwarfs = new List<Dwarf>();
            Dwarfs.Add(new Dwarf());
            Dwarfs[0].Backpack.Moneys = 4;
            Guild guild = new Guild();
            decimal expected = 1;
            decimal result = guild.GetTaxesofAllDwarfs(Dwarfs);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldReturnDwarfMoneyAfterTaxes()
        {
            List<Dwarf> Dwarfs = new List<Dwarf>();
            Dwarfs.Add(new Dwarf());
            Dwarfs[0].Backpack.Moneys = 4;
            Guild guild = new Guild();
            decimal expected = 3;          
            guild.GetTaxesofAllDwarfs(Dwarfs);
            decimal result = Dwarfs[0].Backpack.Moneys;
            Assert.AreEqual(expected, result);

        }
    }
}
