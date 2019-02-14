using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class Randomizer
    {

        //public int RandomNumber { get; set; } 
        //public Randomizer()
        //{
        //    GetRandomNumber();
        //}
        public bool IsDwarfBorn()
        {
            int RandomNumber = GetRandomNumber();
            if (RandomNumber == 1)
                return true;
            else
                return false;

        }
        public TypeEnum GetDwarfType(int RandomNumber)
        {
            if (RandomNumber< 33)
                return TypeEnum.Father;
            else if (RandomNumber < 66)
                return TypeEnum.Lazy;
            else if (RandomNumber < 99)
                return TypeEnum.Single;
            else
                return TypeEnum.Saboteur;
        }

        public Materials GetMaterial()
        {
            int RandomNumber = GetRandomNumber();
            if (RandomNumber < 5)
                return Materials.Mithril;
            else if (RandomNumber < 20)
                return Materials.Gold;
            else if (RandomNumber < 55)
                return Materials.Silver;
            else
                return Materials.DirtyGold;       
        }

        public virtual int GetRandomNumber()
        {
            Random random = new Random();
            return random.Next(0, 99);
        }

        public int GetRange()
        {
            Random random = new Random();
            return random.Next(1, 3);
        }


    }
}
