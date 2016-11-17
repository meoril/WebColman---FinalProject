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

        /// <summary>
        /// This method returns all branches in json format.
        /// </summary>
        /// <returns>All the branches as json array</returns>
        public string GetAllBranches()
        {
            using (var context = new BookStoreContext())
            {
                // Fetching the branches as array and serializing the data to json format using JavaScriptSerializer
                return _jsonSerializer.Serialize(context.Branches.ToArray());
            }
        }
    }
}