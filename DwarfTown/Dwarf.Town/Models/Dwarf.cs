using Dwarf.Town.Enums;
using Dwarf.Town.Interfaces;
using Dwarf.Town.Models;

namespace Dwarf.Town
{
    public class Dwarf
    {
        public bool IsAlive { get; set; }
        public BackPack BackPack { get; set; }
        public Wallet Wallet { get; set; }
        public DwarfType DwarfType { get; set; }
        public IBuy BuyStrategy { get; set; }
        public ISell SellStrategy { get; set; }
        public IWork WorkStrategy { get; set; }
    }
}