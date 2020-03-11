using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyReklama.Models
{
   
        public class MyAppContext : DbContext
        {
            public MyAppContext()
                : base("DbConnection")
            { }

            public DbSet<Client> Clients { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Service> Services { get; set; }
        }
    }
