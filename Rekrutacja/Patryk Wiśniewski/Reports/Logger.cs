using System;
using System.Collections.Generic;
using System.Text;
using ThorinsCompany.Raports;

namespace ThorinsCompany
{
    public sealed class Logger
    {
        static private Logger logger = new Logger();
        private Dictionary<InformationInRaport, int> reports =
            new Dictionary<InformationInRaport, int>();
        
        private Logger() { }
        static public Logger GetInstance() => logger;
        public void AddLogToFinalAndDailyReport(int information, InformationInRaport typeInformationInRaport)
        {
            LoggerFinal.GetInstance().AddLog(information, typeInformationInRaport);
            if (reports.Count == 0)
            {
                foreach (string name in Enum.GetNames(typeof(InformationInRaport)))
                {
                    InformationInRaport result;
                    Enum.TryParse(name, true, out result);
                    reports.Add(result, 0);
                }
            }
            reports[typeInformationInRaport] += information;

        }
        public Dictionary<InformationInRaport, int> GetLogs() => reports;

        public void ClearData()
        {
            reports.Clear();
        }
    }
}
