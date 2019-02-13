using NUnit.Framework;
using DwarfLife.Buildings.Mine;
using DwarfLife.Dwarfs;
using DwarfLife.Enums;
using System;
using System.Collections.Generic;

namespace DwarfLife.Tests
{
    [TestFixture()]
    public class MineTests
    {
        [Test]
        public void ShouldCreateMineWithShaftAAndShaftB()
        {
            // given
            var mine = new Mine();
            var shafts = new List<Shaft>() { new Shaft("Shaft A"), new Shaft("Shaft B") };

            // then
            Assert.IsTrue(mine.Shafts[0].Name == shafts[0].Name);
            Assert.IsTrue(mine.Shafts[1].Name == shafts[1].Name);
        }

        [TestCase("Shaft A")]
        [TestCase("Shaft B")]
        [TestCase("Shaft C")]
        [TestCase("Shaft D")]
        [TestCase("Shaft E")]
        [TestCase("Shaft F")]
        [TestCase("Shaft G")]
        public void ShouldCreateMineWithOneShaftThatNameIs(string shaftName)
        {
            // given
            var mine = new Mine(new[] { shaftName });

            // then
            Assert.IsTrue(mine.Shafts[0].Name == shaftName);
        }

        [Test]
        public void ShouldCreateMineWithSevenShafts()
        {
            // given
            string[] shaftNames = new[] { 
                "Shaft A", "Shaft B", "Shaft C", "Shaft D", "Shaft E", "Shaft F", "Shaft G" };

            // when
            var mine = new Mine(shaftNames);

            // then
            Assert.IsTrue(mine.Shafts[0].Name == shaftNames[0]);
            Assert.IsTrue(mine.Shafts[1].Name == shaftNames[1]);
            Assert.IsTrue(mine.Shafts[2].Name == shaftNames[2]);
            Assert.IsTrue(mine.Shafts[3].Name == shaftNames[3]);
            Assert.IsTrue(mine.Shafts[4].Name == shaftNames[4]);
            Assert.IsTrue(mine.Shafts[5].Name == shaftNames[5]);
            Assert.IsTrue(mine.Shafts[6].Name == shaftNames[6]);
        }

        [Test]
        public void SaboteurCameIntoShaftAndThenShaftShouldCollapse()
        {
            // given
            var mine = new Mine();
            var dwarfs = new List<IDwarf>() 
                {   new DwarfFather(1),
                    new DwarfSingle(2),
                    new DwarfSluggard(3),
                    new DwarfSluggard(4),
                    new DwarfSaboteur(5)
                };
            var foreman = new Foreman();

            // when
            foreman.SendDwarfsToShaft(mine.Shafts[0], dwarfs);
            dwarfs.ForEach(dwarf =>
            {
                dwarf.Dig();
                mine.Shafts[0].CheckForSaboteur();
            });

            // then
            Assert.IsTrue(mine.Shafts[0].IsCollapsed);
        }
    }
}