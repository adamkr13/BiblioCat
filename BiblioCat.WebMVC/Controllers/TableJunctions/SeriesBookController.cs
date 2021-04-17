﻿using BiblioCat.Models.TableJunctions.SeriesBook;
using BiblioCat.Services.TableJunctions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiblioCat.WebMVC.Controllers.TableJunctions
{
    public class SeriesBookController : Controller
    {
        [Authorize]
        // GET: SeriesBook
        public ActionResult Index()
        {
            var service = CreateSeriesBookService();
            var model = service.GetSeriesBooks();
            return View(model);
        }

        public ActionResult Create()
        {
            var service = CreateSeriesBookService();
            var seriesModel = service.SeriesOptions();
            var bookModel = service.BookOptions();
            ViewData["Series"] = seriesModel;
            ViewData["Books"] = bookModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeriesBookCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSeriesBookService();

            if (service.CreateSeriesBook(model))
            {
                var series = service.GetSeriesBookById(model.SeriesId, model.BookId);
                TempData["SaveResult"] = $"The book {series.Title} was added to {series.SeriesName}";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The book could not be added to the series.");

            return View(model);
        }

        public ActionResult Delete(int seriesId, int bookId)
        {
            var service = CreateSeriesBookService();
            var model = service.GetSeriesBookById(seriesId, bookId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int seriesId, int bookId)
        {
            var service = CreateSeriesBookService();
            service.DeleteSeriesBook(seriesId, bookId);

            return RedirectToAction("Index");
        }

        private SeriesBookService CreateSeriesBookService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SeriesBookService(userId);
            return service;
        }
    }
}