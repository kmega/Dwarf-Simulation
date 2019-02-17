using System.Collections.Generic;
using System.Linq;

namespace Mine2._0
{
    public class SimulationEngine
    {
        public SimulationState simulationState;
        private readonly int _simulationDuaration;
        private Hospital _hospital { get; }
        private Mine _mine { get; }
        private Guild _guild { get; }
        private Canteen _canteen { get; }
        private MarketPlace _marketPlace { get; }
        private Bank _bank { get; }
        private ATM _atm { get; }
        public IOutputWriter _presenter { get; }

        public SimulationEngine(int maxSimulationDuaration, IDwarfTypeRandomizer typeRandomizer, ITryBirth isBirthRandomizer)
        {
            _simulationDuaration = maxSimulationDuaration;
            simulationState = new SimulationState();
            _hospital = new Hospital(typeRandomizer, isBirthRandomizer);
            _mine = new Mine(new MineRandomizer());
            _guild = new Guild(new ValueRandomizer());
            _canteen = new Canteen();
            _marketPlace = new MarketPlace();
            _bank = new Bank();
            _atm = new ATM();
            _presenter = new WindowsConsole();
        }

        public SimulationEngine(int maxSimulationDuaration, IDwarfTypeRandomizer typeRandomizer, ITryBirth isBirthRandomizer, IRandomizer mineRandomizer)
        {
            _simulationDuaration = maxSimulationDuaration;
            simulationState = new SimulationState();
            _hospital = new Hospital(typeRandomizer, isBirthRandomizer);
            _mine = new Mine(mineRandomizer);
            _guild = new Guild(new ValueRandomizer());
            _canteen = new Canteen();
            _marketPlace = new MarketPlace();
            _bank = new Bank();
            _atm = new ATM();
            _presenter = new WindowsConsole();
        }

        public SimulationEngine(int maxSimulationDuaration, IDwarfTypeRandomizer typeRandomizer, ITryBirth isBirthRandomizer, IRandomizer mineRandomizer, IGuildRandomizer guildRandomizer, IOutputWriter presenter)
        {
            _simulationDuaration = maxSimulationDuaration;
            simulationState = new SimulationState();
            _hospital = new Hospital(typeRandomizer, isBirthRandomizer);
            _mine = new Mine(mineRandomizer);
            _guild = new Guild(guildRandomizer);
            _canteen = new Canteen();
            _marketPlace = new MarketPlace();
            _bank = new Bank();
            _atm = new ATM();
            _presenter = presenter;
        }

        public void Start(int days = 10)
        {
            _canteen.SetFoodRations(200);
            for (int i = 0; i < _simulationDuaration; i++)
            {
                System.Console.WriteLine();
                _presenter.WriteLine($"Day: {i + 1}");
                System.Console.WriteLine();

                _mine.FixAllSchafts();

                if (i == 0)
                {
                    simulationState._allDwarves.AddRange(_hospital.CreateInitialState(days));
                    foreach (var dwarf in simulationState._allDwarves)
                    {
                        _presenter.WriteLine($"Dwarf: {dwarf.ToString()} was born");
                    }
                }
                else if (_hospital._tryBirthRandomizer.TryBirth())
                {
                    simulationState._allDwarves.Add(_hospital.CreateSingleRandomDwarf());
                    _presenter.WriteLine($"Dwarf: {simulationState._allDwarves.Last()} was born");
                    simulationState._numberOfBirths++;
                }

                List<IWork> works = new List<IWork>(simulationState._allDwarves);
                _mine.PerformMining(works, _presenter);

                _mine.UpdateStats(simulationState._allExtractedMinerals);

                simulationState._numberOfDeadDwarves += simulationState._allDwarves.Count(x => x._isAlive == false);
                simulationState._allDwarves.RemoveAll(x => x._isAlive == false);

                _guild.ExchangeOutputToMoney(new List<IMoneyOperator>(simulationState._allDwarves), _bank, _presenter);
                simulationState._guildBankAccount += _guild._account._overallIncome;
                _guild._account._overallIncome = 0m;

                simulationState._currentDay = i;

                if (_canteen.GetCurrentFoodRationsAmount() - simulationState._allDwarves.Count < 0 || simulationState._allDwarves.All(x => x._isAlive == false))
                {
                    _presenter.WriteLine($"Simulation failed due to breaking conditions");
                    break;
                }

                simulationState._servedFoodRations += _canteen.ServeFoodRaitons(simulationState._allDwarves.Count);
                _canteen.OrderFoodRationsIfNecessary();

                List<IBuy> buyers = new List<IBuy>(simulationState._allDwarves);
                _marketPlace.PerformShopping(buyers, _presenter);
                simulationState._boughtProducts = _marketPlace.GetStats();
                simulationState._marketAccount += _marketPlace.GetOverAllAccount();

                _atm.TransferDailyWageToOverall(new List<IMoneyOperator>(simulationState._allDwarves));
            }
            simulationState._taxBankAccount = _bank.GetCurretnTax();

            System.Console.WriteLine();
            _presenter.WriteLine($"*****\tRESULTS\t*****");
            _presenter.WriteLine($"During simulation {simulationState._numberOfBirths} dwarves was born");
            _presenter.WriteLine($"During simulation died {simulationState._numberOfDeadDwarves} dwarves");

            System.Console.WriteLine();
            if(simulationState._boughtProducts.ContainsKey(E_MarketPlace_Products.Alcohol) || simulationState._boughtProducts.ContainsKey(E_MarketPlace_Products.Food))
            {
                _presenter.WriteLine($"Marketplace statistics:");
                _presenter.WriteLine($"{simulationState._boughtProducts[E_MarketPlace_Products.Alcohol]} units of alcohol was bought");
                _presenter.WriteLine($"{simulationState._boughtProducts[E_MarketPlace_Products.Food]} units of food was bought");
                System.Console.WriteLine();
            }

            _presenter.WriteLine($"Mine statistics:");
            _presenter.WriteLine($"{simulationState._allExtractedMinerals.Count(x => x == E_Minerals.DritGold)} units of DirtGold was mined");
            _presenter.WriteLine($"{simulationState._allExtractedMinerals.Count(x => x == E_Minerals.Gold)} units of Gold was mined");
            _presenter.WriteLine($"{simulationState._allExtractedMinerals.Count(x => x == E_Minerals.Silver)} units of Silver was mined");
            _presenter.WriteLine($"{simulationState._allExtractedMinerals.Count(x => x == E_Minerals.Mithril)} units of Mithril was mined");

            System.Console.WriteLine();
            _presenter.WriteLine($"Guild earned {simulationState._guildBankAccount} units of untaxed money");
            _presenter.WriteLine($"Bank collected {simulationState._taxBankAccount} units of money in taxes");

            System.Console.WriteLine();
            _presenter.WriteLine($"Canteen served {simulationState._servedFoodRations} food rations");
        }
    }
}