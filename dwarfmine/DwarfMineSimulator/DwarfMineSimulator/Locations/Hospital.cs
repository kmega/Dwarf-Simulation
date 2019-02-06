using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Hospital
    {
        public List<Dwarf> TryBirthDwarf(List<Dwarf> DwarfsPopulation)
        {
            Hospital hospital = new Hospital();
            Random rnd = new Random();
            //1 % chance birth
            int chanceToBirthDwarf = rnd.Next(1, 101);
            bool born = false;
            DwarfTypes dwarfTypes;
            dwarfTypes = RandomTypeDwarf();
            if (chanceToBirthDwarf == 1)
            {
                born = true;
                Simulation.TotalBorn++;
            }
            hospital.CreateNewDwarf(DwarfsPopulation, born, dwarfTypes);
            Console.WriteLine("## Born dwarfs ##");
            Console.WriteLine("how many fathers there are: " + Simulation.FatherBorn);
            Console.WriteLine("how many single there are: " + Simulation.SingleBorn);
            Console.WriteLine("how many lazy there are: " + Simulation.LazyBorn);
            Console.WriteLine("how many suicider there are: " + Simulation.SuiciderBorn);
            Console.WriteLine("");
            return DwarfsPopulation;
        }

        public DwarfTypes RandomTypeDwarf()
        {
            Random rnd = new Random();
            int chanceToFatherOrSingle = rnd.Next(1, 101);
            DwarfTypes dwarfTypes;
            if (chanceToFatherOrSingle <= 33)
            {
                dwarfTypes = DwarfTypes.Father;
                Simulation.FatherBorn++;
            }
            else if (chanceToFatherOrSingle > 33 && chanceToFatherOrSingle <= 66)
            {
                dwarfTypes = DwarfTypes.Single;
                Simulation.SingleBorn++;
            }
            else if (chanceToFatherOrSingle > 66 && chanceToFatherOrSingle <= 99)
            {
                dwarfTypes = DwarfTypes.Lazy;
                Simulation.LazyBorn++;
            }
            else
            {
                dwarfTypes = DwarfTypes.Suicider;
                Simulation.SuiciderBorn++;
            }

            return dwarfTypes;
        }

        public void CreateNewDwarf(List<Dwarf> DwarfsPopulation, bool born, DwarfTypes dwarfTypes)
        {
            if (born)
            {
                DwarfsPopulation.Add(new Dwarf
                {
                    Type = dwarfTypes,
                    Alive = true,
                    Money = 0,
                    MoneyEarndedThisDay = 0
                });
            }
        }
    }
}
