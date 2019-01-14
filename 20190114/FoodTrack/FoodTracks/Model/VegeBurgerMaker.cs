namespace FoodTracks.Model
{
    public class VegeBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger burger = new Burger(Meet.CreateMeet(),Cheeseness.Single);
            burger.Price = 5;
            return burger;
        }
    }
}