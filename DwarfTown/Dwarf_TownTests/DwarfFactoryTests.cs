using Dwarf_Town.DwarfStrategies.BuyingStrategy;
using Dwarf_Town.DwarfStrategies.WorkingStrategy;
using Dwarf_Town.Interfaces.SellingStrategy;
using Dwarf_Town.Models;
using NUnit.Framework;



namespace Dwarf_TownTests
{
    [TestFixture]
    public class DwarfFactoryTests
    {
        [Test]
        public void CreateDiffrentDwarves()
        {
            ////when
            //var dwarfOne = DwarfFactory.CreateDwarf(1);
            //var dwarfTwo = DwarfFactory.CreateDwarf(34);
            //var dwarfThree = DwarfFactory.CreateDwarf(67);
            //var dwarfFour = DwarfFactory.CreateDwarf(100);


            ////then
            //Assert.IsTrue(dwarfOne.WorkStrategy.GetType() == typeof(SuicideStrategy));
            //Assert.IsTrue((dwarfTwo.WorkStrategy.GetType() == typeof(DigStrategy))
            //    && (dwarfTwo.BuyStrategy.GetType() == typeof(FoodBuyingStrategy)) 
            //    && (dwarfTwo.SellStrategy.GetType() == typeof(StandardSellingStrategy)));
            //Assert.IsTrue((dwarfThree.WorkStrategy.GetType() == typeof(DigStrategy))
            //   && (dwarfThree.BuyStrategy.GetType() == typeof(AlcoholBuyingStrategy))
            //   && (dwarfThree.SellStrategy.GetType() == typeof(StandardSellingStrategy)));
            //Assert.IsTrue((dwarfFour.WorkStrategy.GetType() == typeof(DigStrategy))
            //  && (dwarfFour.BuyStrategy.GetType() == typeof(NothingBuyingStrategy))
            // && (dwarfFour.SellStrategy.GetType() == typeof(StandardSellingStrategy)));


        }
    }
}