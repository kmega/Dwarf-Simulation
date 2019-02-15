using System;
using System.Collections.Generic;

namespace DwarfsTown
{
    public class Foreaman
    {
        public delegate void ExplodedShaftEventHandler(object o, ExplodedEventArgs e);
        public event ExplodedShaftEventHandler ExplodedShaft;

        public void SendDwarfsToShaft(List<Dwarf> dwarfsThatShouldBeWorking, Shaft shaft1)
        {

            foreach (var dwarf in dwarfsThatShouldBeWorking)
            {
                if (shaft1.dwarfs.Count == 5) break;
                shaft1.dwarfs.Add(dwarf);
            }



            //Remove from dwarfs who should be working sended dwarfs
            dwarfsThatShouldBeWorking.RemoveAll(x => shaft1.dwarfs.Contains(x));

        }

        public List<Dwarf> LetGoDwarfs(Shaft shaft1)
        {
            List<Dwarf> dwarfsThatGoToSurface = new List<Dwarf>();
            dwarfsThatGoToSurface.AddRange(shaft1.dwarfs);

            shaft1.dwarfs.Clear();
            return dwarfsThatGoToSurface;
        }

        public int SumAllDiggedMaterials(List<Dwarf> dwarfsThatWasWorked)
        {
            int allDiggedMaterials = 0;
            foreach (var dwarf in dwarfsThatWasWorked)
            {
                allDiggedMaterials += dwarf.Backpack.Materials.Count;
            }

            return allDiggedMaterials;
        }

        protected virtual void OnExplodedShaft(List<Dwarf> _killedDwarfs)
        {
            if (ExplodedShaft != null)
                ExplodedShaft(this, new ExplodedEventArgs() {killedDwarfs = _killedDwarfs});
        }

        public void CallToGravedigger(List<Dwarf> _killedDwarfs)
        {
            OnExplodedShaft(_killedDwarfs);
        }
    }
}