using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TRM.WPF.Library.Api.Interfaces;
using TRM.WPF.Library.Models;
using TRM.WPF.UI.Models;

namespace TRM.WPF.UI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private ObservableCollection<ProductModel> _products;
        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();
        private ProductModel _selectedProduct;
        private int _itemQuantity = 1;
        private readonly IProductApi _productApi;

        public SalesViewModel(IProductApi productApi)
        {
            _productApi = productApi;
        }

        protected override async void OnInitialize()
        {
            Products = new ObservableCollection<ProductModel>(await _productApi.GetAllProducts());

            base.OnInitialize();
        }

        #region Properties

        public ObservableCollection<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        public BindingList<CartItemModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        public bool CanAddToCart
        {
            get
            {
                return _itemQuantity > 0 && _selectedProduct?.QuantityInStock >= _itemQuantity;
            }
        }

        public bool CanCheckout
        {
            get
            {
                // return !string.IsNullOrEmpty(_userName) && !string.IsNullOrEmpty(_password);
                return false;
            }
        }

        public bool CanRemoveFromCart
        {
            get
            {
                // return !string.IsNullOrEmpty(_userName) && !string.IsNullOrEmpty(_password);
                return false;
            }
        }

        public string SubTotal
        {
            get
            {
                return CalcSubTotal().ToString("C");
            }
        }

        public string Total
        {
            get
            {
                decimal total = CalcSubTotal() + CalcTax();

                return total.ToString("C");
            }
        }

        public string Tax
        {
            get
            {
                return CalcTax().ToString("C");
            }
        }

        #endregion

        #region Methods

        public async Task AddToCart()
        {
            CartItemModel exitingModel = Cart.FirstOrDefault(x => x.Product == SelectedProduct);

            if (exitingModel != null)
            {
                exitingModel.QuantityInCart += _itemQuantity;
                Cart.ResetBindings();
            }
            else
            {
                CartItemModel newItem = new CartItemModel
                {
                    Product = _selectedProduct,
                    QuantityInCart = _itemQuantity
                };
                Cart.Add(newItem);
            }

            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = 1;

            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => Cart);
        }

        public async Task RemoveFromCart()
        {
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
        }

        public async Task Checkout()
        {
        }

        private decimal CalcSubTotal()
        {
            decimal subTotal = 0;

            for (int i = 0; i < Cart.Count; i++)
            {
                subTotal += Cart[i].Product.RetailPrice * Cart[i].QuantityInCart;
            }

            return subTotal;
        }

        private decimal CalcTax()
        {
            decimal taxAmount = 0;

            for (int i = 0; i < Cart.Count; i++)
            {
                taxAmount += (Cart[i].Product.RetailPrice * Cart[i].QuantityInCart) * (Cart[i].Product.TaxPercent / 100);
            }

            return taxAmount;
        }

        #endregion
    }
}
