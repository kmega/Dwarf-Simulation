using DwarfsCity.DwarfContener.DwarfEquipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.DwarfContener
{
    public class Dwarf
    {
        //Field
        Backpack Backpack = new Backpack();
        private Type _attribute;

        public void SetAttribute(Type attribute)
        {
            _attribute = attribute;
        }

    }
}
