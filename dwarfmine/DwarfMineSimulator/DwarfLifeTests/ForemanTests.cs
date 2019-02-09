using NUnit.Framework;
using DwarfLife.Buildings.Mine;
using DwarfLife.Buildings.Hospital;
using DwarfLife.Dwarfs;
using System;
using System.Collections.Generic;

namespace DwarfLife.Tests
{
    [TestFixture()]
    public class ForemanTests
    {
        [Test]
        public void ShouldSendDwarfsToRandomShaftsInMine()
        {
            // given
            var mine = new Mine();
            var foreman = new Foreman();
            var hospital = new Hospital();
            var dwarfs = hospital.BornDwarfes(10);

            // when
            var randomShaft = foreman.WhichShaft(mine);
            foreman.SendDwarfsToShaft(mine, dwarfs);

            // then
            Assert.IsTrue(mine.Shafts[0].DwarfsInShaft.Count > 0);
            Assert.IsTrue(mine.Shafts[0].DwarfsInShaft.Count <= 5);
            Assert.IsTrue(mine.Shafts[1].DwarfsInShaft.Count > 0);
            Assert.IsTrue(mine.Shafts[1].DwarfsInShaft.Count <= 5);
        }
    }
}