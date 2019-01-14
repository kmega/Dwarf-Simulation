namespace FoodTracks.Model
{
    public class Cook
    {
        public Burger Create(IBurgerMaker burgerMaker)
        {
            if (burgerMaker == null)
            {
                return new Burger();
            }

            return burgerMaker.Make();
        }
    }
}