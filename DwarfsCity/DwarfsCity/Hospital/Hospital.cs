using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using System;
using System.Collections.Generic;
using Type = DwarfsCity.DwarfContener.Type;

namespace DwarfsCity
{
    public class Hospital:IReport
    {
        Random _probabilityOfBirth = new Random();

        public List<string> Reports { get; }

        public void GiveBirthToDwarf(List<Dwarf> dwarfs, bool initalState = false)
        {
            int probability = 0;

            if (initalState)
                probability = 5;
            else
             probability = _probabilityOfBirth.Next(1, 100);

            if (probability == 5)
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