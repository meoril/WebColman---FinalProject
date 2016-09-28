using FinalProject.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FinalProject.Controllers
{
    public class StatsController : Controller
    {
        private readonly JavaScriptSerializer _jsonSerializer;

        public StatsController()
        {
            this._jsonSerializer = new JavaScriptSerializer();
        }

        // GET: Stats
        public ActionResult AuthorsBooksStats()
        {
            return View();
        }

        public string GetExtraAuthorsBooksStats()
        {
            using (var context = new BookStoreContext())
            {
                dynamic data = from bk in context.Books
                               group bk by bk.AuthorId into authBk
                               select new
                               {
                                   count = authBk.Count(),
                                   author = authBk.Key
                               };
                               
                return _jsonSerializer.Serialize(data);
            }
        }
    }
}