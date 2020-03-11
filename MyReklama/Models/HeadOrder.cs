using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyReklama.Models
{
    public class HeadOrder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        //public Employee Employee { get; set; }
        public int ClientId { get; set; }
        //public Client Client { get; set; }
        public int Sum { get; set; }
        public ICollection<BodyOrder> BodyOrders { get; set; }
        public HeadOrder()
        {
            BodyOrders = new List<BodyOrder>();
        }

    }
}