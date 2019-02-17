namespace Mine2._0
{
    public class Canteen
    {
        private int _foodRation { get; set; }

        public void SetFoodRations(int rations) => _foodRation = rations;

        public int ServeFoodRaitons(int amountOfDwarfs)
        {
            _foodRation -= amountOfDwarfs;
            return amountOfDwarfs;
        }

        public void OrderFoodRationsIfNecessary()
        {
            if (_foodRation < 10)
            {
                _foodRation += 30;
            }
        }

        public int GetCurrentFoodRationsAmount()
        {
            return _foodRation;
        }
    }
}