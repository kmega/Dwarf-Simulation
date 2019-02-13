using System;

namespace DwarfsTown
{
    public class Hospital
    {
        Randomizer randomizer = new Randomizer();
        public Hospital()
        {


        }     
        //return dwarf
     
        // birtdwarf => Type metoda (randomizer), 
        //add to dwarflist
        //randomizer.getType() - zwraca typ nie liczbe, getMaterial, GetRange -> 1-3. 
        // przypisuje typ zwrocony z randomizera do draft
   //konstruktor = > 10 sie ma urodzic
        public Dwarf BirthDwarf()
        {
            return new Dwarf(randomizer.GetDwarfType());           
        }
    }
}