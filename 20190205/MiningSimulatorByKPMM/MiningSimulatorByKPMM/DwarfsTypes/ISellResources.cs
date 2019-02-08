using MiningSimulatorByKPMM.PersonalItems;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public interface ISellResources
    {
        Backpack ShowBackpack();
        void GetMoney(decimal income);
    }
}