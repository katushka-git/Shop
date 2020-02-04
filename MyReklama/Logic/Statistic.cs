using MyReklama.Models;
using MyReklama.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyReklama.Logic
{
    public class Statistic
    {
        ServiceView MyService;

        public Statistic()

        {

            MyService = new ServiceView();

        }

        public ServiceView getServiceResult()

        {

            MyAppContext db = new MyAppContext();

            MyService.serviceList = db.Orders.GroupBy(item1 => item1.Service).Select(item => new ServiceItemView() { Name = item.Key.Name, Count = item.Count() }).ToList();

            MyService.clientList = db.Orders.GroupBy(item1 => item1.Client).Select(item => new ServiceItemView() { Name = item.Key.FIO, Count = item.Count() }).ToList();

            MyService.userList = db.Orders.GroupBy(item1 => item1.Employee).Select(item => new ServiceItemView() { Name = item.Key.FIO, Count = item.Count() }).ToList();

            return MyService;
        }
    }
}