using System;
using System.Collections.Generic;
using System.Text;
using ThorinsCompany.Raports;
using System.Linq;

namespace ThorinsCompany
{
    public class ViewDailyOrFinalReport
    {
        string displayReport = "";
        public void ViewFinalReport()
        {
            var listLogs = LoggerFinal.GetInstance().GetLogs();

            InformationToDisplay(listLogs);
        }

        public void ViewDailyReport()
        {
            Dictionary<InformationInRaport, int> report = new Dictionary<InformationInRaport, int>();
            foreach (var item in LoggerDaily.GetInstance().GetLogs().OrderBy(i => i.Value))
                report.Add(item.Key, item.Value);
            InformationToDisplay(report);

            LoggerDaily.GetInstance().ClearData();
        }

        private void InformationToDisplay(Dictionary<InformationInRaport, int> listLogs)
        {
            int resultDivideFromNumber3 = listLogs.Count() / 3;
            int counter = 0;
            foreach (var item in listLogs)
            {
                if (counter == 0)
                    displayReport += "Hihg priority information" + "\n";
                else if (counter == resultDivideFromNumber3)
                    displayReport += "\n" + "Normal priority information" + "\n";
                else if (counter == (resultDivideFromNumber3*2))
                    displayReport += "\n" + "Base priority information" + "\n";
                displayReport += (item.Key.ToString() + ": " + item.Value.ToString() + "\n");
                counter++;
            }
            Console.WriteLine(displayReport);
        }
    }
}
