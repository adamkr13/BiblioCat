using BiblioCat.Models.TableJunctions.SeriesBook;
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
    public class SeriesBookController : Controller
    {
        public ActionResult AddBooks(int id)
        {
            var service = CreateSeriesBookService();
            var books = service.GetBooks();
            var seriesModel = service.SeriesOptions(id);
            ViewBag.Books = books;
            ViewData["Series"] = seriesModel;

            return View(new AddBooksCreate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBooks(AddBooksCreate model)
        {
            var service = CreateSeriesBookService();

            service.AddBook(model);

            return RedirectToAction("Index", "Series");
        }

        public ActionResult AddSeries(int id)
        {
            var service = CreateSeriesBookService();
            var bookModel = service.BookOptions(id);
            var series = service.GetSeries();
            ViewBag.Series = series;
            ViewData["Books"] = bookModel;

            return View(new AddSeriesCreate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSeries(AddSeriesCreate model)
        {
            var service = CreateSeriesBookService();

            service.AddSeries(model);

            return RedirectToAction("Index", "Book");
        }

        public ActionResult RemoveBooks(int id)
        {
            var service = CreateSeriesBookService();
            var books = service.GetBooks();
            var seriesModel = service.SeriesOptions(id);
            ViewBag.Books = books;
            ViewData["Series"] = seriesModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveBooks(AddBooksCreate model)
        {
            var service = CreateSeriesBookService();

            service.RemoveBook(model);

            return RedirectToAction("Index", "Series");
        }

        public ActionResult RemoveSeries(int id)
        {
            var service = CreateSeriesBookService();
            var bookModel = service.BookOptions(id);
            var series = service.GetSeries();
            ViewBag.Series = series;
            ViewData["Books"] = bookModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveSeries(AddSeriesCreate model)
        {
            var service = CreateSeriesBookService();

            service.RemoveSeries(model);

            return RedirectToAction("Index", "Book");
        }        

        private SeriesBookService CreateSeriesBookService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SeriesBookService(userId);
            return service;
        }
    }
}