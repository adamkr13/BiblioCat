using BiblioCat.Models.Book;
using BiblioCat.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiblioCat.WebMVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var service = CreateBookService();
            var model = service.GetBooks();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBookService();

            if (service.CreateBook(model))
            {
                TempData["SaveResult"] = "The book was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Book could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateBookService();
            var model = service.GetBookById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBookService();
            var detail = service.GetBookById(id);

            var model = new BookEdit
            {
                BookId = detail.BookId,
                Title = detail.Title,
                PublicationDate = detail.PublicationDate,
                ISBN = detail.ISBN,
                GenreOfBook = detail.GenreOfBook,
                FormatOfBook = detail.FormatOfBook,
                LoanedTo = detail.LoanedTo,
                Narrator = detail.Narrator,
                Translator = detail.Translator,
                Illustrator = detail.Illustrator,
                IsFirstEdition = detail.IsFirstEdition,
                IHaveRead = detail.IHaveRead,
                IOwn = detail.IOwn
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BookId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBookService();

            if (service.UpdateBook(model))
            {
                TempData["SaveResult"] = "The book was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The book could not be updated.");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateBookService();
            var model = service.GetBookById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBookService();
            service.DeleteBook(id);

            TempData["SaveResult"] = "The book was deleted.";

            return RedirectToAction("Index");
        }

        private BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userId);
            return service;
        }
    }
}