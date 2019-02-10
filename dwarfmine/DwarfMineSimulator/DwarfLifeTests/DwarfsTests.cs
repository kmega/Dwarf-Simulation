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
            var dwarf = new DwarfSingle(1);

            // when
            dwarf.Dig(100);

            // then
            Assert.IsTrue(dwarf.MinedMinerals[minerals] > 0);
        }
    }
}