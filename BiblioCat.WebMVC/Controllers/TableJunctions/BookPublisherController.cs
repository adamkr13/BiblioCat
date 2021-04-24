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
    [Authorize]
    public class BookPublisherController : Controller
    {        
        public ActionResult AddBooks(int id)
        {
            var service = CreateBookPublisherService();
            var books = service.GetBooks();
            var publisherModel = service.PublisherOptions(id);
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

        public ActionResult AddPublishers(int id)
        {
            var service = CreateBookPublisherService();
            var bookModel = service.BookOptions(id);
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

        public ActionResult RemoveBooks(int id)
        {
            var service = CreateBookPublisherService();
            var books = service.GetBooks();
            var publisherModel = service.PublisherOptions(id);
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

        public ActionResult RemovePublishers(int id)
        {
            var service = CreateBookPublisherService();
            var bookModel = service.BookOptions(id);
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

        private BookPublisherService CreateBookPublisherService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookPublisherService(userId);

            return service;
        }
    }
}