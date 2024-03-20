using System;
using SQLite;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Models
{
    public class ShoppingItems
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }

        public string ImagePath { get; set; }
    }
}
