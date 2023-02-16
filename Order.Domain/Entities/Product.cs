namespace Orders.Domain.Entities
{
    public class Product : Entity
    {
        public string ProductName { get; private set; }

        public Product(string productName)
        {
            ProductName = productName;
        }

        public void UpdateProductName(string productName)
        {
            ProductName = productName;
        }
    }
}
