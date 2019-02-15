using System;
using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Foreman
    {
        private int _avaibleShafts = 0;
        public void ManageWorkingDwarves(List<Dwarf> dwarves, List<Shaft> allShafts)
        {
            for (int i = 0; i < dwarves.Count; i+=5)
            {
                try
                {

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void GetNumberOfAvaibleShafts(List<Shaft> allShafts)
        {
            foreach (var shaft in allShafts)
            {
                _avaibleShafts = (shaft.IsAvaible) ? _avaibleShafts + 1 : _avaibleShafts;
            }
        }
    }
}