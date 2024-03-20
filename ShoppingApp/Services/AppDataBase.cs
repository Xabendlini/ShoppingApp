using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using SQLite;
using ShoppingApp.Models;

namespace ShoppingApp.Services
{
    public class AppDataBase
    {
        private SQLiteConnection _Connection;

        public string GetDatabasePath()
        {
            string filename = "appdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, filename);
        }

        public AppDataBase()
        {

            _Connection = new SQLiteConnection(GetDatabasePath());
            _Connection.CreateTable<Customer>();
            _Connection.CreateTable<ShoppingItems>();
            _Connection.CreateTable<CustomerCart>();


            SeedDatabase();

        }


        public void SeedDatabase()
        {
            if (_Connection.Table<Customer>().Count() == 0)
            {
                Customer customerProfile = new Customer()
                {
                    Name = "Zintle",
                    Surname = "Xabendlini",
                    Email = "xabendlinizintle0@gmail.com",

                };
                _Connection.Insert(customerProfile);
            }
            if (_Connection.Table<ShoppingItems>().Count() == 0)
            {
                List<ShoppingItems> items = new List<ShoppingItems>()
                {
                    new ShoppingItems()
                    {
                        ProductName = "Beer",
                        Price = "R 19.00",
                        Quantity = 10,
                        ImagePath = "beerpic.jpeg"
                    },

                    new ShoppingItems()
                    {
                        ProductName = "Cider",
                        Price = "R 29.99",
                        Quantity = 2,
                        ImagePath = "cider.jpeg"
                    },

                    new ShoppingItems()
                    {
                        ProductName = "Shots",
                        Price = "R 14.00",
                        Quantity = 10,
                        ImagePath = "shots.jpeg"
                    }
                };
                _Connection.InsertAll(items);
            }
        }

        public Customer GetCustomerById(int Id)
        {
            Customer customer = _Connection.Table<Customer>().Where(x => x.CustomerProfileId == Id).FirstOrDefault();
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            _Connection.Update(customer);
        }

        public List<ShoppingItems> GetAllShoppingItems()
        {

            return _Connection.Table<ShoppingItems>().ToList();

        }

        public void AddShoppingItemToCustomer(int customerId, int shoppingItemId)
        {
            var customer = _Connection.Get<Customer>(customerId);
            var shoppingItem = _Connection.Get<ShoppingItems>(shoppingItemId);

            customer.ShoppingItems.Add(shoppingItem);
            _Connection.Update(customer);
        }

        public void RemoveShoppingItemFromCustomer(int customerId, int shoppingItemId)
        {
            var customer = _Connection.Get<Customer>(customerId);
            var shoppingItem = _Connection.Get<ShoppingItems>(shoppingItemId);

            customer.ShoppingItems.Remove(shoppingItem);
            _Connection.Update(customer);
        }
        public List<CustomerCart> GetCustomerCartItems()
        {

            int customerId = GetCurrentCustomerId(); 

            
            List<CustomerCart> cartItems = _Connection.Table<CustomerCart>().Where(item => item.CustomerProfileId == customerId).ToList();

            return cartItems;
        }
        private int GetCurrentCustomerId()
        {

            return 1;


        }

        internal void AddShoppingItemToCustomer(object customerProfileId, int itemId)
        {
            throw new NotImplementedException();
        }

        internal void AddShoppingItemToCustomer(object itemId)
        {
            throw new NotImplementedException();
        }
    }
}

