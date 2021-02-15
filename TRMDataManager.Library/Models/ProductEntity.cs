namespace TRMDataManager.Library.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public decimal RetailPrice { get; set; }
    }
}
