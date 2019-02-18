using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class ExplodedEventArgs: EventArgs
    {
        public List<Dwarf> killedDwarfs = new List<Dwarf>();
    }
}
