using DwarfsTown;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DwarfsTownTests
{
    [TestClass]
    public class MineTests
    {
        [TestMethod]
        public void Shaft1ShouldHaveAssign5DwarfsWhenForemanSendDwarfs()
        {
            //Given
            City c = new City();

            Foreaman fm = new Foreaman();
            var dwarves = c.dwarfs;
            Shaft s = new Shaft();

            //When
            fm.SendDwarfsToShaft(dwarves, s);

            //Then
            Assert.AreEqual(s.dwarfs.Count, 5);
        }
        [TestMethod]
        public void DwarfBackpackShouldHave1To3MaterialsAfterDigging()
        {
            //Given
            Dwarf dwarf = new Dwarf(TypeEnum.Father);

            //When
            dwarf.Digging();

            //Then
            Assert.IsTrue(dwarf.Backpack.Materials.Count >= 1);
        }
        [TestMethod]
        public void ShaftDwarfsShouldBeEmptyWhenForeamanLetGoDwarfs()
        {
            //Given
            Shaft shaft = new Shaft();
            shaft.dwarfs.Add(new Dwarf(TypeEnum.Father));
            shaft.dwarfs.Add(new Dwarf(TypeEnum.Father));
            shaft.dwarfs.Add(new Dwarf(TypeEnum.Father));

            Foreaman foreaman = new Foreaman();

            //When
            foreaman.LetGoDwarfs(shaft);

            //Then
            Assert.AreEqual(shaft.dwarfs.Count, 0);
        }
    }
}
