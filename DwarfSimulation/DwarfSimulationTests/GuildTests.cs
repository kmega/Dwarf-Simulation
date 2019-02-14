using NUnit.Framework;
using DwarfSimulation;
using System.Collections.Generic;

namespace GuildTests
{
    public class GuildTests
    {
        [Test]
        public void ShouldClearDwarfBackpack()
        {
            // GIVEN
            Dwarf dwarf = new Dwarf()
            {
                BackPack =
              {
                  [Mineral.Gold] = 5,
                  [Mineral.Silver] = 5,
                  [Mineral.Mithril] = 5,
                  [Mineral.TaintedGold] = 5,
              }
            };

            Guild guild = new Guild();

            // WHEN
            guild.clearBackpack(dwarf);

            // THEN
            Assert.AreEqual(0, dwarf.BackPack[Mineral.Gold]);
            Assert.AreEqual(0, dwarf.BackPack[Mineral.Silver]);
            Assert.AreEqual(0, dwarf.BackPack[Mineral.TaintedGold]);
            Assert.AreEqual(0, dwarf.BackPack[Mineral.Mithril]);
        }

        [Test]
        public void ShouldClearDwarvesBackpacks()
        {
            // GIVEN
            List<Dwarf> listOfDwarves = new List<Dwarf>()
            {
                new Dwarf() {BackPack = {[Mineral.Gold] = 5, [Mineral.Mithril]=5,[Mineral.Silver]=5,[Mineral.TaintedGold]=5}},
                new Dwarf() {BackPack = {[Mineral.Gold] = 3, [Mineral.Mithril]=3,[Mineral.Silver]=3,[Mineral.TaintedGold]=3}},
            };

            Guild guild = new Guild();

            // WHEN
            guild.clearBackpacks(listOfDwarves);

            // THEN
            Assert.AreEqual(0, listOfDwarves[0].BackPack[Mineral.Gold]);
            Assert.AreEqual(0, listOfDwarves[0].BackPack[Mineral.Silver]);
            Assert.AreEqual(0, listOfDwarves[0].BackPack[Mineral.TaintedGold]);
            Assert.AreEqual(0, listOfDwarves[0].BackPack[Mineral.Mithril]);

            Assert.AreEqual(0, listOfDwarves[1].BackPack[Mineral.Gold]);
            Assert.AreEqual(0, listOfDwarves[1].BackPack[Mineral.Silver]);
            Assert.AreEqual(0, listOfDwarves[1].BackPack[Mineral.TaintedGold]);
            Assert.AreEqual(0, listOfDwarves[1].BackPack[Mineral.Mithril]);
        }


    }
}
