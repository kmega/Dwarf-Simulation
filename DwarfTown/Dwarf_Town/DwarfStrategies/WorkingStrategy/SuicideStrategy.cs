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
        private Dwarf _dwarf;


        public SuicideStrategy(Dwarf dwarf)
        {
            _dwarf = dwarf;
        }

        public bool AskAboutLife()
        {
            return _dwarf.IsAlive;
        }

        public void DeathSentence()
        {
          _dwarf.IsAlive = false;
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
