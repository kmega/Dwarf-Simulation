namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            Burger cheeseburger = new Burger(AddonType.None, Cheeseness.Single, 8);
            cheeseburger.Name = "Cheeseburger";
            return cheeseburger;
        }
    }
}