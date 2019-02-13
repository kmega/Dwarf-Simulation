using DwarfLifeSimulation.ApplicationLogic;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Interfaces;
using DwarfLifeSimulation.Randomizer.DwarfTypeRandomizer;
using DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer;
using System.Collections.Generic;

namespace DwarfLifeSimulation.Locations.Hospitals
{
    public class Hospital
    {
        private IIsDwarfBornRandomizer _isDwarfBornRandomizer;
        private IDwarfTypeRandomizer _dwarfTypeRandomizer;

        #region Contructors

        public Hospital(IIsDwarfBornRandomizer isDwarfBornRandomizer, 
            IDwarfTypeRandomizer dwarfTypeRandomizer)
        {
            SetInitialGenerators(isDwarfBornRandomizer,
                dwarfTypeRandomizer);           
        }
        public Hospital()
        {
            SetInitialGenerators(new DwarfBornGenerationStrategy(),
              new DwarfTypeGenerationStrategy()); 
        }
        private void SetInitialGenerators(IIsDwarfBornRandomizer isDwarfBornRandomizer,
            IDwarfTypeRandomizer dwarfTypeRandomizer)
        {
            _isDwarfBornRandomizer = isDwarfBornRandomizer;
            _dwarfTypeRandomizer = dwarfTypeRandomizer;
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
                dwarves.Add(DwarfFactory.Create(type));
            }
            return dwarves;
        }
        private List<IDwarf> CreateSingleRandomDwarf()
        {
            List<IDwarf> dwarves = new List<IDwarf>();
            if(_isDwarfBornRandomizer.IsDwarfBorn())
            {
                var type = _dwarfTypeRandomizer.GiveMeDwarfType(omitSuicider: false);
                dwarves.Add(DwarfFactory.Create(type));
            }
            return dwarves;
        }
    }
}
