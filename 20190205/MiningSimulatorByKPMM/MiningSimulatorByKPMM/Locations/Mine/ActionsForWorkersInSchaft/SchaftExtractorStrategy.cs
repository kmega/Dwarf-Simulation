using MiningSimulatorByKPMM.Locations.Mine.Interfaces;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace MiningSimulatorByKPMM.Locations.Mine.SubMineLocations
{

    public partial class MiningSchaft
    {
        public class SchaftExtractorStrategy : ISchaftStrategy
        {
            void ISchaftStrategy.DoWork(TemporaryWorker worker, IOreRandomizer oreRandomizer, IOreUnitAmountRandomizer oreUnitAmountRandomizer)
            {
                int amountOfOres = oreUnitAmountRandomizer.GetAmountOfOreUnintsToRandom();

                for (int i = 0; i < amountOfOres; i++)
                {
                    worker.backpack.AddSingleOre(oreRandomizer.GetRandomMineral());
                }
            }
        }

    }
}
