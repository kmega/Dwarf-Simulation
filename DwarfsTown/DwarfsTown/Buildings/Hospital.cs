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
            
        }

        //return dwarf

        // birtdwarf => Type metoda (randomizer), 
        //add to dwarflist
        //randomizer.getType() - zwraca typ nie liczbe, getMaterial, GetRange -> 1-3. 
        // przypisuje typ zwrocony z randomizera do draft
        //konstruktor = > 10 sie ma urodzic
        public void BirthDwarf(List <Dwarf> dwarfs, Randomizer rand)
        {
            if (rand.IsDwarfBorn())
                dwarfs.Add(new Dwarf(City.randomizer.GetDwarfType(rand.GetRandomNumber())));           
        }
    }
}