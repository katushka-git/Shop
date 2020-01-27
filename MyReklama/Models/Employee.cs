using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyReklama.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Adres { get; set; }
        public int Tel { get; set; }
        public int NumberOrder { get; set; }

        public ICollection<Order> Orders { get; set; }
        public Employee()
        {
            Orders = new List<Order>();
        }
    }
}