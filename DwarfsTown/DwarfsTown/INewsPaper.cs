using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public interface INewsPaper
    {
        List<string> TheJournalist { get; set; }
        void AddInformation(string idBuilding, string message);
    }
}
