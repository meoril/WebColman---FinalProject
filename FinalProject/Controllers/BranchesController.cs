using FinalProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FinalProject.Controllers
{
    public class BranchesController : Controller
    {
        private readonly JavaScriptSerializer _jsonSerializer;

        public BranchesController()
        {
            _jsonSerializer = new JavaScriptSerializer();
        }

        public ActionResult Index()
        {
            return View();
        }

        public string GetAllBranches()
        {
            using (var context = new BookStoreContext())
            {
                return _jsonSerializer.Serialize(context.Branches.ToArray());
            }
        }
    }
}