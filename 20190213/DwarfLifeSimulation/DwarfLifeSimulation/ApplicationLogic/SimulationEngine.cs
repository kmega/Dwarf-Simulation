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
                SimulateDay(hospital, mine, guild, canteen, shop);
            }
        }

        private void SimulateDay(Hospital hospital, Mine mine, Guild guild, Canteen canteen, Shop shop)
        {
            //Hospital.CreateDwarves(currentSimaltionState); - updates SimulationState
            hospital.CreateDwarves(currentSimulationState);
            //Mine.Work(IWork workers);
            List<IWork> workers = new List<IWork>();
            currentSimulationState.dwarves.ForEach(d => workers.Add(d));
            mine.Work(workers);
            //Guild.ExchangeResources(??)
            List<IExchange> exchangers = new List<IExchange>();
            currentSimulationState.dwarves.ForEach(d => exchangers.Add(d));
            guild.ExchangeResource(exchangers);
            //Canteen.ServeFood(int dwarvesCount)
            //canteen.ServeFood(currentSimulationState.dwarves.Count);
            //Shop.ServeAllCustomers(IBuy customers);
            List<IBuy> customers = new List<IBuy>();
            currentSimulationState.dwarves.ForEach(d => customers.Add(d));
            shop.ServeAllCustomers(customers);
        }
    }
}
