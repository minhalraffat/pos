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
    public class AccountController : Controller
    {
        private POSEntities db = new POSEntities();

        // GET: /Account/
        public ActionResult Index()
        {
            //return View(db.Accounts.ToList());
            return View();
        }

        // GET: /Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: /Account/Create
        public ActionResult Create()
        {
            Account account = new Account();
            account.Createddate = DateTime.Now;
            account.LastModified = DateTime.Now;
            return View(account);
        }

        // POST: /Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Accid,AccName,AccNum,BankName,Active,Createddate,LastModified")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: /Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: /Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Accid,AccName,AccNum,BankName,Active,Createddate,LastModified")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: /Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: /Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
        public JsonResult getAccount() {

            var JsonData = new
            {

                data = db.Accounts.ToList().OrderByDescending(o=> o.Accid).Select(item => new Account
                {
                    AccName = item.AccName,
                    AccNum = item.AccNum,
                    BankName = item.BankName,

                    Action ="<a href='/Account/Edit?id="+item.Accid+"'>Edit</a> | " +
                             "<a href='/Account/Details?id="+item.Accid+"'>Details</a> | " +
                             "<a href='/Account/Delete?id="+item.Accid+"'>Delete</a>"
                

                
                })


            };

            return Json(JsonData,JsonRequestBehavior.AllowGet);
        
        }
    }
}
