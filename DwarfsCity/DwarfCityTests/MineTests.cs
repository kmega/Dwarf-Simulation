using DwarfsCity.DwarfContener;
using DwarfsCity.MineContener;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfCityTests
{
    [TestClass]
    public class MineTests
    {
        [TestMethod]
        public void ShaftShouldHaveExistAttrEqualsFalseWhenOnTheShaftIsSaboteur()
        {
            //Given
            List<Dwarf> saboteurDwarf = new List<Dwarf>() { new Dwarf() { Attribute = DwarfsCity.DwarfContener.Type.Saboteur } };
            Shaft shaft = new Shaft();
            var mock = new Mock<IForeman>();
            mock.Setup(foreman => foreman.SendDwarfsToShaft(saboteurDwarf, shaft));
            
            //When
            

        }
    }
}
