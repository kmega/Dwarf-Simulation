namespace DwarfSimulation
{
    internal class SuiciderWorkStrategy : IWork
    {
        public Shaft Work(Shaft shaft, Raport raport)
        {
            Dwarf dwarf;

            for (int index = 0; index < shaft.MaxInside; index++)
            {
                dwarf = shaft.Miners[index];
                dwarf.IsAlive = false;
            }

            shaft.Collapsed = true;

            return shaft;
        }
    }
}
