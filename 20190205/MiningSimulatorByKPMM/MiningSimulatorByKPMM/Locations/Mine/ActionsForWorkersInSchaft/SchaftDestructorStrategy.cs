using MiningSimulatorByKPMM.Locations.Mine.Interfaces;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace MiningSimulatorByKPMM.Locations.Mine.SubMineLocations
{

    public partial class MiningSchaft
    {
        public class SchaftDestructorStrategy : ISchaftStrategy
        {
            void ISchaftStrategy.DoWork(TemporaryWorker worker, IOreRandomizer oreRandomizer, IOreUnitAmountRandomizer oreUnitAmountRandomizer)
            {
                worker.isAlive = false;
            }
        }

    }
}
