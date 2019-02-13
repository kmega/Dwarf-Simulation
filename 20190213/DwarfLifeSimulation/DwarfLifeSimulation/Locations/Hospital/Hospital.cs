using DwarfLifeSimulation.ApplicationLogic;
using DwarfLifeSimulation.Interfaces;
using DwarfLifeSimulation.Randomizer.DwarfNameRandomizer;
using DwarfLifeSimulation.Randomizer.DwarfTypeRandomizer;
using DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Locations.Hospital
{
    public class Hospital
    {
        private IIsDwarfBornRandomizer _isDwarfBornRandomizer;
        private IDwarfTypeRandomizer _dwarfTypeRandomizer;
        private IDwarfNameRandomizer _dwarfNameRandomizer;

        public Hospital(IIsDwarfBornRandomizer isDwarfBornRandomizer, 
            IDwarfTypeRandomizer dwarfTypeRandomizer, 
            IDwarfNameRandomizer dwarfNameRandomizer)
        {
            SetInitialGenerators(isDwarfBornRandomizer,
                dwarfTypeRandomizer, dwarfNameRandomizer);           
        }
        public Hospital()
        {
            SetInitialGenerators(new DwarfBornGenerationStrategy(),
              new DwarfTypeGenerationStrategy(), new DwarfNameGenerationStrategy()); 
        }
        private void SetInitialGenerators(IIsDwarfBornRandomizer isDwarfBornRandomizer,
            IDwarfTypeRandomizer dwarfTypeRandomizer,
            IDwarfNameRandomizer dwarfNameRandomizer)
        {
            _isDwarfBornRandomizer = isDwarfBornRandomizer;
            _dwarfTypeRandomizer = dwarfTypeRandomizer;
            _dwarfNameRandomizer = dwarfNameRandomizer;
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
            return null;
        }
    }
}
