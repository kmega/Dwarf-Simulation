using NUnit.Framework;
using System;
using System.Collections.Generic;
using DwarfLife.Buildings.Guild;
using DwarfLife.Enums;
using System.Linq;

namespace DwarfLife.Tests
{
    [TestFixture()]
    public class GuildTests
    {
        [Test]
        public void ShouldBuyMineralsCollectTaxesAndProvideSalary()
        {
            // given
            decimal salary = 0m;
            decimal expectedMinSalary = 375m;
            decimal expectedMaxSalary = 675m;
            decimal expectedMinTaxes = 125m;
            decimal expectedMaxTaxes = 225m;
            var guild = new Guild();
            var minerals = new Dictionary<Minerals, int>()
            {
                { Minerals.Mithril, 5},         // *<15, 25> = <75, 125>
                { Minerals.Gold, 10},           // *<10, 20> = <100, 200>
                { Minerals.Silver, 25},         // *<5, 15> = <125, 375>
                { Minerals.TaintedGold, 100},   // *2 = 200
            };  // sum = <500, 900> and take tax so real range is <375, 675>
                // tax is 25% so expected range is <125, 225>

            // when
            salary = guild.BuyMinerals(minerals);
            decimal taxes = guild.CollectedTaxes;

            // then
            Assert.IsTrue(salary >= expectedMinSalary && salary <= expectedMaxSalary);
            Assert.IsTrue(taxes >= expectedMinTaxes && taxes <= expectedMaxTaxes);
        }
    }
}