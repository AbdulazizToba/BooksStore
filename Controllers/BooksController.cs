using Books.Models;
using Books.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContect _Context;
        public BooksController()
        {
            _Context = new ApplicationDbContect();
        }
        // GET: Books
        public ActionResult Index()
        {
            var books = _Context.Books.Include(m => m.Category).ToList();
            return View(books);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = _Context.Books.Include(m => m.Category).SingleOrDefault(m => m.Id == id);
            if (id == null)
                return HttpNotFound();
            return View(book);
        }
        public ActionResult Create()
        {
            var ViewModel = new BookFormViewModel
            {
                Categories = _Context.Categories.Where(m => m.IsActive).ToList()
            };
            return View("BookForm", ViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = _Context.Books.Find(id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Description = book.Description,
                Categories = _Context.Categories.Where(m => m.IsActive).ToList()
            };
            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _Context.Categories.Where(m => m.IsActive).ToList();
                return View("BookForm", model);
            }
            if (model.Id == 0)
            {
                var book = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    CategoryId = model.CategoryId,
                    Description = model.Description

                };
                _Context.Books.Add(book);
            }
            else
            {
                var book = _Context.Books.Find(model.Id);
                if (book == null)
                    return HttpNotFound();

                book.Title = model.Title;
                book.Author = model.Author;
                book.CategoryId = model.CategoryId;
                book.Description = model.Description;
            }

            _Context.SaveChanges();

            TempData["Message"] = "Saved successfully";
            return RedirectToAction("Index");

        }

    }

}