namespace FoodTracks.Model
{
    public class Cook 
    {
        public Burger Create(IBurgerMaker burgerMaker)
        {

            if (burgerMaker != null)
            {

                return burgerMaker.Make();
            }
            else
            {
                return new Burger();
            }
        }

       
    }
}