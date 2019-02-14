using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class Dwarf
    {
        //typ,plecak,portfel,
        public TypeEnum Type { get; private set; } 
        public IBankAccount BankAccount;
        public IBackpack Backpack;
        public bool IsAlive { get; set; }

        public Dwarf(TypeEnum type)
        {
            Type = new TypeEnum();
            IsAlive = true;
            Type = type;
        }

        //TODO: 
        //In feature will be method to changing IsAlive to false
    }
}
