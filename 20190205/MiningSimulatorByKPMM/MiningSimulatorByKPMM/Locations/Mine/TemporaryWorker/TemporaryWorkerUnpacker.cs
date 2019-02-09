using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.PersonalItems;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public partial class MineSupervisor
    {
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
    }
}