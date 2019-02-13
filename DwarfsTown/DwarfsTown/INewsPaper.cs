using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public interface INewsPaper
    {
        void AddInformation(string idBuilding, string message);
    }
}
