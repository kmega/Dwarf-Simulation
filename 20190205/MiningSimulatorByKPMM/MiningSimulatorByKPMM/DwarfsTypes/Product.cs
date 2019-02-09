using MiningSimulatorByKPMM.Enums;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public class Product
    {
        private E_ProductsType _productType;
        private decimal _quantity;

        public decimal Quantity
        {
            get { return _quantity; }
        }
        public E_ProductsType ProductType
        {
            get { return _productType; }
        }


        public Product(E_ProductsType productType, decimal quantity)
        {
            this._productType = productType;
            this._quantity = quantity;
        }
    }
}