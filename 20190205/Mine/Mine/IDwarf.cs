using System;
using System.Collections.Generic;
using System.Text;

namespace Mine
{
    interface IDwarf
    {
        IWork work { get; set; }
        IBackPack backpack { get; set; }
        

    }

    internal interface IWork
    {
    }
}
