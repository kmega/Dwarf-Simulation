using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiningSimulatorByKPMM.ApplicationLogic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Hospital;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationTests.E2ESimulationTests
{
    [TestClass]
    class End2EndTests
    {
        private Mock<IBirthChanceRandomizer> birthChanceMock = new Mock<IBirthChanceRandomizer>();
        private Mock<IDwarfTypeRandomizer> dwarfTypeGeneratorMock = new Mock<IDwarfTypeRandomizer>();
        private Mock<ICreateOreValue> oreValueMock = new Mock<ICreateOreValue>();

        private void SetOreValueMock(int value)
        {
            oreValueMock.Setup(random => random.GenerateSingleValue()).Returns(value);
        }
        private void SetBirthMock(bool result)
        {
            birthChanceMock.Setup(random => random.IsDwarfBorn()).Returns(result);
        }
        private void SetDwarfTypeMock(E_DwarfType result)
        {
            dwarfTypeGeneratorMock.Setup(random => random.GenerateType()).Returns(result);
        }

        [TestMethod]
        public void FullSimulationWhen10DwarfFathersWith1DigAlwaysMineGoldWorth10NoneBirths()
        {
            //given   
            SetBirthMock(false);
            SetDwarfTypeMock(E_DwarfType.Dwarf_Father);
            SetOreValueMock(10);
            var hospital = FakeHospitalFactory.Create(birthChanceMock.Object, dwarfTypeGeneratorMock.Object);
            var guild = FakeGuildFactory.Create(oreValueMock.Object);
            var simulationEngine = new SimulationEngine();
            //when
            simulationEngine.Start();
            //then

            Assert.Fail();
        }

    }
}
