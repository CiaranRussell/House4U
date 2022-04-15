namespace Drippyz.Models
{
    public class Cart
    {
        private List<CartProducts> _products;

        public Cart()
        {
            _products = new List<CartProducts>();
        }

        public void AddProduct(Products products)
        {
            var match = _products.FirstOrDefault(p => p.ProductCode.ToLower() == products.ProductCode.ToLower());
            if (match == null)
            {
                _products.Add(new CartProducts()
                {
                    ProductCode = products.ProductCode,
                    ProductName = products.ProductName,
                    ProductDescription = products.ProductDescription,
                    ProductPrice = products.ProductPrice,
                    Quanity = 1
                });
            }
            else
            {
                match.Quanity++;
            }
            
        }

        public double CalculateTotalPrice()
        {
            return _products.Sum(prd => prd.ProductPrice * prd.Quanity);
        }

    }
}
