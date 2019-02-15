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
    public class VendorController : Controller
    {
        private POSEntities db = new POSEntities();

        // GET: /Vendor/
        public ActionResult Index()
        {
            //var vendors = db.Vendors.Include(v => v.Account).Include(v => v.Company);
            //return View(vendors.ToList());
            return View();
        }

        // GET: /Vendor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: /Vendor/Create
        public ActionResult Create()
        {
            ViewBag.Accid = new SelectList(db.Accounts, "Accid", "AccName");
            ViewBag.Companyid = new SelectList(db.Companies, "Comid", "ComName");
            Vendor vendor = new Vendor();
            vendor.CreatedDate = DateTime.Now;
            vendor.LastModified = DateTime.Now;
            return View(vendor);
        }

        // POST: /Vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Vid,VName,VContactNumber,Active,CreatedDate,LastModified,Remarks,Companyid,Accid")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Accid = new SelectList(db.Accounts, "Accid", "AccName", vendor.Accid);
            ViewBag.Companyid = new SelectList(db.Companies, "Comid", "ComName", vendor.Companyid);
            return View(vendor);
        }

        // GET: /Vendor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Accid = new SelectList(db.Accounts, "Accid", "AccName", vendor.Accid);
            ViewBag.Companyid = new SelectList(db.Companies, "Comid", "ComName", vendor.Companyid);
            return View(vendor);
        }

        // POST: /Vendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Vid,VName,VContactNumber,Active,CreatedDate,LastModified,Remarks,Companyid,Accid")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Accid = new SelectList(db.Accounts, "Accid", "AccName", vendor.Accid);
            ViewBag.Companyid = new SelectList(db.Companies, "Comid", "ComName", vendor.Companyid);
            return View(vendor);
        }

        // GET: /Vendor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: /Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
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
        public JsonResult getVendor() {

            var JsonData = new
            {

                data = db.Vendors.ToList().OrderByDescending(o => o.Vid).Select(item => new Vendor
                {

                    VName = item.VName,
                    VContactNumber = item.VContactNumber,
                    Remarks = item.Remarks,
                     CompanyName = item.Company!=null?item.Company.ComName:string.Empty,
                    AccountName = item.Account != null ? item.Account.AccName : string.Empty,

                    Action = "<a href='/Vendor/Edit?id=" + item.Vid + "'>Edit</a> | " +  
                    "<a href='/Vendor/Details?id="+item.Vid+"'>Details</a> | " +
                    "<a href='/Vendor/Delete?id="+item.Vid+"'>Delete</a>"

                })
            };

            return Json(JsonData, JsonRequestBehavior.AllowGet);
        
        }




    }
}
