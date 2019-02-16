using System;
using System.Collections.Generic;
using System.Linq;
using ThorinsCompany.Raports;

namespace ThorinsCompany
{
    public class Displayer
    {
        internal void DisplayDailyReport()
        {
            Dictionary<InformationInRaport, int> report = new Dictionary<InformationInRaport, int>();
            foreach (var item in LoggerFinal.GetInstance().GetLogs().OrderBy(i => i.Value))
                report.Add(item.Key, item.Value);
            InformationToDisplay(report);
        }

        internal void DisplayFinalReport()
        {
            Dictionary<InformationInRaport, int> report = new Dictionary<InformationInRaport, int>();
            foreach (var item in Logger.GetInstance().GetLogs().OrderBy(i => i.Value))
                report.Add(item.Key, item.Value);
            InformationToDisplay(report);
        }

        private void InformationToDisplay(Dictionary<InformationInRaport, int> listLogs)
        {
            string displayReport = "";
            int resultDivideFromNumber3 = listLogs.Count() / 3;
            int counter = 0;
            foreach (var item in listLogs)
            {
                if (counter == 0)
                    displayReport += "Hihg priority information" + "\n";
                else if (counter == resultDivideFromNumber3)
                    displayReport += "\n" + "Normal priority information" + "\n";
                else if (counter == (resultDivideFromNumber3 * 2))
                    displayReport += "\n" + "Base priority information" + "\n";
                displayReport += (item.Key.ToString() + ": " + item.Value.ToString() + "\n");
                counter++;
            }
            Console.WriteLine(displayReport);
        }
    }
}