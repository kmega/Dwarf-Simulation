using System;
using System.IO;
using System.Threading.Tasks;
using CyberMagicWithTests.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1;
using VivaRegex;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FryderykKomciur()
        {
            Task1 task1 = new Task1();
            string result = task1.GetKomciur();

            Assert.AreEqual("Fryderyk Komciur był budowany 23 minuty", result);
        }

        [TestMethod]
        public void IsCharactersReaded()
        {
            Task2 task2 = new Task2();
            int result = task2.CharactersList.Count;

            Assert.IsTrue(result > 1);
        }


    }
}
