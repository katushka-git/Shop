using MyReklama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyReklama.Logic
{
    public class ForCreateOreder
    {
        public ForCreateOreder(Order or, Client cl, Service se)
        {
            order = or;
            client = cl;
            ser = se;

        }
        public Order order;
        public Client client;
        public Service ser;
    }
}