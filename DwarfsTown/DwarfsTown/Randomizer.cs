using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class Randomizer
    {

        public int RandomNumberForType { get; set; } = 0;
        public Randomizer()
        {

            GetType();

        }

        public void GetRandomNumberForType()
        {
            Random random = new Random();
            int RandomNumberForType = random.Next(0, 99);
            this.RandomNumberForType = RandomNumberForType;
        }


        public TypeEnum GetDwarfType()
        {           
           
            if (RandomNumberForType < 33)
                return TypeEnum.Father;
            else if (RandomNumberForType < 66)
                return TypeEnum.Lazy;
            else if (RandomNumberForType < 99)
                return TypeEnum.Single;
            else
                return TypeEnum.Saboteur;
        }

        public Materials GetMaterials()
        {
            return Materials.Gold;
        }
        public int GetRange()
        {
            return 1;
        }

    }
}
