using SQLite;
using System;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Models
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int CustomerProfileId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        [ForeignKey(typeof(CustomerCart))]
        public int? CartItemId { get; set; }

        [ManyToOne]
        public CustomerCart CustomerCart { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ShoppingItems> ShoppingItems { get; set; }

        public Customer()
        {
            ShoppingItems = new List<ShoppingItems>();
        }
    }
}

