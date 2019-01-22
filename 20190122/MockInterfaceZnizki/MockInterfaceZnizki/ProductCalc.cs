using System;

namespace MockInterfaceZnizki
{
    public class ProductCalc: IDiscount_Calc
    {
        public enum Type { Clothes, TurtleShoes, Others}
        public DateTime dateTime { get; set; }

        double IDiscount_Calc.Calculate(Type type)
        {
            if (type == Type.Clothes)
            {
                double price = DataReposit.ClothesPrice();
                double discount = 0.3;
                return price - (price * discount);
            }
            else if (type == Type.TurtleShoes)
            {
                double price = DataReposit.ShoesTurtlePrice();
                double discount = 0.2;
                return price + (price * discount);
            }
            else
            {
                double price = DataReposit.OtherThingsPrice();
                return price;
            }
        }

        double IDiscount_Calc.Calculate(DateTime dt)
        {
            
            if (dt.Day >= 19 && dt.Day <=24 && dt.Month == 12)
            {
                double price = DataReposit.OtherThingsPrice();
                double discount = 0.2;
                return price - (price * discount);

            }
            if (dt.Day ==29 &&  dt.Month == 11)
            {
                double price = DataReposit.OtherThingsPrice();
                double discount = 0.5;
                return price - (price * discount);

            }
            else
            {
                double price = DataReposit.OtherThingsPrice();
                return price;
            }
        
        }

    }
}