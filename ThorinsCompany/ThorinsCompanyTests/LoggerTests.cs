using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ThorinsCompany.Raports;

namespace ThorinsCompanyTests
{
    public class LoggerTests
    {

        [Test]
        public void ShouldReturnEmptyListWhenDataIsCleared()
        {
            // given
            Logger logger = Logger.GetInstance();
            int expectedListSize = 0;

            // when
            logger.AddLog("Dwarf bought Alcohol");
            logger.AddLog("Dwarf bought Food");
            logger.ClearData();

            // then
            int actualListSize = logger.GetLogs().Count;
            Assert.AreEqual(expectedListSize, actualListSize);
        }

        [Test]
        public void ShouldReturnLogsWhenLogsExist()
        {
            // given
            Logger logger = Logger.GetInstance();
            logger.ClearData();
            List<string> Logs = new List<string>();
            Logs.Add("Dwarf bought Alcohol");
            Logs.Add("Dwarf bought Food");
            Logs.Add("Dwarf bought Alcohol");

            // when
            foreach (string log in Logs)
            {
                logger.AddLog(log);
            }

            // then
            CollectionAssert.AreEqual(Logs, logger.GetLogs());

        }

    }
}
