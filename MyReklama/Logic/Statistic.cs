using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyReklama.Logic
{
    public class Statistic
    {
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