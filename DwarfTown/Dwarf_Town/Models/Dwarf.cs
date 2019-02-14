using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Interfaces.SellingStrategy;
using Dwarf_Town.Models;

namespace Dwarf_Town
{
    public class Dwarf { 

        //public LifeStatus IsAlive { get; set; }
        public Backpack Backpack { get; set; }
        public Wallet Wallet { get; set; }
        public IBuy BuyStrategy { get; set; }
        public ISell SellStrategy { get; set; }
        public IWork WorkStrategy { get; set; }


        public Dwarf()
        {
            //IsAlive = LifeStatus.Live;
            Backpack = new Backpack();
            Wallet = new Wallet();

        }

    }
}
