using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginData model)
        {
            // Validate model
            if (ModelState.IsValid)
            {
                // Check if the admin password is entered correctly
                if (model.UserName.ToLower() == "admin" && model.Password == "Aa123456")
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                }
            }
            
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Admin");
        }
    }
}