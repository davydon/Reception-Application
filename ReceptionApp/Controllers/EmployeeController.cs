using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReceptionApp.Models;
using System.Data.Entity;

namespace ReceptionApp.Controllers
{
    public class EmployeeController : Controller
    {

        private DbModels dbModel = new DbModels();


        // GET: Employee
        public ActionResult Index(string Surname)
        {
            var surname = from s in dbModel.Employees
                          select s;
            if (!String.IsNullOrEmpty(Surname))
            {
                surname = surname.Where(c => c.Surname.Contains(Surname));
            }
            return View(surname);
        }


        public ActionResult List(string Surname)
        {

            var surname = from l in dbModel.Employees
                          select l;
            if (!String.IsNullOrEmpty(Surname))
            {
                surname = surname.Where(c => c.Surname.Contains(Surname));

            }
            return View(surname);

        }



        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Employees.Where(x => x.Id == id).FirstOrDefault());
            }
            
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Employees.Add(employee);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index","Employee");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Employees.Where(x => x.Id == id).FirstOrDefault());
            }
            
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Entry(employee).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Employees.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    Employee employee = dbModel.Employees.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Employees.Remove(employee);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index","Employee");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SideMenu()
        {
            return PartialView("SideMenu");
        }
    }
}
