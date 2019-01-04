using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeaPrograms;

namespace TeaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSortTeaInformation()
        {
            List<ListTeaClass> informatioAboutTea = new List<ListTeaClass>();
            informatioAboutTea.Add(new ListTeaClass
            {
                teaName = "Gunpowder Czarny",
                typeTea = "czarna",
                boilingpoint = "90",
                boilingTime = "3"
            });

            informatioAboutTea.Add(new ListTeaClass
            {
                teaName = "Gunpowder Zielony",
                typeTea = "zielona",
                boilingpoint = "70",
                boilingTime = "3"
            });

            var newList = informatioAboutTea.OrderBy(x => x.typeTea).ToList();
            Assert.AreEqual(newList[0].typeTea, "czarna");
        }

        [TestMethod]
        public void TestReverseTeaInformation()
        {
            DataTestInformation testingData = new DataTestInformation();
            var informatioAboutTea = testingData.InformationTest();

            informatioAboutTea.Reverse();
            Assert.AreEqual(informatioAboutTea[0].typeTea, "napar");
        }

        [TestMethod]
        public void TestMakeATeaWhenMintHave96Temperatureand300secondsresultPerfect()
        {
            DataTestInformation testingData = new DataTestInformation();
            var informatioAboutTea = testingData.InformationTest();

            MakeATeaTask make = new MakeATeaTask();

            string quality = make.QualityTea(informatioAboutTea, 96, 300);
            Assert.AreEqual(quality, "Perfect");
        }

        [TestMethod]
        public void TestMakeATeaWhenMintHave91Temperatureand310secondsresultPerfect()
        {
            DataTestInformation testingData = new DataTestInformation();
            var informatioAboutTea = testingData.InformationTest();

            MakeATeaTask make = new MakeATeaTask();

            string quality = make.QualityTea(informatioAboutTea, 91, 310);
            Assert.AreEqual(quality, "Perfect");
        }

        [TestMethod]
        public void TestMakeATeaWhenMintHave80Temperatureand300secondsresultweak()
        {
            DataTestInformation testingData = new DataTestInformation();
            var informatioAboutTea = testingData.InformationTest();

            MakeATeaTask make = new MakeATeaTask();

            string quality = make.QualityTea(informatioAboutTea, 91, 310);
            Assert.AreEqual(quality, "Weak");
        }

        [TestMethod]
        public void TestMakeATeaWhenMintHave80Temperatureand350secondsresultyucky()
        {
            DataTestInformation testingData = new DataTestInformation();
            var informatioAboutTea = testingData.InformationTest();

            MakeATeaTask make = new MakeATeaTask();

            string quality = make.QualityTea(informatioAboutTea, 91, 310);
            Assert.AreEqual(quality, "Yucky");
        }
    }
}
