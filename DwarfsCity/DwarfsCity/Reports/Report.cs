using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.Reports
{
    public class Report
    {
        List<string> _reportsToDisplay = new List<string>();

        public void AnaliseReports(List<IReport> classesReports)
        {
            foreach (var reports in classesReports)
            {
               _reportsToDisplay.Add(reports.Report);
            }
        }

        public List<string> GetReportsToDisplay()
        {
            return _reportsToDisplay;
        }

    }
}
