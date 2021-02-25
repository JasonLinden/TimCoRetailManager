using TRM.WPF.Library.Models;

namespace TRM.WPF.UI.Models
{
    public class CartItemModel
    {
        public ProductModel Product { get; set; }
        public int QuantityInCart { get; set; }

        public string DisplayText
        {
            get
            {
                return $"{Product.ProductName} ({QuantityInCart})";
            }
        }
    }
}
