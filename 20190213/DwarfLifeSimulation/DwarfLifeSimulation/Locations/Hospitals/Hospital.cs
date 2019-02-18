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
        public int NumberOfBirths { get; private set; }

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
            NumberOfBirths = 0;
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
                NumberOfBirths++;
                _logger.AddLog($"{type} has been born.");
            }
            return dwarves;
        }
    }
}
