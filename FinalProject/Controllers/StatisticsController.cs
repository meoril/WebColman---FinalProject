using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Context;

namespace BookShop.Controllers
{
    public class StatisticsController : Controller
    {

        private BookStoreContext db = new BookStoreContext();
        public ActionResult AuthorsBooksStatistics()
        {
            return View();
        }

        public ActionResult CustomersCityStatistics()
        {
            return View();
        }

        public string GetAuthorsAndBooksCount()
        {
            return "age,population\r\n" + String.Join(Environment.NewLine, db.Authors
                .Select(x => x.Name + " - " + x.Books.Count + "," + x.Books.Count));
        }

        public string GetCustomersCityCount()
        {
            return "letter	frequency\r\n" + String.Join(Environment.NewLine, db.Customers.GroupBy(x => x.City)
                  .Select(x => x.Key + "\t" + x.Count()));
        }
    }
}