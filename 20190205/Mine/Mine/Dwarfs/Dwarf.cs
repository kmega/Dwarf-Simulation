using System.Collections.Generic;
using Mine.DwarfWorkStrategy;
using Mine.Locations;

namespace Mine.Dwarfs
{
    public class Dwarf : IDwarf
    {
        public IWork Work { get;  }
        public List<Ore> Backpack { get; private set; }
        public IBankAccount BankAccount { get; }
        public DwarfType Type { get; }

        public Dwarf(DwarfType type)
        {
            Type = type;
            if (Type == DwarfType.Sabotazysta)
            {
                Work = new Suecide();
            }
           
            Work = new Dig();
            BankAccount = new Bank();
            Backpack = new List<Ore>();
        }

        public void AddOresToBackPack(List<Ore> ores)
        {
            Backpack.AddRange(ores);
        }

        public void AddOreToBackPack(Ore ore)
        {
            Backpack.Add(ore);
        }


    }
}
