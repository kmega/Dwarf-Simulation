﻿using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Models;
using Dwarf_Town.Strategy;

namespace Dwarf_Town
{
    public class Dwarf
    {
        public IWork _work = null;
        public ISell _sell = null;
        public IBuy _buy = null;

        public Dwarf(DwarfType dwarfType)
        {
            if (dwarfType == DwarfType.FATHER)
            {
                _work = new DiggWork(this);
                _sell = new NormalSell(this);
                _buy = new FoodBuy();
            }
            else if (dwarfType == DwarfType.IDLER)
            {
                _work = new DiggWork(this);
                _sell = new NormalSell(this);
                _buy = new NormalBuy();
            }
            else if (dwarfType == DwarfType.SINGLE)
            {
                _work = new DiggWork(this);
                _sell = new NormalSell(this);
                _buy = new AlcoholBuy();
            }
            else if (dwarfType == DwarfType.SUICIDE)
            {
                _work = new ExplodeWork(this);
                _sell = new DefaultSell();
                _buy = new DefaultBuy();
            }

            IsAlive = true;
            BackPack = new BackPack();
            Wallet = new Wallet();
            DwarfType = dwarfType;
        }

        public bool IsAlive { get; set; }
        public BackPack BackPack { get; set; }
        public Wallet Wallet { get; set; }
        public DwarfType DwarfType { get; set; }
    }
}