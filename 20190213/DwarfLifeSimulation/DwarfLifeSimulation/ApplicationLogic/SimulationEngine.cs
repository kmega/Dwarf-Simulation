using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Locations.Canteens;
using DwarfLifeSimulation.Locations.Guilds;
using DwarfLifeSimulation.Locations.Hospitals;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Locations.Shops;
using System.Collections.Generic;

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
            var canteen = new Canteen();
            var shop = new Shop();
            for(; currentSimulationState.turn <= 30; currentSimulationState.turn++)
            {
                //Hospital.CreateDwarves(currentSimaltionState); - updates SimulationState
                hospital.CreateDwarves(currentSimulationState);
                //Mine.Work(IWork workers);
                mine.Work(currentSimulationState.dwarves);
                //Guild.ExchangeResources(??)
                guild.ExchangeResource(currentSimulationState.dwarves);
                //Canteen.ServeFood(int dwarvesCount)
                canteen.ServeFood(currentSimulationState.dwarves.Count);
                //Shop.ServeAllCustomers(IBuy customers);
                shop.ServeAllCustomers(currentSimulationState.dwarves);
            }
        }
    }
}
