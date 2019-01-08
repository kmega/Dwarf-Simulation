using System;
using System.Collections.Generic;
using AirportSimulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirportTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsplainGetAnswerFromControlToweraboutlandingzone()
        {
            Plain plain = new Plain(1,200);
            ControlTower ct = new ControlTower();
            ct.landingzones.Add(new Runway() { number = 1, IsEnable = true });

            int result = ct.SearchFreeRunaway();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void IsOnePlainLandwithOneRunaway()
        {
            Plain plain = new Plain(1,200);
            ControlTower ct = new ControlTower();
            ct.landingzones.Add(new Runway() { number = 1, IsEnable = true });
            plain.AskForFreeRunaway(ct,0);

            Assert.AreEqual(0, ct.SearchFreeRunaway());           
        }

        [TestMethod]
        public void SecondPlainDontLand()
        {
            Plain plain1 = new Plain(1,200);
            Plain plain2 = new Plain(1,200);
            ControlTower ct = new ControlTower();
            ct.landingzones.Add(new Runway() { number = 1, IsEnable = true });
            plain1.AskForFreeRunaway(ct, 0);
            bool answer = plain2.AskForFreeRunaway(ct, 0);

            Assert.IsFalse(answer);
        }
        [TestMethod]
        public void SecondPlainLandOnSecondRunaway()
        {
            Plain plain1 = new Plain(1,200);
            Plain plain2 = new Plain(2,200);
        
            ControlTower ct = new ControlTower();
            ct.landingzones.Add(new Runway() { number = 1, IsEnable = true });
            ct.landingzones.Add(new Runway() { number = 2, IsEnable = true });
          

            plain1.AskForFreeRunaway(ct, 0);
            bool answer = plain2.AskForFreeRunaway(ct,0);

            Assert.IsTrue(answer);
            Assert.AreEqual(0, ct.SearchFreeRunaway());
        }
        [TestMethod]
        public void SixthPlainwillland()
        {
           List<Plain> planes = FakeDataFactory.BuildFakePlanes();
           ControlTower ct = FakeDataFactory.BuildFakeControlTowerWith5Runways();
            bool answer = false;
            foreach(var plane in planes)
            {
                answer = plane.AskForFreeRunaway(ct,0);
                ct.RunwayCleaner();
            }

            Assert.IsTrue(answer);
            Assert.AreEqual(1, ct.SearchFreeRunaway());
        }
        [TestMethod]
        public void PlaneCrashCompilationGetResult1()
        {
            List<Plain> listofplain = new List<Plain>();
            SimulationReport actualReport = new AirportSimulation().Simulate(5);
            Assert.AreEqual(1, actualReport.CrashedPlanes);
            Assert.AreEqual(8, actualReport.TotalIterations);
        }
    }
}
