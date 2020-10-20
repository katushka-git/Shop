using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyReklama.Models;
using System.Collections.Generic;

namespace MyReklama.Controllers
{
    public class OrderViewController : Controller
    {
        private MyAppContext db = new MyAppContext();
        // GET: OrderView
        public ActionResult Index(int? service)
        {
            IQueryable<Order> orders = db.Orders.Include(o => o.Client).Include(o => o.Employee).Include(o => o.Service);
            
            if (service != null && service != 0)
            {
                orders = orders.Where(p => p.ServiceId == service);
            }
            List<Service> services = db.Services.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            services.Insert(0, new Service { Name = "Все", Id = 0 });

            OrdersListViewModel plvm = new OrdersListViewModel
            {
                Orders = orders.ToList(),
                Services = new SelectList(services, "Id", "Name")
            };
            return View(plvm);
        }
    }
}