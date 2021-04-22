using BiblioCat.Models.TableJunctions.BookPublisher;
using BiblioCat.Services.TableJunctions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiblioCat.WebMVC.Controllers.TableJunctions
{
    public class BookPublisherController : Controller
    {
        [Authorize]
        // GET: BookPublisher
        public ActionResult Index()
        {
            var service = CreateBookPublisherService();
            var model = service.GetBookPublishers();
            return View(model);
        }

        public ActionResult AddBooks()
        {
            var service = CreateBookPublisherService();
            var books = service.GetBooks();
            var publisherModel = service.PublisherOptions();
            ViewBag.Books = books;
            ViewData["Publishers"] = publisherModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBooks(AddBooksCreate model)
        {
            var service = CreateBookPublisherService();

            service.AddBook(model);

            return RedirectToAction("Index", "Publisher");
        }

        public ActionResult AddPublishers()
        {
            var service = CreateBookPublisherService();
            var bookModel = service.BookOptions();
            var publishers = service.GetPublishers();
            ViewBag.Publishers = publishers;
            ViewData["Books"] = bookModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPublishers(AddPublishersCreate model)
        {
            var service = CreateBookPublisherService();

            service.AddPublisher(model);

            return RedirectToAction("Details", "Book", new { id = model.BookId });
        }

        public ActionResult RemoveBooks()
        {
            var service = CreateBookPublisherService();
            var books = service.GetBooks();
            var publisherModel = service.PublisherOptions();
            ViewBag.Books = books;
            ViewData["Publishers"] = publisherModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveBooks(AddBooksCreate model)
        {
            var service = CreateBookPublisherService();

            service.RemoveBook(model);

            return RedirectToAction("Index", "Publisher");
        }

        public ActionResult RemovePublishers()
        {
            var service = CreateBookPublisherService();
            var bookModel = service.BookOptions();
            var publishers = service.GetPublishers();
            ViewBag.Publishers = publishers;
            ViewData["Books"] = bookModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemovePublishers(AddPublishersCreate model)
        {
            var service = CreateBookPublisherService();

            service.RemovePublisher(model);

            return RedirectToAction("Details", "Book", new { id = model.BookId });
        }

        //public ActionResult Create()
        //{
        //    var service = CreateBookPublisherService();
        //    var bookModel = service.BookOptions();
        //    var publisherModel = service.PublisherOptions();
        //    ViewData["Books"] = bookModel;
        //    ViewData["Publishers"] = publisherModel;

        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(BookPublisherCreate model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var service = CreateBookPublisherService();

        //    if (service.CreateBookPublisher(model))
        //    {
        //        var bp = service.GetBookPublisherById(model.BookId, model.PublisherId);
        //        TempData["SaveResult"] = $"Book {bp.Title} has been added to publisher {bp.PublisherName}";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "The book could not be added to the publisher.");

        //    return View(model);
        //}

        //public ActionResult Delete(int bookId, int publisherId)
        //{
        //    var service = CreateBookPublisherService();
        //    var model = service.GetBookPublisherById(bookId, publisherId);

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("Delete")]
        //public ActionResult DeletePost(int bookId, int publisherId)
        //{
        //    var service = CreateBookPublisherService();
        //    service.DeleteBookPublisher(bookId, publisherId);

        //    return RedirectToAction("Index");
        //}

        private BookPublisherService CreateBookPublisherService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookPublisherService(userId);

            return service;
        }
    }
}