using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaPrograms
{
    public class DataTestInformation
    {


        public  List<ListTeaClass> InformationTest()
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

            informatioAboutTea.Add(new ListTeaClass
            {
                teaName = "Mięta",
                typeTea = "napar",
                boilingpoint = "96",
                boilingTime = "5"
            });
            return informatioAboutTea;
        }
    }
}
