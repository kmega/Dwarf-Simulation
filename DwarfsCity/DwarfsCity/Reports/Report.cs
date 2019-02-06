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
            for (int i = 0; i < classesReports.Count; i++)
            {
                for (int j = 0; j < classesReports[i].Reports.Count; j++)
                {
                    _reportsToDisplay.Add(classesReports[i].Reports[j]);
                }
            }
        }

        public List<string> GetReportsToDisplay()
        {
            return _reportsToDisplay;  
        }

    }
}
