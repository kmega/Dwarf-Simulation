namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            int cookingtime = 10;
            int a = 0;
                int b = 0;
                int c = 0; 
               
            return new Burger(cookingtime,a,b,c);
        }
    }
}