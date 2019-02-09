using NUnit.Framework;
using DwarfLife.Buildings;
using DwarfLife.Enums;
using DwarfLife.Dwarfs;
using System;

namespace DwarfLife.Tests
{
    [TestFixture()]
    public class DwarfLifeTests
    {
        [TestCase(DwarfTypes.Father)]
        [TestCase(DwarfTypes.Single)]
        [TestCase(DwarfTypes.Sluggard)]
        [TestCase(DwarfTypes.Saboteur)]
        public void ShouldBornDwarfTypeOf(DwarfTypes dwarfType)
        {
            // given
            var hospital = new Hospital();

            // when
            IDwarf dwarf = hospital.BornDwarf(1, dwarfType);

            // then
            Assert.IsTrue(dwarf.DwarfType() == dwarfType);
        }

        [TestCase(DwarfTypes.Father)]
        [TestCase(DwarfTypes.Single)]
        [TestCase(DwarfTypes.Sluggard)]
        [TestCase(DwarfTypes.Saboteur)]
        public void ShouldBeAliveDwarfTypeOf(DwarfTypes dwarfType)
        {
            // given
            var hospital = new Hospital();

            // when
            IDwarf dwarf = hospital.BornDwarf(1, dwarfType);

            // then
            Assert.IsTrue(dwarf.Alive);
        }
    }
}