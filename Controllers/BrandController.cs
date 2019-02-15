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
    public class BrandController : Controller
    {
        private POSEntities db = new POSEntities();

        // GET: /Brand/
        public ActionResult Index()
        {
            //var brands = db.Brands.Include(b => b.Category);
            //return View(brands.ToList());
            return View();
        }

        // GET: /Brand/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: /Brand/Create
        public ActionResult Create()
        {
            ViewBag.Categoryid = new SelectList(db.Categories, "Cid", "CName");
            Brand brand = new Brand();
            brand.Createddate = DateTime.Now;
            brand.LastModified = DateTime.Now;
            return View(brand);
        }

        // POST: /Brand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Bid,BName,BDesc,Quantity,Categoryid,Active,Createddate,LastModified")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoryid = new SelectList(db.Categories, "Cid", "CName", brand.Categoryid);
            return View(brand);
        }

        // GET: /Brand/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoryid = new SelectList(db.Categories, "Cid", "CName", brand.Categoryid);
            return View(brand);
        }

        // POST: /Brand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Bid,BName,BDesc,Quantity,Categoryid,Active,Createddate,LastModified")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoryid = new SelectList(db.Categories, "Cid", "CName", brand.Categoryid);
            return View(brand);
        }

        // GET: /Brand/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: /Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
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
        public JsonResult getBrand() {

            var JsonData = new
            {

                data = db.Brands.ToList().OrderByDescending(o=> o.Bid).Select(item => new Brand
                {
                    BName = item.BName,
                    BDesc = item.BDesc,
                    Quantity = item.Quantity,
                    Categoryid  = item.Categoryid,

                    Action = "<a href='/Brand/Edit?id="+item.Bid+"'>Edit</a> | " +
                            "<a href='/Brand/Details?id="+item.Bid+"'>Details</a> |" +
                            "<a href='/Brand/Delete?id="+item.Bid+"'>Delete</a>"
                
                
                })

            };

            return Json(JsonData, JsonRequestBehavior.AllowGet);
        }
        
    }
}
