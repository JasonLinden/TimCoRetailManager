using Caliburn.Micro;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace TRM.WPF.UI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;
        private BindingList<string> _cart;
        private int _itemQuantity;

        public BindingList<string> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public bool CanAddToCart
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
                return "$0.00";
            }
        }

        public string Total
        {
            get
            {
                return "$0.00";
            }
        }

        public string Tax
        {
            get
            {
                return "$0.00";
            }
        }

        public async Task AddToCart()
        {
        }

        public bool CanRemoveFromCart
        {
            get
            {
                // return !string.IsNullOrEmpty(_userName) && !string.IsNullOrEmpty(_password);
                return false;
            }
        }

        public async Task RemoveFromCart()
        {
        }

        public bool CanCheckout
        {
            get
            {
                // return !string.IsNullOrEmpty(_userName) && !string.IsNullOrEmpty(_password);
                return false;
            }
        }

        public async Task Checkout()
        {
        }
    }
}
