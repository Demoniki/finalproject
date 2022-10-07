using EGroceryyStoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryyStoreApplication.Data
{
    public class GroceryDbContext:DbContext
    {
        public GroceryDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<UserAccountModel> UserAccount { get; set; }
        public DbSet<LoginModel>LoginModel { get; set; }
        public DbSet<RolesModel> RolesModel { get; set; }


        public DbSet<GroceryTable> GroceryTables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<RatingModel> RatingModels { get; set; }
        public DbSet<ItemModel> ItemModels { get; set; }

    }
}
