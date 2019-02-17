namespace Mine2._0
{
    public class Bank
    {
        private decimal _taxes { get; set; }

        public void AddTax(decimal newTax)
        {
            _taxes += newTax;
        }

        public decimal GetCurretnTax()
        {
            return _taxes;
        }
    }
}