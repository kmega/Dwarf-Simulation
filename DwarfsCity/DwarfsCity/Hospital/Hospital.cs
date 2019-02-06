﻿using DwarfsCity.DwarfContener;
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
                Type attribute = Randomizer.TypeOfBornDwarf();
                Dwarf newBornDwarf = new Dwarf();
                newBornDwarf.Attribute = attribute;
                dwarfs.Add(newBornDwarf);
                GiveReport($"Hospital: new {attribute} dwarf was born"); 
            }

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