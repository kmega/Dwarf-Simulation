using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.DwarfStrategies.WorkingStrategy
{
    public class DigStrategy : IWork
    {
        private LifeStatus _isAlive;
        private Backpack _backpack;


        public DigStrategy(Backpack backpack)
        {
            _isAlive = LifeStatus.Live;
            _backpack = backpack;
        }

        public void DeathSentence()
        {
            _isAlive = LifeStatus.Dead;
        }

        public int Dig()
        {
           Random rand = new Random();
           int numberOfHits = rand.Next(1, 3);
           return numberOfHits;
        }

        public void HideToBackpack(MineralType ore)
        {
            _backpack.AddOre(ore);
        }

        public LifeStatus AskAboutLife()
        {
            return _isAlive;
        }
    }
}
