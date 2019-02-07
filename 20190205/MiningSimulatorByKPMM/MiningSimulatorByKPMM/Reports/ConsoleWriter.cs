using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Reports
{
    public class ConsoleWriter : IOutputWriter
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
