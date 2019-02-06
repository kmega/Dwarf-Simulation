using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Interfaces;
using MiningSimulatorByKPMM.Locations.Hospital;
using Moq;
using System.Collections.Generic;

namespace SimulationTests.Hospital_Tests
{
    [TestClass]
    public class HospitalTests
    {
        private Mock<IRandomGenerator> randomGenerator = new Mock<IRandomGenerator>();
        private Mock<IRandomGenerator> randomGenerator2 = new Mock<IRandomGenerator>();

        private List<IRandomGenerator> SetRandomMocks(int resultOfFirstGenerator, int resultOfSecondGenerator)
        {
            randomGenerator.Setup(x => x.GenerateSignleRandomNumber()).Returns(resultOfFirstGenerator);
            randomGenerator2.Setup(x => x.GenerateSignleRandomNumber()).Returns(resultOfSecondGenerator);
            return new List<IRandomGenerator>()
            {
                randomGenerator.Object, randomGenerator2.Object
            };
        }

        [TestMethod]
        public void ShouldCreateSuicideDwarf()
        {
            //given   
            var hospital = new Hospital(SetRandomMocks(0,0));
            //when
            var result = hospital.TryToCreateDwarf();
            //then
            Assert.AreEqual(result.DwarfType, E_DwarfType.Dwarf_Suicide);
        }
        [TestMethod]
        public void ShouldCreateFatherDwarf()
        {
            //given
            var hospital = new Hospital(SetRandomMocks(0,13));
            //when
            var result = hospital.TryToCreateDwarf();
            //then
            Assert.AreEqual(result.DwarfType, E_DwarfType.Dwarf_Father);
        }
        [TestMethod]
        public void ShouldReturnNullWhenFirstRandomReturnDifferentThan0()
        {
            //given
            var hospital = new Hospital(SetRandomMocks(12, 13));
            //when
            var result = hospital.TryToCreateDwarf();
            //then
            Assert.IsNull(result);
        }
    }
}

