
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Guild;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationTests.E2ESimulationTests
{
    internal class FakeGuildFactory
    {
        internal static Guild Create(Dictionary<E_Minerals, ICreateOreValue> oreMarketInformations)
        {
            return new Guild(oreMarketInformations);
        }

    }
}
