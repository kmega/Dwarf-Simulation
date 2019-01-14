namespace FoodTracks.Model
{
    public class Cook
    {
        public Burger Create(IBurgerMaker burgerMaker)
        {
            if(burgerMaker == null)
            {
                return new Burger(Meet.CreateMeet(), AddonType.None);
            }

            return burgerMaker.Make();
        }

    }
}