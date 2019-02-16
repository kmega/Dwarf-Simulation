using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public sealed class LoggerDaily
    {
        static private LoggerDaily logger = new LoggerDaily();
        private Dictionary<InformationInRaport, int> reports =
            new Dictionary<InformationInRaport, int>();
        
        private LoggerDaily() { }
        static public LoggerDaily GetInstance() => logger;
        public void AddLog(int information, InformationInRaport typeInformationInRaport)
        {
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
