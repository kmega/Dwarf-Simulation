using System;

namespace FoodTracks.Model
{
    public class CashRegister
    {
        private readonly IDiscountCalculator _discountCalculator;
		private readonly IDiscountRandom _discountRandom;
		public bool HasDiscount { get; private set; }

        public CashRegister(IDiscountCalculator discountCalculator = null)
        {
            _discountCalculator = discountCalculator;
        }

		public CashRegister(IDiscountRandom discountRandom)
		{
			_discountRandom = discountRandom;
		}
      
        public decimal HowMuch(Burger burger)
        {
			if (_discountCalculator != null)
			{
				return PriceWithDiscountPossibility(ValueBurger(burger)) + _discountCalculator.Calculate();
			}
            return PriceWithDiscountPossibility(ValueBurger(burger));
        }

        private decimal ValueBurger(Burger burger)
        {
            return burger.Price;
        }

		private decimal PriceWithDiscountPossibility(decimal price)
		{
			if(_discountRandom != null)
			{
				HasDiscount = _discountRandom.discount();
			}
			if (HasDiscount)
			{
				return price / 2;
			}
			return price;
		}
    }
}