using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyReklama.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}