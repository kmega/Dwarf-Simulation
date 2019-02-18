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
        IBehaviorOnTheShaft shaftStrategy;

        public Dwarf(TypeEnum type)
        {
            Type = new TypeEnum();
            Backpack = new Backpack();
            BankAccount = new BankAccount();
            Type = type;
            if (type == TypeEnum.Saboteur) shaftStrategy = new SaboteurStrategy();
            else shaftStrategy = new CommonDwarfStrategy();
        }

        public void Working(Shaft shaft)
        {
            shaftStrategy.DoYourJob(shaft, this.Backpack);
        }
    }
}
