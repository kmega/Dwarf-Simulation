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
        private readonly ISchaftOperator _schaftOperator;
        private List<MiningSchaft> Schafts;
        private List<Backpack> _workingBackpackList = new List<Backpack>();
        private List<E_DwarfType> _workingTypeList = new List<E_DwarfType>();
        private List<bool> _workingBools = new List<bool>();
        private List<TemporaryWorker> _allWorkers = new List<TemporaryWorker>();
        private List<TemporaryWorker> _previousShiftOfMine;

        public Dictionary<E_Minerals, int> MineSupervisorStats { get; set; } = new Dictionary<E_Minerals, int>()
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

        public MineSupervisor(ISchaftOperator schaftOperator, IOreUnitAmountRandomizer oreUnitAmountRandomizer, IOreRandomizer oreRandomizer)
        {
            this._schaftOperator = schaftOperator;
            this._oreUnitAmountRandomizer = oreUnitAmountRandomizer;
            this._oreRandomizer = oreRandomizer;
            Schafts = SchaftFactory.CreateTwoSchafts();
        }

        public MineSupervisor()
        {
            Schafts = SchaftFactory.CreateTwoSchafts();
        }

        public void Work(ref List<Backpack> backpackList, List<E_DwarfType> typeList, ref List<bool> isAliveList)
        {
            new SchaftMender().FixSchafts(Schafts);
            _allWorkers = new TemporaryWorkerFactory().CreateListTemporaryWorkersFromParameters(backpackList, typeList, isAliveList);
            new WorkProcessor().ProcessWork(Schafts, _allWorkers, _oreRandomizer, _oreUnitAmountRandomizer);
            (_allWorkers, MineSupervisorStats) = new MineStatsUpdater().UpdateDailyStats(_allWorkers, MineSupervisorStats);
            new TemporaryWorkerUnpacker().ChangesStatesFromUnpackedTemporaryWorkers(backpackList, typeList, isAliveList, _allWorkers);
            //isAliveList = UnwrapAllWorkersAndChangeStatesOfParameters(backpackList, typeList, isAliveList);
            _previousShiftOfMine = new List<TemporaryWorker>(_allWorkers);
            _allWorkers.Clear();
        }

        public class TemporaryWorkerUnpacker
        {
            public void ChangesStatesFromUnpackedTemporaryWorkers(List<Backpack> backpackList, List<E_DwarfType> typeList, List<bool> isAliveList, List<TemporaryWorker> _allWorkers)
            {
                List<Backpack> unwrappedBackpacks = new List<Backpack>();
                List<E_DwarfType> unwrappedTypeLists = new List<E_DwarfType>();
                List<bool> unwrappedIsAliveList = new List<bool>();

                _allWorkers.ForEach(x => unwrappedBackpacks.Add(x.backpack));
                _allWorkers.ForEach(x => unwrappedTypeLists.Add(x.type));
                _allWorkers.ForEach(x => unwrappedIsAliveList.Add(x.isAlive));

                backpackList = unwrappedBackpacks;
                typeList = unwrappedTypeLists;
                isAliveList = unwrappedIsAliveList;
            }
        }

        private List<bool> UnwrapAllWorkersAndChangeStatesOfParameters(List<Backpack> backpackList, List<E_DwarfType> typeList, List<bool> isAliveList)
        {
            List<Backpack> unwrappedBackpacks = new List<Backpack>();
            List<E_DwarfType> unwrappedTypeLists = new List<E_DwarfType>();
            List<bool> unwrappedIsAliveList = new List<bool>();

            _allWorkers.ForEach(x => unwrappedBackpacks.Add(x.backpack));
            _allWorkers.ForEach(x => unwrappedTypeLists.Add(x.type));
            _allWorkers.ForEach(x => unwrappedIsAliveList.Add(x.isAlive));

            backpackList = unwrappedBackpacks;
            typeList = unwrappedTypeLists;
            //isAliveList = unwrappedIsAliveList;

            return unwrappedIsAliveList;
        }
    }
}