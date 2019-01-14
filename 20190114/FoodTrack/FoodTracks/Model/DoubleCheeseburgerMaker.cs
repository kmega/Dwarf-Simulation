namespace FoodTracks.Model
{
    public class DoubleCheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger burger = new Burger(Meet.CreateMeet(5),Cheeseness.Double);
            burger.Price = 20;
            return burger;
        }
    }
}