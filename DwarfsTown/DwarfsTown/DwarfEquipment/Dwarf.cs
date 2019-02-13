using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class Dwarf
    {
        public TypeEnum Type { get; private set; } 
        public IBankAccount BankAccount;
        public IBackpack Backpack;
        public bool IsAlive { get; set; }

        public Dwarf(TypeEnum type)
        {
            Type = new TypeEnum();
            IsAlive = true;
        }

        public void Digging()
        {

        }
    }
}
