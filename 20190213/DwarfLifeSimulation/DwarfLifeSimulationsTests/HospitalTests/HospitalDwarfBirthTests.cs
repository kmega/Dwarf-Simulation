using DwarfLifeSimulation.ApplicationLogic;
using DwarfLifeSimulation.Dwarves.BuyStrategies;
using DwarfLifeSimulation.Dwarves.WorkStrategies;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Hospitals;
using DwarfLifeSimulation.Randomizer.DwarfNameRandomizer;
using DwarfLifeSimulation.Randomizer.DwarfTypeRandomizer;
using DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer;
using Moq;
using NUnit.Framework;

namespace DwarfLifeSimulationsTests.HospitalTests
{
    internal class HospitalDwarfBirthTests
    {
        private Mock<IIsDwarfBornRandomizer> isDwarfBornMock;
        private Mock<IDwarfTypeRandomizer> dwarfTypeMock;
        private Hospital hospital;
        [SetUp]
        public void Setup()
        {
            isDwarfBornMock = new Mock<IIsDwarfBornRandomizer>();
            isDwarfBornMock.Setup(x => x.IsDwarfBorn(100)).Returns(true);   //100 added cause randomizer uses it as optional arg
            dwarfTypeMock = new Mock<IDwarfTypeRandomizer>();
            dwarfTypeMock.Setup(x => x.GiveMeDwarfType(true)).Returns(DwarfType.Father);
        }

        [Test]
        public void T100_ShouldBuild10DwarfFathersWhenTurnEquals1()
        {
            //given
            SimulationState simulationState = new SimulationState();
            hospital = new Hospital(isDwarfBornMock.Object, dwarfTypeMock.Object);
            //when
            hospital.CreateDwarves(simulationState);
            //then            
            foreach (var dwarf in simulationState.dwarves)
            {
                Assert.IsTrue(dwarf._dwarfType == DwarfType.Father);
            }
        }

        [Test]
        public void T101_ShouldBuild1SingleDwarfWhenTurnNotEquals1()
        {
            //given
            SimulationState simulationState = new SimulationState();
            simulationState.turn = 2;
            dwarfTypeMock.Setup(x => x.GiveMeDwarfType(false)).Returns(DwarfType.Single);
            hospital = new Hospital(isDwarfBornMock.Object, dwarfTypeMock.Object);
            //when
            hospital.CreateDwarves(simulationState);
            //then            
            Assert.IsTrue(simulationState.dwarves[0]._dwarfType == DwarfType.Single);
        }
        [Test]
        public void T102_ShouldBuild1SingleDwarfWhenTurnNotEquals1()
        {
            //given
            SimulationState simulationState = new SimulationState();
            simulationState.turn = 2;
            dwarfTypeMock.Setup(x => x.GiveMeDwarfType(false)).Returns(DwarfType.Suicide);
            hospital = new Hospital(isDwarfBornMock.Object, dwarfTypeMock.Object);
            //when
            hospital.CreateDwarves(simulationState);
            //then            
            Assert.IsTrue(simulationState.dwarves[0]._dwarfType == DwarfType.Suicide);
        }

    }
}
