using System;
using System.Collections.Generic;
using System.Data.Entity;
using MySql.Data;
using System.Linq;
using System.Web;
using MySql.Data.EntityFramework;
using System.Reflection.Emit;
using WbHooksCroydon.Domain.Yuju.Models;

namespace WbHooksCroydon.Models.DataBase
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MarketPlaceHooksContext : DbContext
    {
        public MarketPlaceHooksContext() : base("MarketPlaceHooks")
        {

        }

        public DbSet<orders_hooks> orders
        {
            get; set;
        }
        public DbSet<Billing_Address> Billing_Address
        {
            get; set;
        }
        public DbSet<Customer> Customer
        {
            get; set;
        }
        public DbSet<Item> Item
        {
            get; set;
        }
        public DbSet<OrderDetail> OrderDetail
        {
            get; set;
        }
        public DbSet<Product> Product
        {
            get; set;
        }
        public DbSet<Progress> Progress
        {
            get; set;
        }
        public DbSet<Shipping_Address> Shipping_Address
        {
            get; set;
        }

    }
}