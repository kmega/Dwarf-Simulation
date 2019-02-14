using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public interface IHospital
    {
        List<Dwarf> GiveBirthToDwarf(List<Dwarf> dwarves);
        List<Dwarf> CreateDwarves(int howManyDwarfYouWantCreate);
    }
}
