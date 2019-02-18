using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Locations.Banks;
using DwarfLifeSimulation.Locations.Canteens;
using DwarfLifeSimulation.Locations.Graveyards;
using DwarfLifeSimulation.Locations.Guilds;
using DwarfLifeSimulation.Locations.Hospitals;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Locations.Shops;
using DwarfLifeSimulation.Loggers;
using System.Collections.Generic;

namespace DwarfLifeSimulation.ApplicationLogic
{
    public class SimulationEngine
    {
        private SimulationState currentSimulationState;
        private ILog logger;

        public SimulationEngine(SimulationState simulationState = null)
        {
            currentSimulationState = (simulationState!=null) ? simulationState : new SimulationState();
            logger = new Logger();
        }

        public void Start()
        {
            var hospital = new Hospital(logger);
            var mine = new Mine(logger);
            var guild = new Guild(logger);
            var canteen = new Canteen();
            var shop = new Shop(logger);
            var graveyard = new Graveyard();
            for(; currentSimulationState.turn <= 30; currentSimulationState.turn++)
            {
                SimulateDay(hospital, mine, guild, canteen, shop, graveyard);
            }
			currentSimulationState._deadDwarves = graveyard.DeadDwarvesAmount;
			currentSimulationState._shopState = shop._shopState;
			currentSimulationState._extractedOre = guild.GetOveralResources();
			currentSimulationState._shopBankAccount = Bank.Instance.GetOverallAccountMoney(shop._bankAccountId);
			currentSimulationState._guildBankAccount = Bank.Instance.GetOverallAccountMoney(guild.bankAccountId);
			currentSimulationState._taxBankAccount = Bank.Instance.generalAccount.OverallMoney;
			currentSimulationState._numberOfBirths = hospital.GetNumberOfBirths();
			logger.DisplayReport(currentSimulationState);
			System.Console.ReadLine();
        }

        public void SimulateDay(Hospital hospital, Mine mine, Guild guild, Canteen canteen, Shop shop, Graveyard graveyard)
        {
            currentSimulationState.dwarves.ForEach(d => d._hasWorked = false);
            //Hospital.CreateDwarves(currentSimaltionState); - updates SimulationState
            hospital.CreateDwarves(currentSimulationState);
            //Mine.Work(IWork workers);
            List<IWork> workers = new List<IWork>();
            currentSimulationState.dwarves.ForEach(d => workers.Add(d));
            mine.Work(workers);
            //Graveyard.BuryAllDead();
            graveyard.BuryDeadDwarves(currentSimulationState.dwarves);
            //Guild.ExchangeResources(??)
            List<IExchange> exchangers = new List<IExchange>();
            currentSimulationState.dwarves.ForEach(d => exchangers.Add(d));
            guild.ExchangeResource(exchangers);
            //Canteen.ServeFood(int dwarvesCount)
            canteen.ServeMultipleRations(currentSimulationState.dwarves.Count);
            //Shop.ServeAllCustomers(IBuy customers);
            List<IBuy> customers = new List<IBuy>();
            currentSimulationState.dwarves.ForEach(d => customers.Add(d));
            shop.ServeAllCustomers(customers);
            Bank.Instance.TransferSavings();
        }
    }
}
