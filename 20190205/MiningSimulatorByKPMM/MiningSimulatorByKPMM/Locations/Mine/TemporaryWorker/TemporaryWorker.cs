using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.PersonalItems;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public partial class MineSupervisor
    {
        public class TemporaryWorker
        {
            public Backpack backpack;
            public E_DwarfType type;
            public bool isAlive;

            public TemporaryWorker(Backpack backpack, E_DwarfType type, bool isalive)
            {
                this.backpack = backpack;
                this.type = type;
                this.isAlive = isalive;
            }

            public override string ToString()
            {
                return type.ToString();
            }
        }
    }
}