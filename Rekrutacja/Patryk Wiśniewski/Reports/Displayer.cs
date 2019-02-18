using System;
using System.Collections.Generic;
using System.Linq;
using ThorinsCompany.Raports;

namespace ThorinsCompany
{
    public class Displayer
    {
        internal void DisplayDailyReport(int numberDay)
        {
            Dictionary<InformationInRaport, int> report = new Dictionary<InformationInRaport, int>();
            foreach (var item in Logger.GetInstance().GetLogs().OrderBy(i => i.Value))
                report.Add(item.Key, item.Value);
            InformationToDisplay(report, DailyORFinalEnum.daily, numberDay);
            Logger.GetInstance().ClearData();
        }

        internal void DisplayFinalReport(int numberDay)
        {
            Dictionary<InformationInRaport, int> report = new Dictionary<InformationInRaport, int>();
            foreach (var item in LoggerFinal.GetInstance().GetLogs().OrderBy(i => i.Value))
                report.Add(item.Key, item.Value);
            InformationToDisplay(report, DailyORFinalEnum.final, numberDay);
        }

        private void InformationToDisplay(Dictionary<InformationInRaport, int> listLogs, DailyORFinalEnum dailyORFinal, int numberDay)
        {
            string displayReport = "";
            int resultDivideFromNumber3 = listLogs.Count() / 3;
            int counter = 0;
            if (dailyORFinal == DailyORFinalEnum.daily)
            {
                displayReport += "Daily Report Day :" + numberDay + "\n" + "\n";
            }
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