using System;
using System.Collections.Generic;

namespace DwarfsTown
{
    public class Hospital 
    {
        public Hospital(List<Dwarf> dwarfs)
        {
            Birth10DwarfToStart(dwarfs);
           
        }
        public void Birth10DwarfToStart(List<Dwarf> dwarfs)
        {
            for (int i = 0; i < 10; i++)
            {
                dwarfs.Add(new Dwarf(City.randomizer.GetDwarfType(City.randomizer.GetRandomNumber())));
            }
            AddInformation("Hospital", "Today 10 Dwarfs are born.");

        }

        public void BirthDwarf(List <Dwarf> dwarfs, Randomizer rand)
        {
            if (rand.IsDwarfBorn())
            {
                dwarfs.Add(new Dwarf(City.randomizer.GetDwarfType(rand.GetRandomNumber())));
                AddInformation("Hospital", "Today 1 Dwarfes are born.");
            }
        }
        public void AddInformation(string idBuilding, string message)
        {
            City.newsPaper.Add(idBuilding + ": " + message);
        }
    }
}