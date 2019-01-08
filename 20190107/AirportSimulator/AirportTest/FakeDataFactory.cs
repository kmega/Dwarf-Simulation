using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportSimulator;

namespace AirportTest
{
    internal static class FakeDataFactory
    {
        internal static List<Plain> BuildFakePlanes()
        {
            List<Plain> list = new List<Plain>()
            {
                new Plain(1,200),
                new Plain(2, 200),
                new Plain(3, 200),
                new Plain(4, 200),
                new Plain(5, 200),
                new Plain(6, 200)
            };
            return list;
        }

        internal static ControlTower BuildFakeControlTowerWith5Runways()
        {
            ControlTower ct = new ControlTower();
            ct.landingzones.Add(new Runway() { number = 1, IsEnable = true });
            ct.landingzones.Add(new Runway() { number = 2, IsEnable = true });
            ct.landingzones.Add(new Runway() { number = 3, IsEnable = true });
            ct.landingzones.Add(new Runway() { number = 4, IsEnable = true });
            ct.landingzones.Add(new Runway() { number = 5, IsEnable = true });
            return ct;
        }
    }
}
