using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.DwarfsTypes.BuyStrategies
{
    public interface IBuyAction
    {
        Product Perform(BankAccount bankAccount);        
    }
}
