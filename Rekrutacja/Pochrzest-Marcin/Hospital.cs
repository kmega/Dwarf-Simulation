using DwarfLifeSimulation.ApplicationLogic;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Loggers;
using DwarfLifeSimulation.Randomizer.DwarfTypeRandomizer;
using DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer;
using System.Collections.Generic;

namespace DwarfLifeSimulation.Locations.Hospitals
{
    public class Hospital
    {
        private IIsDwarfBornRandomizer _isDwarfBornRandomizer;
        private IDwarfTypeRandomizer _dwarfTypeRandomizer;
        private DwarfFactory _dwarfFactory;
        private ILog _logger;
		private int _numberOfBirths;

        #region Contructors

        public Hospital(ILog logger = null, IIsDwarfBornRandomizer isDwarfBornRandomizer = null, 
            IDwarfTypeRandomizer dwarfTypeRandomizer = null)
        {
            _isDwarfBornRandomizer = (isDwarfBornRandomizer != null) 
                ? isDwarfBornRandomizer : new DwarfBornGenerationStrategy();
            _dwarfTypeRandomizer = (dwarfTypeRandomizer != null) ?
                dwarfTypeRandomizer : new DwarfTypeGenerationStrategy();
            _logger = (logger != null) ? logger : new Logger();
            _dwarfFactory = new DwarfFactory();
            _numberOfBirths = 0;
        }
        #endregion

        public void CreateDwarves(SimulationState simulationState)
        {
            if(simulationState.turn == 1)
            {
                simulationState.dwarves.AddRange(CreateInitialDwarves());
            }
            else
            {
                simulationState.dwarves.AddRange(CreateSingleRandomDwarf());
            }
        }
        private List<IDwarf> CreateInitialDwarves()
        {
            List<IDwarf> dwarves = new List<IDwarf>();
            for(int i = 0; i < 10; i++)
            {
                var type = _dwarfTypeRandomizer.GiveMeDwarfType(omitSuicider: true);
                dwarves.Add(_dwarfFactory.Create(type));
            }
            _logger.AddLog("10 dwarves have been born.");
            return dwarves;
        }
        private List<IDwarf> CreateSingleRandomDwarf()
        {
            List<IDwarf> dwarves = new List<IDwarf>();
            if(_isDwarfBornRandomizer.IsDwarfBorn())
            {
                var type = _dwarfTypeRandomizer.GiveMeDwarfType(omitSuicider: false);
                dwarves.Add(_dwarfFactory.Create(type));
                _logger.AddLog($"{type} has been born.");
				_numberOfBirths++;
            }
            return dwarves;
        }

		public int GetNumberOfBirths()
		{
			return _numberOfBirths;
		}
    }
}

//TESTS

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
            hospital = new Hospital(new Logger(),isDwarfBornMock.Object, dwarfTypeMock.Object);
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
            hospital = new Hospital(new Logger(), isDwarfBornMock.Object, dwarfTypeMock.Object);
            //when
            hospital.CreateDwarves(simulationState);
            //then            
            Assert.IsTrue(simulationState.dwarves[0]._dwarfType == DwarfType.Single);
        }
