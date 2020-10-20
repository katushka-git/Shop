using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyReklama.Models
{
    public class OrdersListViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public SelectList Services { get; set; }
       
    }
}