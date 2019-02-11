using System.Collections.Generic;
using System.Linq;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.ActionsForWorkersInSchaft;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Factories;
using MiningSimulatorByKPMM.Locations.Mine.Interfaces;
using MiningSimulatorByKPMM.Locations.Mine.SubMineLocations;
using MiningSimulatorByKPMM.PersonalItems;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public partial class MineSupervisor
    {
        private readonly IOreRandomizer _oreRandomizer = new OreRandomizer();
        private readonly IOreUnitAmountRandomizer _oreUnitAmountRandomizer = new OreUnitAmountRandomizer();
        private readonly ISchaftStrategy _schaftOperator;
        private List<MiningSchaft> Schafts;
        private List<Backpack> _workingBackpackList = new List<Backpack>();
        private List<E_DwarfType> _workingTypeList = new List<E_DwarfType>();
        private List<bool> _workingBools = new List<bool>();
        private List<TemporaryWorker> _allWorkers = new List<TemporaryWorker>();
        private List<TemporaryWorker> _previousShiftOfMine;

        public MineSupervisor()
        {
            Schafts = SchaftFactory.CreateTwoSchafts();
        }

        public Dictionary<E_Minerals, int> MineSupervisorStats { get; private set; } = new Dictionary<E_Minerals, int>()
        {
            {E_Minerals.DirtGold, 0},
            {E_Minerals.Gold, 0},
            {E_Minerals.Mithril, 0},
            {E_Minerals.Silver, 0},
        };

        public List<TemporaryWorker> GetPreviousShiftOfMine()
        {
            return _previousShiftOfMine;
        }

        public E_MiningSchaftStatus[] GetTwoSchaftsStatus()
        {
            return new E_MiningSchaftStatus[] { Schafts[0].GetSchaftStatus(), Schafts[1].GetSchaftStatus() };
        }

        //ForTests
        public MineSupervisor(ISchaftStrategy schaftOperator, IOreUnitAmountRandomizer oreUnitAmountRandomizer, IOreRandomizer oreRandomizer)
        {
            this._schaftOperator = schaftOperator;
            this._oreUnitAmountRandomizer = oreUnitAmountRandomizer;
            this._oreRandomizer = oreRandomizer;
            Schafts = SchaftFactory.CreateTwoSchafts();
        }

        public void Work(ref List<Backpack> backpackList, List<E_DwarfType> typeList, ref List<bool> isAliveList)
        {
            new SchaftMender().FixSchafts(Schafts);
            _allWorkers = new TemporaryWorkerFactory().CreateListTemporaryWorkersFromParameters(backpackList, typeList, isAliveList);
            new WorkProcessor().ProcessWork(Schafts, _allWorkers, _oreRandomizer, _oreUnitAmountRandomizer);
            new MineStatsUpdater().UpdateDailyStats(_allWorkers, MineSupervisorStats);
            new TemporaryWorkerUnpacker().ChangesStatesFromUnpackedTemporaryWorkers(ref backpackList, ref typeList, ref isAliveList, _allWorkers);
            _previousShiftOfMine = new List<TemporaryWorker>(_allWorkers);
            _allWorkers.Clear();
        }
    }
}