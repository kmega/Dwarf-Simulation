namespace FoodTracks.Model
{
    public class Cook
    {
        public Burger Create(IBurgerMaker burgerMaker)
        {
            var burger = new Burger();

            if(burgerMaker == null)
            {
                return burger;
            }

            return burgerMaker.Make();
        }
    }
}