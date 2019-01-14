namespace FoodTracks.Model
{
    public interface IDiscountCalculator
    {
        decimal Calculate();
        int ChanceForWin();
    }
}