namespace Example.Autofac
{
    public class TheShepardHouse
    {
        private readonly IShepardable _shepard;
        private readonly IEatTable _theSheep2;
        private readonly IEatTable _theSheep1;

        public TheShepardHouse(
            IShepardable shepard, 
            IEatTable theSheep1,
            IEatTable theSheep2)
        {
            _shepard = shepard;
            _theSheep2 = theSheep2;
            _theSheep1 = theSheep1;
        }

        public void MakeSheepScreem()
        {
            _shepard.GuardTheShip(_theSheep1);
            _shepard.GuardTheShip(_theSheep2);
        }
    }
}