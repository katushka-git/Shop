using MyReklama.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyReklama.Models.View
{

    public class ServiceView

    {
        public string Name { get; set; }
        public int Count { get; set; }
        public List<ServiceItemView> serviceList { get; set; }

        public List<ServiceItemView> userList { get; set; }

        public List<ServiceItemView> clientList { get; set; }

    }

}