using ShoppingApp.Models;
using ShoppingApp.Services;

namespace ShoppingApp
{
    public partial class MainPage : ContentPage
    {
        private AppDataBase _database;
        private Customer _currentCustomer;


        public Customer CurrentCustomer
        {
            get { return _currentCustomer; }
            set
            {
                _currentCustomer = value;

                OnPropertyChanged();

            }
        }

        public MainPage()
        {
            InitializeComponent();
            _database = new AppDataBase();

            BindingContext = this;

        }

        private void OnPropertyChanged()
        {
            base.OnAppearing();

        }

        private void LoadData()
        {
            Customer customer = _database.GetCustomerById(1);

        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            _database.UpdateCustomer(CurrentCustomer);                                                                            ;
        }
    }
}


