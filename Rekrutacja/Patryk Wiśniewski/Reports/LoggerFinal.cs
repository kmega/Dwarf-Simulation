using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany.Raports
{
    public sealed class LoggerFinal
    {
        static private LoggerFinal logger = new LoggerFinal();
        private Dictionary<InformationInRaport, int> reports = 
            new Dictionary<InformationInRaport, int>();

        private LoggerFinal()  {    }
        static public LoggerFinal GetInstance() => logger;
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
    }
}
