namespace FoodTracks.Model
{
    public class Cook
    {
        public Burger Create(IBurgerMaker burgerMaker)
        {
            if (burgerMaker == null)
            {
                Burger burger = new Burger();
                return burger;
            }
            return burgerMaker.Make();
        }
    }
}