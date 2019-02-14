using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Hospital;
using Moq;

namespace SimulationTests.Hospital_Tests
{
    [TestClass]
    public class HospitalTests
    {
        private Mock<IBirthChanceRandomizer> birthChanceMock = new Mock<IBirthChanceRandomizer>();
        private Mock<IDwarfTypeRandomizer> dwarfTypeGeneratorMock = new Mock<IDwarfTypeRandomizer>();

        private void SetBirthMock(bool result)
        {
            birthChanceMock.Setup(random => random.IsDwarfBorn()).Returns(result);
        }
        private void SetDwarfTypeMock(E_DwarfType result)
        {
            dwarfTypeGeneratorMock.Setup(random => random.GenerateType()).Returns(result);
        }

        [TestMethod]
        public void ShouldCreateSuicideDwarf()
        {
            //given   
            SetBirthMock(true);
            SetDwarfTypeMock(E_DwarfType.Dwarf_Suicide);
            var hospital = new Hospital(birthChanceMock.Object, dwarfTypeGeneratorMock.Object);
            //when
            var result = hospital.CreateDwarf();
            //then
            Assert.AreEqual(result[0].DwarfType, E_DwarfType.Dwarf_Suicide);
        }
        [TestMethod]
        public void ShouldCreateFatherDwarf()
        {
            //given
            SetBirthMock(true);
            SetDwarfTypeMock(E_DwarfType.Dwarf_Father);
            var hospital = new Hospital(birthChanceMock.Object, dwarfTypeGeneratorMock.Object);
            //when
            var result = hospital.CreateDwarf();
            //then
            Assert.AreEqual(result[0].DwarfType, E_DwarfType.Dwarf_Father);
        }
        [TestMethod]
        public void ShouldReturnNullWhenFirstRandomReturnDifferentThan0()
        {
            //given
            SetBirthMock(false);
            var hospital = new Hospital(birthChanceMock.Object, dwarfTypeGeneratorMock.Object);
            //when
            var result = hospital.CreateDwarf();
            //then
            Assert.IsTrue(result.Count == 0);
        }
        [TestMethod]
        public void ShouldCreateListOf10DwarfFather()
        {
            //given
            SetDwarfTypeMock(E_DwarfType.Dwarf_Father);
            var hospital = new Hospital(birthChanceMock.Object, dwarfTypeGeneratorMock.Object);
            //when
            var result = hospital.BuildInitialDwarves();
            //then
            Assert.AreEqual(10, result.Count);
            foreach(var dwarf in result)
            {
                Assert.AreEqual(E_DwarfType.Dwarf_Father, dwarf.DwarfType);
            }
        }
    }
}

