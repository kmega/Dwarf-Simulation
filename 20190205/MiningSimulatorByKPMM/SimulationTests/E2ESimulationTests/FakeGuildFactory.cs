
using MiningSimulatorByKPMM.Locations.Guild;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationTests.E2ESimulationTests
{
    internal class FakeGuildFactory
    {
        internal static Guild Create(ICreateOreValue value)
        {
            return new Guild(value);
        }

    }
}
