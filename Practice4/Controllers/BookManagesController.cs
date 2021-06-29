using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practice4.Data;
using Practice4.Models;

namespace Practice4.Controllers
{
    public class BookManagesController : Controller
    {
        private Practice4Context db = new Practice4Context();

        // GET: BookManages
        public ActionResult Index()
        {
            return View(db.BookManages.ToList());
        }

        // GET: BookManages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookManage bookManage = db.BookManages.Find(id);
            if (bookManage == null)
            {
                return HttpNotFound();
            }
            return View(bookManage);
        }

        // GET: BookManages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookManages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Author,Description,ImageCover,Price")] BookManage bookManage)
        {
            if (ModelState.IsValid)
            {
                db.BookManages.Add(bookManage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookManage);
        }

        // GET: BookManages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookManage bookManage = db.BookManages.Find(id);
            if (bookManage == null)
            {
                return HttpNotFound();
            }
            return View(bookManage);
        }

        // POST: BookManages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,Description,ImageCover,Price")] BookManage bookManage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookManage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookManage);
        }

        // GET: BookManages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookManage bookManage = db.BookManages.Find(id);
            if (bookManage == null)
            {
                return HttpNotFound();
            }
            return View(bookManage);
        }

        // POST: BookManages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookManage bookManage = db.BookManages.Find(id);
            db.BookManages.Remove(bookManage);
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

        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManage book = db.BookManages.SingleOrDefault(p => p.Id == id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
    }
}
