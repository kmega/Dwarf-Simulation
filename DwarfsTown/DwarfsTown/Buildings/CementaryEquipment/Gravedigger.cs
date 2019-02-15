using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public static class Gravedigger
    {
        public static void OnExplodedShaft(object o, ExplodedEventArgs e)
        {
            FuneralDwarfs(e.killedDwarfs);
        }

        private static void FuneralDwarfs(List<Dwarf> killedDwarfs)
        {
            City.newsPaper.Add("Cementary - " + killedDwarfs.Count + " dwarfs died");

            foreach (var dwarf in killedDwarfs)
            {
                Cementary.Graves.Add(dwarf);
            }

            killedDwarfs.Clear();
        }
    }
}
