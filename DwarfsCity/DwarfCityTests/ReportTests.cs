using System;
using System.Collections.Generic;
using System.Text;
using DwarfsCity;
using DwarfsCity.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DwarfCityTests
{
    [TestClass]
    public class ReportTests
    {
        [TestMethod]
        public void New100DwarfsAreBorn()
        {
            //given
            City city = new City();
            Hospital hospital = new Hospital();
            Report report = new Report();
            int numberInListOfDwarfs_Single = 0;
            int numberInListOfDwarfs_Father = 0;
            int numberInListOfDwarfs_Lazy = 0;
            
            List<IReport> listOfReports = new List<IReport>() { hospital };

            //when
            hospital.InitialiseBasicNumberOfDwarfs(city.GetDwarfs(), 100);

            //then
            report.AnaliseReports(listOfReports);

            for (int i = 0; i < 100; i++)
            {
                switch(report.GetReportsToDisplay()[i])
                {
                    case "Hospital: new Single dwarf was born":
                    numberInListOfDwarfs_Single = i;
                        break;

                    case "Hospital: new Father dwarf was born":
                        numberInListOfDwarfs_Father = i;
                        break;

                    case "Hospital: new Lazy dwarf was born":
                        numberInListOfDwarfs_Lazy = i;
                        break;
                }
                    
            }

            Assert.AreEqual(100, report.GetReportsToDisplay().Count);
            Assert.AreEqual("Hospital: new Single dwarf was born", report.GetReportsToDisplay()[numberInListOfDwarfs_Single]);
            Assert.AreEqual("Hospital: new Father dwarf was born", report.GetReportsToDisplay()[numberInListOfDwarfs_Father]);
            Assert.AreEqual("Hospital: new Lazy dwarf was born", report.GetReportsToDisplay()[numberInListOfDwarfs_Lazy]);

        }

        

        
}
}
