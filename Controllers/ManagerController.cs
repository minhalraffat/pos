using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POS1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace POS1.Controllers
{
    public class ManagerController : Controller
    {
        private POSEntities db = new POSEntities();

        // GET: /Manager/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Manager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: /Manager/Create
        public ActionResult Create()
        {
            Company company = new Company { };
            company.Createddate = DateTime.Now;          
            company.LastModified = DateTime.Now;
            return View(company);
        }

        // POST: /Manager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Comid,ComName,ComAdd,Active,Createddate,LastModified")] Company company)
        {
            if (ModelState.IsValid)
            {

                company.Createddate = DateTime.Now.Date;
                //DateTime now = System.DateTime.Now;
                company.LastModified = DateTime.Now.Date;
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View(company);
        }

        public class Foo
        {
            public DateTime Createddate { get; set; }
            public Foo()
            {
                Createddate = DateTime.Now;
            }

        }

        // GET: /Manager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: /Manager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Comid,ComName,ComAdd,Active,Createddate,LastModified")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: /Manager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: /Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public JsonResult GetList()
        //{
        //    return Json(db.Companies.ToList(),JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public JsonResult getCompany()
        {
           

            var jsonData = new
            {
                data = db.Companies.ToList().OrderByDescending(o => o.Comid).Select(item => new Company
                {
                    ComName = item.ComName,
                    ComAdd = item.ComAdd,
                    Action = "<a href='/Manager/Edit?id=" + item.Comid + "'>Edit</a> | <a href='/Manager/Delete?id=" + item.Comid + "'>Delete</a> | <a href='/Manager/Details?id="+item.Comid+"'>Details</a>"
                    
                })
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
