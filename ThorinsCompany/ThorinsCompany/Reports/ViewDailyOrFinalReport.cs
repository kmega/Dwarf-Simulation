using System;
using System.Collections.Generic;
using System.Text;
using ThorinsCompany.Raports;

namespace ThorinsCompany
{
    class ViewDailyOrFinalReport
    {
        string displayReport = "";
        public void ViewFinalReport()
        {
            var listLogs = LoggerFinal.GetInstance().GetLogs();

            InformationToDisplay(listLogs);
        }

        public void ViewDailyReport()
        {
            var listLogs = LoggerDaily.GetInstance().GetLogs();
            InformationToDisplay(listLogs);

            LoggerDaily.GetInstance().ClearData();
        }

        private void InformationToDisplay(Dictionary<InformationInRaport, int> listLogs)
        {
            foreach (var item in listLogs)
                displayReport += (item.Key.ToString() + ": " + item.Value.ToString() + "\n");
            Console.WriteLine(displayReport);
        }
    }
}
