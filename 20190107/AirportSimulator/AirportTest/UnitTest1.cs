using System;
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
            Plain plain = new Plain(1);
            ControlTower ct = new ControlTower();
            ct.landingzones.Add(new Runway() { number = 1, IsEnable = true });

            int result = ct.SearchFreeRunaway();


            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void IsOnePlainLandwithOneRunaway()
        {
            Plain plain = new Plain(1);
            ControlTower ct = new ControlTower();
            ct.landingzones.Add(new Runway() { number = 1, IsEnable = true });
            plain.AskForFreeRunaway(ct);

            Assert.AreEqual(0, ct.SearchFreeRunaway());           
        }

        [TestMethod]
        public void SecondPlainDontLand()
        {
            Plain plain1 = new Plain(1);
            Plain plain2 = new Plain(1);
            ControlTower ct = new ControlTower();
            ct.landingzones.Add(new Runway() { number = 1, IsEnable = true });
            plain1.AskForFreeRunaway(ct);
            bool answer = plain2.AskForFreeRunaway(ct);

            Assert.IsFalse(answer);
        }
        [TestMethod]
        public void SecondPlainLandOnSecondRunaway()
        {
            Plain plain1 = new Plain(1);
            Plain plain2 = new Plain(2);
        
            ControlTower ct = new ControlTower();
            ct.landingzones.Add(new Runway() { number = 1, IsEnable = true });
            ct.landingzones.Add(new Runway() { number = 2, IsEnable = true });
          

            plain1.AskForFreeRunaway(ct);
            bool answer = plain2.AskForFreeRunaway(ct);

            Assert.IsTrue(answer);
            Assert.AreEqual(0, ct.SearchFreeRunaway());
        }



        [TestMethod]
        public void SixthPlainwillland()
        {
            Plain plain1 = new Plain(1);
            Plain plain2 = new Plain(2);
            Plain plain3 = new Plain(3);
            Plain plain4 = new Plain(4);
            Plain plain5 = new Plain(5);
            Plain plain6 = new Plain(6);
            ControlTower ct = new ControlTower();
            ct.landingzones.Add(new Runway() { number = 1, IsEnable = true });
            ct.landingzones.Add(new Runway() { number = 2, IsEnable = true });
            ct.landingzones.Add(new Runway() { number = 3, IsEnable = true });
            ct.landingzones.Add(new Runway() { number = 4, IsEnable = true });
            ct.landingzones.Add(new Runway() { number = 5, IsEnable = true });
        
            plain1.AskForFreeRunaway(ct);
            ct.RunwayCleaner();
            plain2.AskForFreeRunaway(ct);
            ct.RunwayCleaner();
            plain3.AskForFreeRunaway(ct);
            ct.RunwayCleaner();
            plain4.AskForFreeRunaway(ct);
            ct.RunwayCleaner();
            plain5.AskForFreeRunaway(ct);
            ct.RunwayCleaner();
            bool answer = plain6.AskForFreeRunaway(ct);
            ct.RunwayCleaner();

            Assert.IsTrue(answer);
            Assert.AreEqual(2, ct.SearchFreeRunaway());



        }

    }
}
