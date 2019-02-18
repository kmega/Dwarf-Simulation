namespace Example.Autofac
{
    public class Shepard: IShepardable
    {
        public void GuardTheShip(IEatTable theSheep)
        {
            theSheep.Eat();
        }
    }
}