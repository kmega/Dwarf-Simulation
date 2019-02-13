using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Interfaces.BuyingStategy;
using Dwarf_Town.Interfaces.SellingStrategy;
using Dwarf_Town.Interfaces.WorkingStategy;
using Dwarf_Town.Models;

namespace Dwarf_Town
{
    public class Dwarf : IBuy, ISell, IWork
    {
        public bool IsAlive { get; set; }
        public Backpack BackPack { get; set; }
        public Wallet Wallet { get; set; }
        public DwarfType DwarfType { get; set; }
        public IBuyingStrategy BuyStrategy { get; set; }
        public ISellingStrategy SellStrategy { get; set; }
        public IWorkingStrategy WorkStrategy { get; set; }

        public void Buy()
        {
            throw new System.NotImplementedException();
        }

        public void Sell()
        {
           
        }

        public void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}