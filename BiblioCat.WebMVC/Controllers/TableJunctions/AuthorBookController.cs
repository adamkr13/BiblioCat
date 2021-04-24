using BiblioCat.Models.TableJunctions.AuthorBook;
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
    public class AuthorBookController : Controller
    {        
        public ActionResult AddBooks(int id)
        {
            var service = CreateAuthorBookService();
            var authorModel = service.AuthorOptions(id);
            var books = service.GetBooks();
            ViewBag.Books = books;
            ViewData["Authors"] = authorModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBooks(AddBooksCreate model)
        {
            var service = CreateAuthorBookService();
                        
            service.AddBook(model);

            return RedirectToAction("Index", "Author");
        }

        public ActionResult AddAuthors()
        {
            var service = CreateAuthorBookService();
            var bookModel = service.BookOptions();
            var authors = service.GetAuthors();
            ViewBag.Authors = authors;
            ViewData["Books"] = bookModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAuthors(AddAuthorsCreate model)
        {
            var service = CreateAuthorBookService();

            service.AddAuthor(model);

            return RedirectToAction("Index", "Book");
        }

        public ActionResult RemoveBooks(int id)
        {
            var service = CreateAuthorBookService();
            var authorModel = service.AuthorOptions(id);
            var books = service.GetBooks();
            ViewBag.Books = books;
            ViewData["Authors"] = authorModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveBooks(AddBooksCreate model)
        {
            var service = CreateAuthorBookService();

            service.RemoveBook(model);

            return RedirectToAction("Index", "Author");
        }

        public ActionResult RemoveAuthors()
        {
            var service = CreateAuthorBookService();
            var bookModel = service.BookOptions();
            var authors = service.GetAuthors();
            ViewBag.Authors = authors;
            ViewData["Books"] = bookModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveAuthors(AddAuthorsCreate model)
        {
            var service = CreateAuthorBookService();

            service.RemoveAuthor(model);

            return RedirectToAction("Index", "Book");
        }

        private AuthorBookService CreateAuthorBookService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AuthorBookService(userId);
            return service;
        }
    }
}