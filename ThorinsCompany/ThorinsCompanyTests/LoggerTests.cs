using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ThorinsCompany;
using ThorinsCompany.Raports;

namespace ThorinsCompanyTests
{
    public class LoggerTests
    {
        int counter = 0;
        [TestCase(InformationInRaport.AlcoholBought, 10)]
        [TestCase(InformationInRaport.DeathCount, 5)]
        [TestCase(InformationInRaport.GoldMinded, 100)]
        [TestCase(InformationInRaport.ShopEarned, 200)]
        [TestCase(InformationInRaport.SuiciderBorn, 10)]
        [TestCase(InformationInRaport.TaintedGoldMinded, 10)]
        public void T01ReturnInfomationInLogs(InformationInRaport information, int howMany)
        {
            LoggerDaily.GetInstance().AddLog(howMany, information);
            var listLogs = LoggerDaily.GetInstance().GetLogs();
            Assert.AreEqual(listLogs[information], howMany);
            LoggerDaily.GetInstance().ClearData();
            counter++;

        }
        [TestCase(InformationInRaport.AlcoholBought, 10)]
        [TestCase(InformationInRaport.AlcoholBought, 10)]
        public void T02AddTwoTimesTheSameInformation(InformationInRaport information, int howMany)
        {
            bool moreInformation = false;
            LoggerDaily.GetInstance().AddLog(howMany, information);
            var listLogs = LoggerDaily.GetInstance().GetLogs();
            if (listLogs[InformationInRaport.AlcoholBought] == howMany)
                moreInformation = true;
            else if (listLogs[InformationInRaport.AlcoholBought] == howMany * 2)
                moreInformation = true;
            Assert.IsTrue(moreInformation);
            ViewDailyOrFinalReport view = new ViewDailyOrFinalReport();
            view.ViewDailyReport();
        }


    }
}
