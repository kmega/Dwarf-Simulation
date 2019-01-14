namespace FoodTracks.Model
{
    public interface IDiscountCalculator
    {
        decimal Calculate();
        decimal RandomBonus();
    }
}