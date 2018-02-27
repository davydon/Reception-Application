using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReceptionApp.Models;
using System.Data.Entity;

namespace ReceptionApp.Controllers
{
    public class VisitorController : Controller
    {
        private DbModels dbModel = new DbModels();


        // GET: Visitor
        public ActionResult Index(string Surname)
        {
            var surname = from s in dbModel.Visitors
                          select s;
            if (!String.IsNullOrEmpty(Surname))
            {
                surname = surname.Where(c => c.Surname.Contains(Surname));
            }
            return View(surname);
        }


        public ActionResult AdminList(string Surname)
        {
            var surname = from s in dbModel.Visitors
                          select s;
            if (!String.IsNullOrEmpty(Surname))
            {
                surname = surname.Where(c => c.Surname.Contains(Surname));
            }
            return View(surname);
        }

        // GET: Visitor/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Visitors.Where(x => x.Id == id).FirstOrDefault());
            }
            
        }

        // GET: Visitor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visitor/Create
        [HttpPost]
        public ActionResult Create(Visitor visitor)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Visitors.Add(visitor);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index","Visitor");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visitor/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Visitors.Where(x => x.Id == id).FirstOrDefault());
            }
            
        }

        // POST: Visitor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visitor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Visitor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
