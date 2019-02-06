using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using DwarfsCity.Tools;
using System;
using System.Collections.Generic;
using Type = DwarfsCity.DwarfContener.Type;

namespace DwarfsCity
{
    public class Hospital:IReport
    {

        public List<string> Reports { get; set; }

        public Hospital()
        {
            Reports = new List<string>();
        }

        public void GiveBirthToDwarf(List<Dwarf> dwarfs, bool initalState = false)
        {
            bool isBorn;

            if (initalState)
                isBorn = true;
            else
                isBorn = Randomizer.IsDwarfBorn();

            if (isBorn)
            {
                Type attribute = CreateDwarfAttribute();
                Dwarf newBornDwarf = new Dwarf();
                newBornDwarf.Attribute = attribute;
                dwarfs.Add(newBornDwarf);
                GiveReport($"Hospital: new {attribute} dwarf was born"); 
            }

        }

        private Type CreateDwarfAttribute()
        {
            Random probability = new Random();

            int probabilityOfEachAttribute = probability.Next(1, 100);

            if (probabilityOfEachAttribute <= 33)
                return Type.Father;
            else if (probabilityOfEachAttribute > 33 && probabilityOfEachAttribute <= 66)
                return Type.Lazy;
            else if (probabilityOfEachAttribute > 66 && probabilityOfEachAttribute <= 99)
                return Type.Single;
            else
                return Type.Saboteur; 
        }

        public void InitialiseBasicNumberOfDwarfs(List<Dwarf> dwarfs,int numberOfDwarfs)
        {
            for (int i = 0; i < numberOfDwarfs; i++)
            {
                GiveBirthToDwarf(dwarfs, true);
            }
        }

        public void GiveReport(string message)
        {
            Reports.Add(message);
        }
    }
}