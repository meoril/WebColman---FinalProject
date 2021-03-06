﻿using System;
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
    public class BooksController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        // GET: Books
        public ActionResult Index(string bookName, string AuthorName, string price)
        {
            var books = db.Books.Include(b => b.Author);

            if (!String.IsNullOrEmpty(bookName))
            {
                books = SearchByBookName(books, bookName);
            }

            if (!String.IsNullOrEmpty(AuthorName))
            {
                books = SearchByAuthorName(books, AuthorName);
            }

            if (!String.IsNullOrEmpty(price))
            {
                books = SearchByPrice(books, price);
            }

            return View(books.ToList());
        }

        public IQueryable<Book> SearchByBookName(IQueryable<Book> books, string bookName)
        {
            return books.Where(s => s.Name.Contains(bookName));
        }
        public IQueryable<Book> SearchByAuthorName(IQueryable<Book> books, string AuthorName)
        {
            return books.Where(s => s.Author.Name.Contains(AuthorName));
        }
        public IQueryable<Book> SearchByPrice(IQueryable<Book> books, string strprice)
        {
            int price = int.Parse(strprice);
            return books.Where(s => s.Price == price);
        }
        // GET: Books/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,NumberOfPages,Price,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            // Reloading the authors data for in the format needed on client
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,NumberOfPages,Price,AuthorId")] Book book)
        {
            // Validating the given book's model before saving the modifications
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Reloading the authors data for in the format needed on client
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
