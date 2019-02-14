using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Models;
using Dwarf_Town.Strategy;

namespace Dwarf_Town
{
    public class Dwarf
    {
        private readonly IWork _work = null;
        private readonly ISell _sell = null;
        private readonly IBuy _buy = null;

        public Dwarf(DwarfType dwarfType)
        {
            if (dwarfType == DwarfType.FATHER)
            {
                _work = new DiggWork();
                _sell = new NormalSell();
                _buy = new FoodBuy();
            }
            else if (dwarfType == DwarfType.IDLER)
            {
                _work = new DiggWork();
                _sell = new NormalSell();
                _buy = new NormalBuy();
            }
            else if (dwarfType == DwarfType.SINGLE)
            {
                _work = new DiggWork();
                _sell = new NormalSell();
                _buy = new AlcoholBuy();
            }
            else if (dwarfType == DwarfType.SUICIDE)
            {
                _work = new ExplodeWork();
                _sell = new DefaultSell();
                _buy = new DefaultBuy();
            }

            IsAlive = true;
            BackPack = new BackPack();
            Wallet = new Wallet();
        }

        public bool IsAlive { get; set; }
        public BackPack BackPack { get; set; }
        public Wallet Wallet { get; set; }
        public DwarfType DwarfType { get; set; }
    }
}