using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroplaneSymulation
{
    public class WiezaKontrolna
    {

        public bool check(List<bool> pasy)
        {
            bool flag = false;
            foreach (var pas in pasy)
            {
                if (pas)
                {
                    flag = true;
                }
            }

            return flag;
        }

        public List<bool> change_to_full(List<bool> pasy)
        {
            bool flag = true;
            List<bool> pasy_update = new List<bool>();

            foreach (var pas in pasy)
            {
                if (flag)
                {
                    if (pas)
                    {
                        flag = false;
                        pasy_update.Add(false);
                    }

                }
                else { pasy_update.Add(pas); }

            }
            return pasy_update;
        }
    }
}
