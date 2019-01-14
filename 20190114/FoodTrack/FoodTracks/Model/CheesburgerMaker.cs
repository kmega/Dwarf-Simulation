namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger burger = new Burger(Meet.CreateMeet(5),Cheeseness.Single);
            burger.Price = 10;
            return burger;
        }
    }
}