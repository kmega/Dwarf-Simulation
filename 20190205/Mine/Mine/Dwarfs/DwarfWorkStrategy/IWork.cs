using System;
using System.Collections.Generic;
using System.Text;
using Mine.Locations;

namespace Mine
{
    public interface IWork
    {
        List<Ore> DoWork();
    }
}
