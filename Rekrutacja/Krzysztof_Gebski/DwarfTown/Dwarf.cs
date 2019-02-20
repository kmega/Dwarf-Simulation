using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Models;
using Dwarf_Town.Strategy;

namespace Dwarf_Town
{
    public class Dwarf
    {
        public IWork Work { get; set; }
        public ISell Sell { get; set; }
        public IBuy Buy { get; set; }

        public Dwarf(DwarfType dwarfType)
        {
            if (dwarfType == DwarfType.FATHER)
            {
                Work = new DiggWork(this);
                Sell = new NormalSell(this);
                Buy = new FoodBuy();
            }
            else if (dwarfType == DwarfType.IDLER)
            {
                Work = new DiggWork(this);
                Sell = new NormalSell(this);
                Buy = new NormalBuy();
            }
            else if (dwarfType == DwarfType.SINGLE)
            {
                Work = new DiggWork(this);
                Sell = new NormalSell(this);
                Buy = new AlcoholBuy();
            }
            else if (dwarfType == DwarfType.SUICIDE)
            {
                Work = new ExplodeWork(this);
                Sell = new DefaultSell();
                Buy = new DefaultBuy();
            }

            IsAlive = true;
            BackPack = new Backpack();
            Wallet = new Wallet();
            DwarfType = dwarfType;
        }

        public bool IsAlive { get; set; }
        public Backpack BackPack { get; set; }
        public Wallet Wallet { get; set; }
        public DwarfType DwarfType { get; set; }
    }
}