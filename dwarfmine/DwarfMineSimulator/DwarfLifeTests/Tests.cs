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
            var hospital = new Hospital();
            IDwarf dwarf = hospital.BornDwarf(1, dwarfType);
            Assert.IsTrue(dwarf.DwarfType() == dwarfType);
        }
    }
}