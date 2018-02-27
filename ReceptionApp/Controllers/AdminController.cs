using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReceptionApp.Models;


namespace ReceptionApp.Controllers
{
    public class AdminController : Controller
    {

        private DbModels dbModel = new DbModels();

        
        public ActionResult Login()
        {
            return View();
        }




        [HttpPost]

        // POST: Login
        public ActionResult Login(Admin admin)
        {
            using (DbModels dbModel = new DbModels())
            {
                var details = (from userlist in dbModel.Admins
                               where userlist.Username == admin.Username && userlist.Password == admin.Password
                               select new
                               {

                                   userlist.Id,
                                   userlist.Username
                               }).ToList();

                if (details.FirstOrDefault() != null)
                {
                    Session["Id"] = details.FirstOrDefault().Id;
                    Session["Username"] = details.FirstOrDefault().Username;
                    return RedirectToAction("Index", "Employee");
                }

                else
                {
                    ModelState.AddModelError("", "Email or Password is incorrect");
                }
            }


            return View(admin);
        }


        public ActionResult LoggedIn()
        {
            return View();
        }

        public ActionResult SideMenu()
        {
            return PartialView("SideMenu");
        }

        public ActionResult UserMenu()
        {
            return PartialView("UserMenu");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            // or Session["register"] = null;

            return RedirectToAction("Login", "Admin");
        }
    }
}