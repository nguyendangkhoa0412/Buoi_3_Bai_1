using Buoi_3_Bai_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Buoi_3_Bai_1.Controllers
{
    public class BookController : Controller
    {
        BookManagerContext context = new BookManagerContext();
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Books.ToList();
            return View(listBook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)   
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();    
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ID,Title,Author,Description,Images,Price")]Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("ListBook");
            }
            return View(book);
        }
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = context.Books.Find(id);
            if (book==null) 
            {
                return HttpNotFound();
            }


            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Author,Description,Images,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                context.Entry(book).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("ListBook");
            }
            return View(book);
        }
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }
            Book book = context.Books.Find(id);
            if(book == null)
            {

            
                return HttpNotFound();
            }


            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Book book = context.Books.Find(id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("ListBook");
        }
    }
}