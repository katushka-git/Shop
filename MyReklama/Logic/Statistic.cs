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
            //MyService.serviceList = db.Services.GroupBy(item1 => item1.Price).Select(item => new ServiceItemView() { Sum = item.Sum() });
            //MyService.serviceList = db.Services.Where(x=>x.Price!=0).Sum(); 
            MyService.SumPrice = db.Services.Sum(x=>x.Price);
            return MyService;
        }
    }
}