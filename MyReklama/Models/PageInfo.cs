using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyReklama.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class IndexViewModel2
    {
        public IEnumerable<Service> Service { get; set; }
        public IEnumerable<Client> Client { get; set; }
        public IEnumerable<Employee> Employee { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}