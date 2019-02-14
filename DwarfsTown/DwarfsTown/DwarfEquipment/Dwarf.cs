using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class Dwarf
    {
        public TypeEnum Type { get; private set; } 
        public BankAccount BankAccount;
        public Backpack Backpack;
        public bool IsAlive { get; set; }

        public Dwarf(TypeEnum type)
        {
            Type = new TypeEnum();
            Backpack = new Backpack();
            BankAccount = new BankAccount();
            IsAlive = true;
            Type = type;
        }

        public void Digging()
        {
            for (int i = 0; i < City.randomizer.GetRange(); i++)
            {
                Backpack.Materials.Add(City.randomizer.GetMaterial());
            }
        }
    }
}
