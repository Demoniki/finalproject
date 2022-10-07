using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryyStoreApplication.Models
{
    public class GroceryTable
    {
        [Key]
        public int GroceryId { get; set; }


        public String GroceryCategory { get; set; }
       
    }
}
