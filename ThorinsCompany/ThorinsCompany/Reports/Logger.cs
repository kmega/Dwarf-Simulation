using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany.Raports
{
    public sealed class Logger
    {
        static private Logger logger = new Logger();
        private List<string> reports = new List<string>();

        private Logger() { }
        static public Logger GetInstance() => logger;
        public void AddLog(string log)
        {
            reports.Add(log);
        }
        public List<string> GetLogs() => reports;

        public void ClearData()
        {
            reports.Clear();
        }

    }
}
