using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyReklama.Models
{
    public class BodyOrder
    {
        public int Id { get; set; }
        public int HeadOrderId { get; set; }
        public int ServiceId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }

    }
}