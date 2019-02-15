using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DwarfSimulation
{
    internal class Hospital
    {
        internal List<Dwarf> BornDwarf(List<Dwarf> dwarves, bool IsBorn, Raport raport)
        {
            if (IsBorn)
            {
                List<Dwarf> BornDwarf = new List<Dwarf>();
                Builder builder = new Builder();
                BornDwarf = builder.CreateDwarves(1);

                Display(BornDwarf);
                UpdateRaport(raport, BornDwarf);

                dwarves = dwarves.Concat(BornDwarf).ToList();
                return dwarves;
            }
            return dwarves;
        }

        internal bool IsBorn()
        {
            Randomizer random = new Randomizer();
            int chance = random.ReturnFromTo(1, 100);
            return (chance == 1);
        }

        internal void Display(List<Dwarf> BornDwarf)
        {
            List<string> output = new List<string>();
            Outputer outputer = new Outputer();
            output.Add("");
            output.Add("### Hospital ###");
            output.Add("Born dwarf " + BornDwarf[0].DwarfType);
            outputer.Display(output);
        }

        internal void UpdateRaport(Raport raport, List<Dwarf> BornDwarf)
        {
            raport.TotalBorn += 1;

            switch (BornDwarf[0].DwarfType)
            {
                case DwarfType.Father:
                    raport.FathersBorn += 1; 
                    break;
                case DwarfType.Single:
                    raport.SingleBorn += 1;
                    break;
                case DwarfType.Lazy:
                    raport.LazyBorn += 1;
                    break;
                case DwarfType.Suicider:
                    raport.SuiciderBorn += 1;
                    break;
                default:
                    break;
            }
        }
    }
}
