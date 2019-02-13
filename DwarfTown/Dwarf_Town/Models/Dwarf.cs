using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Models;

namespace Dwarf_Town
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