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
            //Randomize chance how many times dwarf will be digging
            Randomizer rand = new Randomizer();
            for (int i = 0; i < rand.GetChance(); i++)
            {
                Backpack.Materials.Add(Materials.rand.GetMaterial());
            }
        }
    }
}
