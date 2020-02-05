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

           //{

        //    MyService = new ServiceView();

        //}

        //public ServiceView getServiceResult()

        //{

        //    MyAppContext db = new MyAppContext();

        //    MyService.serviceList = db.Orders.GroupBy(item1 => item1.Service).Select(item => new ServiceItemView() { Name = item.Key.Name, Count = item.Count() }).ToList();

        //    MyService.clientList = db.Orders.GroupBy(item1 => item1.Client).Select(item => new ServiceItemView() { Name = item.Key.FIO, Count = item.Count() }).ToList();

        //    MyService.userList = db.Orders.GroupBy(item1 => item1.Employee).Select(item => new ServiceItemView() { Name = item.Key.FIO, Count = item.Count() }).ToList();

        //    return MyService;
        //}
         List<ServiceView> listServices;
        public Statistic()
        {
            listServices = new List<ServiceView>();
        }

        public List<ServiceView> getListServices()
        {

            MyAppContext db = new MyAppContext();
            listServices = db.Orders.GroupBy(item1 => item1.Service).Select(item => new ServiceView() { Name = item.Key.Name, Count = item.Count() }).ToList();
            return listServices;
        }
    }
}