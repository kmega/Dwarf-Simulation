using DwarfLifeSimulation.ApplicationLogic;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Interfaces;
using DwarfLifeSimulation.Randomizer.DwarfNameRandomizer;
using DwarfLifeSimulation.Randomizer.DwarfTypeRandomizer;
using DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Locations.Hospitals
{
    public class Hospital
    {
        private IIsDwarfBornRandomizer _isDwarfBornRandomizer;
        private IDwarfTypeRandomizer _dwarfTypeRandomizer;

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

        public void Create(SimulationState simulationState)
        {
            if(simulationState.Turn == 1)
            {
                simulationState.Dwarves.AddRange(CreateInitialDwarves());
            }
            else
            {
                simulationState.Dwarves.AddRange(CreateSingleRandomDwarf());
            }
        }
        private List<IDwarf> CreateInitialDwarves()
        {
            return null;
        }
        private List<IDwarf> CreateSingleRandomDwarf()
        {
            List<IDwarf> dwarves = new List<IDwarf>();
            if(_isDwarfBornRandomizer.IsDwarfBorn())
            {
                var type = _dwarfTypeRandomizer.GiveMeDwarfType();
                dwarves.Add(DwarfFactory.Create(type));
            }
            return dwarves;
        }
    }
}
