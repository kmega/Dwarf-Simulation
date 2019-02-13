using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public interface IHospital
    {
        Dwarf GiveBirthToDwarf();
        List<Dwarf> CreateDwarves();
    }
}
