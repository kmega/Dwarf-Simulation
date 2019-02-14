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
            City city = Configurator.PrepareCityToSimulation();
            List<Dwarf> dwarfs = new List<Dwarf>();
            dwarfs.Add(new Dwarf(TypeEnum.Father));
            dwarfs.Add(new Dwarf(TypeEnum.Lazy));
            dwarfs.Add(new Dwarf(TypeEnum.Single));
            dwarfs.Add(new Dwarf(TypeEnum.Father));
            dwarfs.Add(new Dwarf(TypeEnum.Lazy));

            //When
            city.mine.StartWorking(dwarfs);

            //Then
            Assert.AreEqual(city)
        }
    }
}
