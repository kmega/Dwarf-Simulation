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
            fm.SendDwarfsToTheShaft(dwarves, s);

            //Then
            Assert.AreEqual(s.dwarfs.Count, 5);
        }
        [TestMethod]
        public void DwarfBackpackShouldHave1To3MaterialsAfterDigging()
        {
            //Given
            Dwarf dwarf = new Dwarf(TypeEnum.Father);
            Shaft shaft = new Shaft();

            //When
            dwarf.Working(shaft);

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
        [TestMethod]
        public void AfterStartMineShouldReturn6DwarfsWhenOnIndexNumber3DwarfsIsSabouteur()
        {
            //Given
            City city = new City();

            city.dwarfs.Insert(2, new Dwarf(TypeEnum.Saboteur));

            //When
            city.mine.StartWorking(city.dwarfs);

            //Then
            Assert.AreEqual(city.dwarfs.Count, 6);
        }
        [TestMethod]
        public void ShaftShouldBeDestroyedWhenOnTheShaftIsSaboteur()
        {
            //Given
            Dwarf saboteur = new Dwarf(TypeEnum.Saboteur);
            Shaft shaft = new Shaft();

            //When
            saboteur.Working(shaft);

            //Then
            Assert.AreEqual(shaft.isExist, false);
        }
        [TestMethod]
        public void WhenCommonDwarfWorkingShaftShouldntBeDestroyed()
        {
            //Given
            Dwarf common = new Dwarf(TypeEnum.Father);
            Shaft shaft = new Shaft();

            //When
            common.Working(shaft);

            //Then
            Assert.AreEqual(shaft.isExist, true);
        }
    }
}
