using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.Reports
{
    public interface IReport
    {
        List<string> Reports { get; }
        void GiveReport(string message);
    }
}
