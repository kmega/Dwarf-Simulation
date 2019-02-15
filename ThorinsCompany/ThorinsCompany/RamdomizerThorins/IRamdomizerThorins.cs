using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public interface IRamdomizerThorins
    {
        int ReturnPriceMaterials(Material material);
        bool WillHeBeBorn(int chanceToFatherOrSingle);
        DwarfType GenerateDwarfType(int chanceToFatherOrSingle);
    }
}
