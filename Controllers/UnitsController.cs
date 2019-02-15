using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POS1.Models;

namespace POS1.Controllers
{
    public class UnitsController : Controller
    {
        private POSEntities db = new POSEntities();

        // GET: /Units/
        public ActionResult Index()
        {
            //return View(db.Units.ToList());
            return View();
        }

        // GET: /Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: /Units/Create
        public ActionResult Create()
        {
            Unit unit = new Unit();
            unit.Createddate = DateTime.Now;
            unit.LastModified = DateTime.Now;
            return View(unit);
        }

        // POST: /Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Uid,UName,Single,Box,Carton,Active,LastModified,Createddate")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: /Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: /Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Uid,UName,Single,Box,Carton,Active,LastModified,Createddate")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        // GET: /Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: /Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.Units.Find(id);
            db.Units.Remove(unit);
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

        [HttpGet]
        public JsonResult getUnit() {

            var JsonData = new
            {
                data = db.Units.ToList().OrderByDescending(o=> o.Uid).Select(item => new Unit
                {
                       UName = item.UName,
                       Single = item.Single,
                       Box = item.Box,
                       Carton = item.Carton,

                       Action ="<a href='/Units/Edit?id="+item.Uid+"'>Edit</a> | " +
                               "<a href='/Units/Details?id="+item.Uid+"'>Details</a> | " +
                               "<a href='/Units/Delete?id="+item.Uid+"'>Delete</a>"
                
                
                })


            };


            return Json(JsonData,JsonRequestBehavior.AllowGet);

        
        }
    }
}
