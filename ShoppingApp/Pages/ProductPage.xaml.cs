using ShoppingApp.Models;
using ShoppingApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace ShoppingApp.Pages
{
    public partial class ProductPage : ContentPage
    {
        private AppDataBase _database;
        private Customer _currentCustomer;
        private ObservableCollection<ShoppingItems> _items;

        public ObservableCollection<ShoppingItems> Items
        {
            get { return _items; }
            set
            {
                _items = value;

                OnPropertyChanged();

            }
        }

        public ProductPage()
        {
            InitializeComponent();
            _database = new AppDatabase();
            BindingContext = this;
            LoadData();
        }



        private void LoadData()
        {
            // _currentCustomer = _database.GetCustomerById(1);
            Items = new ObservableCollection<ShoppingItems>(_database.GetAllShoppingItems());
            //ShoppingItemsListView.BindingContext = Items;
        }

        private void AddShoppingItem_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var shoppingItem = (ShoppingItems)button.CommandParameter;

            _database.AddShoppingItemToCustomer(_currentCustomer.CustomerProfileId, shoppingItem.ItemId);
        }

    }
}
