using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication27.Models;

namespace WebApplication27.Controllers
{
    [Authorize]
    public class PayController : Controller
    {
        private DemoEntities db = new DemoEntities();

        // GET: Pay
        public ActionResult Index()
        {
            return View(db.Pay.ToList());
        }

        // GET: Pay/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay pay = db.Pay.Find(id);
            if (pay == null)
            {
                return HttpNotFound();
            }
            return View(pay);
        }

        // GET: Pay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "交易序號,醫療機構名稱,就醫帳號,手機,姓名,身分證號碼,出生年,科別,系統別,時段,金額,繳費日期,繳費方式,信用卡卡號,信用卡訂單編號,信用卡授權碼")] Pay pay)
        {
            if (ModelState.IsValid)
            {
                db.Pay.Add(pay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pay);
        }

        // GET: Pay/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay pay = db.Pay.Find(id);
            if (pay == null)
            {
                return HttpNotFound();
            }
            return View(pay);
        }

        // POST: Pay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "交易序號,醫療機構名稱,就醫帳號,手機,姓名,身分證號碼,出生年,科別,系統別,時段,金額,繳費日期,繳費方式,信用卡卡號,信用卡訂單編號,信用卡授權碼")] Pay pay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pay);
        }

        // GET: Pay/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay pay = db.Pay.Find(id);
            if (pay == null)
            {
                return HttpNotFound();
            }
            return View(pay);
        }

        // POST: Pay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pay pay = db.Pay.Find(id);
            db.Pay.Remove(pay);
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
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}
