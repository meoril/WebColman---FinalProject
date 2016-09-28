using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Context;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class AuthorsController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        // GET: Authors
        public ActionResult Index(string age, string AuthorName, string city)
        {
            var authors = db.Authors.AsQueryable();
            
            if (!String.IsNullOrEmpty(age))
            {
                authors = SearchByAge(authors, age);
            }

            if (!String.IsNullOrEmpty(AuthorName))
            {
                authors = SearchByAuthorName(authors, AuthorName);
            }

            if (!String.IsNullOrEmpty(city))
            {
                authors = SearchByCity(authors, city);
            }
            
            return View(authors);
        }

        public IQueryable<Author> SearchByAge(IQueryable<Author> authors, string strage)
        {
            int age = int.Parse(strage);
            return authors.Where(s => s.Age == age);
        }
        public IQueryable<Author> SearchByAuthorName(IQueryable<Author> authors, string AuthorName)
        {
            return authors.Where(s => s.Name.Contains(AuthorName));
        }
        public IQueryable<Author> SearchByCity(IQueryable<Author> authors, string city)
        {
            return authors.Where(s => s.City.Contains(city));
        }
   
        // GET: Authors/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Include(a => a.Books)
                .SingleOrDefault(a => a.Id == id);
            
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,City")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,City")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
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
    }
}
