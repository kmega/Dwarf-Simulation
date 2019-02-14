using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.DwarfStrategies.WorkingStrategy
{
    public class SuicideStrategy : IWork
    {
        private LifeStatus _isAlive;
        

       public SuicideStrategy()
        {
            _isAlive = LifeStatus.Live;
        }

        public LifeStatus AskAboutLife()
        {
            return _isAlive;
        }

        public void DeathSentence()
        {
            _isAlive = LifeStatus.Dead;
        }
    

        public int Dig()
        {
            // Value -1 destroy shaft
            return -1;
        }

        public void HideToBackpack(MineralType ore)
        {
           
        }

        
    }
}
