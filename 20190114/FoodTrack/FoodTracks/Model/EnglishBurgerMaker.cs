namespace FoodTracks.Model
{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
            return new Burger(Cheeseness.Single, 10, new System.Collections.Generic.List<AddonType>
            {
                AddonType.Halapenio,
                AddonType.Egg
            });
        }
    }
}