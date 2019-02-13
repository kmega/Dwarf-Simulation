using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Interfaces;
using DwarfLifeSimulation.Locations.Guilds;
using DwarfLifeSimulation.Locations.Hospitals;
using DwarfLifeSimulation.Locations.Mines;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.ApplicationLogic
{
    public class SimulationEngine
    {
        private SimulationState currentSimulationState;
        public SimulationEngine()
        {
            currentSimulationState = new SimulationState();
        }

        public void Start()
        {
            var hospital = new Hospital();
            var mine = new Mine();
            var guild = new Guild();
            for(; currentSimulationState.turn <= 30; currentSimulationState.turn++)
            {
                //Hospital.CreateDwarves(currentSimaltionState); - updates SimulationState
                hospital.CreateDwarves(currentSimulationState);
                //Mine.Work(IWork workers);
                mine.Work(currentSimulationState.dwarves);
                //Guild.ExchangeResources(??)
                guild.ExchangeResource(currentSimulationState.dwarves);
                //Canteen.ServeFood(int dwarvesCount)
                
                //Shop.ServeAllCustomers(IBuy customers);


            }
        }
    }
}
