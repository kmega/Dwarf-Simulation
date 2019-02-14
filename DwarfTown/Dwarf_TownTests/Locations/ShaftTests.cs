using System;
using System.Collections.Generic;
using System.Text;
using Dwarf_Town;
using Dwarf_Town.DwarfStrategies.WorkingStrategy;
using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Locations.Mine;
using Moq;
using NUnit.Framework;



namespace Dwarf_TownTests.Locations
{
    [TestFixture]
    public class ShaftTests
    {
        [Test]
        public void DropDiffrentOres()
        {
           

            //when
            var mineralOne = GiveSpecificOre.GetTheOre(5);
            var mineralTwo = GiveSpecificOre.GetTheOre(20);
            var mineralThree = GiveSpecificOre.GetTheOre(55);
            var mineralFour = GiveSpecificOre.GetTheOre(100);

            //then
            Assert.IsTrue(mineralOne == MineralType.Mithril);
            Assert.IsTrue(mineralTwo == MineralType.Gold);
            Assert.IsTrue(mineralThree == MineralType.Silver);
            Assert.IsTrue(mineralFour == MineralType.DirtyGold);

        }

        [Test]
        public void DwarfBroughtOutThreeGold()
        {
            //given
            Shaft shaft = new Shaft();
            Dwarf dwarf = new Dwarf();
            Mock<IWork> workingDwarf = new Mock<IWork>();
            workingDwarf.Setup(i => i.Dig()).Returns(3);
            workingDwarf.Setup(i => i.GenerateChance(It.IsAny<int>(), It.IsAny<int>())).Returns(20);
            workingDwarf.Setup(i => i.HideToBackpack(It.IsAny<MineralType>())).Callback((MineralType ore) =>
            {
                dwarf.Backpack.AddOre(ore);
            });

            //when
            shaft.SendDwarvesDown(new List<IWork>() { workingDwarf.Object });
            shaft.PerformWork();

            //then
            Assert.IsTrue(dwarf.Backpack.ShowBackpack().Count==3);
            foreach (var ore in dwarf.Backpack.ShowBackpack())
            {
                Assert.IsTrue(ore == MineralType.Gold);
            }
        }

        [Test]
        public void SuicideDestroyShaft()
        {
            //given
            Shaft shaft = new Shaft();
            Dwarf dwarf = new Dwarf();
            IWork WorkingDwarf = new SuicideStrategy(dwarf);

            //when
            shaft.SendDwarvesDown(new List<IWork>() { WorkingDwarf});
            shaft.PerformWork();

            //then
            Assert.IsFalse(shaft.EfficientShaft);
            Assert.IsFalse(WorkingDwarf.AskAboutLife());


        }

    }
}
