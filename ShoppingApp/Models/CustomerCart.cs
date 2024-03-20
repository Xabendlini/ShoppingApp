using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Models
{
    public class CustomerCart
    {
        [PrimaryKey, AutoIncrement]
        public int CustomerCartId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }

        [ForeignKey(typeof(Customer))]
        public int? CustomerProfileId { get; set; }

        [ManyToOne]
        public Customer Customer { get; set; }

        public CustomerCart()
        {
            Customer = new Customer();
        }
    }
}

