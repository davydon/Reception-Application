using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReceptionApp.Models;
using System.Data.Entity;

namespace ReceptionApp.Controllers
{
    public class UserController : Controller

    {
        private DbModels dbModel = new DbModels();
        
        public ActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Create(User user)
        {
            using (DbModels dbModel = new DbModels())
            {
                dbModel.Users.Add(user);
                dbModel.SaveChanges();
            }
            return RedirectToAction("Index", "User");
        }





        // GET: User
        public ActionResult Index(string Surname)
        {

            var user = from u in dbModel.Users
                       select u;
            if (!String.IsNullOrEmpty(Surname))
            {
                user = user.Where(c => c.Surname.Contains(Surname));
            }
            return View(user);
        }



        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Users.Where(x => x.Id == id).FirstOrDefault());
            }
            
        }

        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Users.Where(x => x.Id == id).FirstOrDefault());
            }

        }

        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            using (DbModels dbModel = new DbModels())
            {
                dbModel.Entry(user).State = EntityState.Modified;
                dbModel.SaveChanges();
            }
            return RedirectToAction("Index", "User");
        }




        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Users.Where(x => x.Id == id).FirstOrDefault());
            }

        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (DbModels dbModel = new DbModels())
            {
                User user = dbModel.Users.Where(x => x.Id == id).FirstOrDefault();
                dbModel.Users.Remove(user);
                dbModel.SaveChanges();
            }
            return RedirectToAction("Index", "User");

        }




        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
       
        // POST: Login
        public ActionResult Login(User user)
        {
            using (DbModels dbModel = new DbModels())
            {
                var details = (from userlist in dbModel.Users
                               where userlist.Email == user.Email && userlist.Password == user.Password
                               select new
                               {

                                   userlist.Id,
                                   userlist.Email
                               }).ToList();

                if (details.FirstOrDefault() != null)
                {
                    Session["Id"] = details.FirstOrDefault().Id;
                    Session["Email"] = details.FirstOrDefault().Email;
                    return RedirectToAction("List","Employee");
                }

                else
                {
                    ModelState.AddModelError("", "Email or Password is incorrect");
                }
            }


            return View(user);
        }

        public ActionResult Welcome()
        {
            return View();
        }




        // GET: User
        public ActionResult Logout()
        {
            Session.Clear();
            // or Session["register"] = null;

            return RedirectToAction("Login","User");
        }
    }
}