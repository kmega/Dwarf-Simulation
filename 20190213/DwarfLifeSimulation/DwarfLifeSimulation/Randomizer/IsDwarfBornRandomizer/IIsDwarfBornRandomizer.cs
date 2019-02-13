namespace DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer
{
    public interface IIsDwarfBornRandomizer : IRandomizer
    {
        bool IsDwarfBorn(int maxValue = 100);
    }
}