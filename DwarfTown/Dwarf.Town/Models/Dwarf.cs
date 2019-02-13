using Dwarf.Town.Enums;
using Dwarf.Town.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf.Town
{
    public class Dwarf
    {
        public bool IsAlive { get; set; }
        public BackPack BackPack { get; set; }
        public Wallet Wallet { get; set; }
        public DwarfType DwarfType { get; set; }
    }
}
