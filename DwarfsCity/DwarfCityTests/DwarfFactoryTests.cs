using System;
using System.Collections.Generic;
using System.Text;
using DwarfsCity.DwarfContener;
using DwarfsCity.DwarfContener.DwarfEquipment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Type = DwarfsCity.DwarfContener.Type;

namespace DwarfCityTests
{
    [TestClass]
    public class DwarfFactoryTests
    {
        [TestMethod]
        public void CreateOneDwarfOfEachType_FatherSonLazySaboteur()
        {
            //given
            DwarfFactory factory = new DwarfFactory();

            //when
            var father = factory.CreateADwarf(Type.Father);
            var single = factory.CreateADwarf(Type.Single);
            var lazy = factory.CreateADwarf(Type.Lazy);
            var saboteur = factory.CreateADwarf(Type.Saboteur);

            //then
            Assert.IsTrue(father.Attribute == Type.Father);
            Assert.IsTrue(single.Attribute == Type.Single);
            Assert.IsTrue(lazy.Attribute == Type.Lazy);
            Assert.IsTrue(saboteur.Attribute == Type.Saboteur);

        }

        [TestMethod]
        public void CreateADwarfWith10MoneyAndMithrilInBackpack()
        {
            //given
            DwarfFactory factory = new DwarfFactory();

            //when
            var dwarf = factory.CreateADwarf(Type.Father,money:10,items:new List<Item>() { Item.Mithril });
            

            //then
            Assert.IsTrue(dwarf.Attribute == Type.Father);
            Assert.IsTrue(dwarf.Backpack.Money == 10);
            Assert.IsTrue(dwarf.Backpack.Items[0] == Item.Mithril);
           
        }

        [TestMethod]
        public void Create10DwarfsOfFatherType()
        {
            //given
            DwarfFactory factory = new DwarfFactory();

            //when
            var fathers = factory.CreateMultipleDwarfs(numberOfDwarfs: 10, attribute: Type.Father);
            

            //then
            Assert.IsTrue(fathers[0].Attribute == Type.Father);
            Assert.IsTrue(fathers.Count == 10);
            

        }
    }
}
