using Dwarf_Town.Interfaces;
using Dwarf_Town.Locations;
using System;

namespace Dwarf_Town
{
    public class SimulationStart

    {
        public Newspapper newspapper = new Newspapper();

        public void Start()
        {
            SimulationStartConditions simulationStartConditions = new SimulationStartConditions(10, 30, 100);
            SimulationState simulationState = new SimulationState();

            Hospital hospital = new Hospital(new Chance());

            simulationState.Dwarves = hospital.GenerateDwarves(simulationStartConditions.DwarvesAtStart);

            for (int i = 0; i < simulationStartConditions.Rounds; i++)
            {
                UpdateSimulationState(simulationState);
            }
        }

        private void UpdateSimulationState(SimulationState simulationState)
        {
            throw new NotImplementedException();
        }
    }
}