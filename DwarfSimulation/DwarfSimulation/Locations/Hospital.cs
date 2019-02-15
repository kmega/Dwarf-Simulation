using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DwarfSimulation
{
    internal class Hospital
    {
        bool _IsBorn;

        public Hospital(IBornRandomizer randomizer)
        {
            _IsBorn = randomizer.IsBorn();
        }

        internal List<Dwarf> BornDwarf(List<Dwarf> dwarves, Raport raport)
        {
            List<Dwarf> BornDwarf = new List<Dwarf>();
            if (_IsBorn)
            {
                Builder builder = new Builder();
                BornDwarf = builder.CreateDwarves(1);

                Display(BornDwarf);
                UpdateRaport(raport, BornDwarf);

                dwarves = dwarves.Concat(BornDwarf).ToList();
                return dwarves;
            }
            Display(BornDwarf);
            return dwarves;
        }

        internal void Display(List<Dwarf> BornDwarf)
        {
            List<string> output = new List<string>();
            Outputer outputer = new Outputer();
            output.Add("");
            output.Add("\n### Hospital ###");
            if (BornDwarf.Count == 0)
            {
                output.Add("Nobody born");
            }
            else
            {
                output.Add("Born dwarf " + BornDwarf[0].DwarfType);
            }
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
