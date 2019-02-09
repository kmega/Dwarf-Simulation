using System;
using System.Collections.Generic;
using DwarfLife.Diaries;
using DwarfLife.Dwarfs;

namespace DwarfLife.Buildings.Mine
{
    public class Shaft
    {
        readonly string _name;
        bool _collapsed;
        public string Name { get { return _name; } }
        public bool IsCollapsed 
        { 
            get { return _collapsed; } 
            private set { _collapsed = value; } 
        }
        public List<IDwarf> Dwarfs { get; private set; }

        public Shaft(string name)
        {
            _name = name;
            _collapsed = false;
            Dwarfs = new List<IDwarf>();
        }

        public void SendDwarfsToShaft(List<IDwarf> dwarfs)
        {
            Dwarfs = dwarfs;
        }
    }
}
