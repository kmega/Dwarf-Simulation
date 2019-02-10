using NUnit.Framework;
using DwarfLife.Buildings.Mine;
using DwarfLife.Buildings.Hospital;
using DwarfLife.Enums;
using DwarfLife.Dwarfs;
using System;
using System.Collections.Generic;

namespace DwarfLife.Tests
{
    [TestFixture()]
    public class DwarfTests
    {
        [TestCase(Minerals.Mithril)]
        [TestCase(Minerals.Gold)]
        [TestCase(Minerals.Silver)]
        [TestCase(Minerals.TaintedGold)]
        public void ShouldDigMineralsTypeOf(Minerals minerals)
        {
            // given
            var foreman = new Foreman();
            var dwarfs = new List<IDwarf>() { new DwarfSingle(1) };
            var mine = new Mine();

            // when
            foreman.SendDwarfsToRandomShaft(mine, dwarfs);
            dwarfs[0].Dig(100);

            // then
            Assert.IsTrue(dwarfs[0].MinedMinerals[minerals] > 0);
        }
    }
}