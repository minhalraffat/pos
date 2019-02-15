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
    public class ItemsController : Controller
    {
        private POSEntities db = new POSEntities();

        // GET: /Items/
        public ActionResult Index()
        {
            //var items = db.Items.Include(i => i.Brand).Include(i => i.Unit);
            //return View(items.ToList());
            return View();
        }

        // GET: /Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: /Items/Create
        public ActionResult Create()
        {
            ViewBag.brandid = new SelectList(db.Brands, "Bid", "BName");
            ViewBag.unitid = new SelectList(db.Units, "Uid", "UName");
            Item item = new Item();
            item.Createddate = DateTime.Now;
            item.LastModified = DateTime.Now;
            return View(item);
        }

        // POST: /Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Iid,IName,Quantity,brandid,unitid,Active,Createddate,LastModified,Genericformula")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brandid = new SelectList(db.Brands, "Bid", "BName", item.brandid);
            ViewBag.unitid = new SelectList(db.Units, "Uid", "UName", item.unitid);
            return View(item);
        }

        // GET: /Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.brandid = new SelectList(db.Brands, "Bid", "BName", item.brandid);
            ViewBag.unitid = new SelectList(db.Units, "Uid", "UName", item.unitid);
            return View(item);
        }

        // POST: /Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Iid,IName,Quantity,brandid,unitid,Active,Createddate,LastModified,Genericformula")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brandid = new SelectList(db.Brands, "Bid", "BName", item.brandid);
            ViewBag.unitid = new SelectList(db.Units, "Uid", "UName", item.unitid);
            return View(item);
        }

        // GET: /Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: /Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
        public JsonResult getItem() {

            var JsonData = new
            {
                data = db.Items.ToList().OrderByDescending(o=> o.Iid).Select(item => new Item
                {
                    IName = item.IName,
                    Quantity = item.Quantity,
                    brandid = item.brandid,
                    unitid = item.unitid,
                    Genericformula = item.Genericformula,

                    Action = "<a href='/Items/Edit?id="+item.Iid+"'>Edit</a> | " +
                             "<a href='/Items/Details?id="+item.Iid+"'>Details</a> | " +
                             "<a href='/Items/Delete?id="+item.Iid+"'>Delete</a>"
                
                
                
                })


            };

            return Json(JsonData, JsonRequestBehavior.AllowGet);

        }

    }
}
