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
    public class AuthorBookController : Controller
    {
        [Authorize]
        // GET: AuthorBook
        public ActionResult Index()
        {
            var service = CreateAuthorBookService();
            var model = service.GetAuthorBooks();

            return View(model);
        }

        //public ActionResult Create()
        //{
        //    var service = CreateAuthorBookService();
        //    var bookModel = service.BookOptions();
        //    var authorModel = service.AuthorOptions();
        //    ViewData["Books"] = bookModel;
        //    ViewData["Authors"] = authorModel;

        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(AuthorBookCreate model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var service = CreateAuthorBookService();            

        //    if (service.CreateAuthorBook(model))
        //    {                
        //        var book = service.GetAuthorBookById(model.AuthorId, model.BookId);
        //        TempData["SaveResult"] = $"Author {book.FirstName} {book.LastName} was added to book {book.Title}";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "The author could not be added to the book.");

        //    return View(model);
        //}

        public ActionResult AddBooks()
        {
            var service = CreateAuthorBookService();
            var authorModel = service.AuthorOptions();
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

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }

        public ActionResult RemoveBooks()
        {
            var service = CreateAuthorBookService();
            var authorModel = service.AuthorOptions();
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

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int authorId, int bookId)
        {
            var service = CreateAuthorBookService();
            var model = service.GetAuthorBookById(authorId, bookId);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int authorId, int bookId)
        {
            var service = CreateAuthorBookService();
            service.DeleteAuthorBook(authorId, bookId);

            return RedirectToAction("Index");
        }

        private AuthorBookService CreateAuthorBookService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AuthorBookService(userId);
            return service;
        }
    }
}