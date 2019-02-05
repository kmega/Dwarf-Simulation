using System;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Market;

namespace MiningSimulatorByKPMM.Interfaces
{
    public interface IShopAction
    {
        void BuyProdcutsFromMarket(decimal dailySalary, Market market);
    }
}
