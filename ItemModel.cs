using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryyStoreApplication.Models
{
    public class ItemModel
    {
        [Key]
        public int ItemId { get; set; }
        public String ItemName { get; set; }

        public float Price { get; set; }

        public int GroceryId { get; set; }
       // [ForeignKey("GroceryId")]

        //public GroceryTable groceryTable{get;set;}
    }
}
