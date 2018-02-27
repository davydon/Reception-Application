using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReceptionApp.Models;
using System.Data.Entity;

namespace ReceptionApp.Controllers
{
    public class DepartmentController : Controller
    {
        private DbModels dbModel = new DbModels();



        // GET: Department
        public ActionResult Index(string DepartmentName)
        {
            var department = from d in dbModel.Departments
                             select d;
            if (!String.IsNullOrEmpty(DepartmentName))
            {
                department = department.Where(c => c.DepartmentName.Contains(DepartmentName));
            }
            return View(department);
        }


        public ActionResult Dept(string DepartmentName)
        {
            var department = from d in dbModel.Departments
                             select d;

            if (!String.IsNullOrEmpty(DepartmentName))
            {
                department = department.Where(c => c.DepartmentName.Contains(DepartmentName));
            }
            return View(department);

        }


        // GET: Department/Details/5
        public ActionResult Details(int id)
        {

            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Departments.Where(x => x.Id == id).FirstOrDefault());
            }
            
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Department department)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Departments.Add(department);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index","Department");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Departments.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Entry(department).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index","Department");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Departments.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    Department department = dbModel.Departments.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Departments.Remove(department);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index","Department");
            }
            catch
            {
                return View();
            }
        }
    }
}
