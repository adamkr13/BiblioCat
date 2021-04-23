using BiblioCat.Models.TableJunctions.SeriesAuthor;
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
    public class SeriesAuthorController : Controller
    {
        public ActionResult AddAuthors()
        {
            var service = CreateSeriesAuthorService();
            var authors = service.GetAuthors();
            var seriesModel = service.SeriesOptions();
            ViewBag.Authors = authors;
            ViewData["Series"] = seriesModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAuthors(AddAuthorsCreate model)
        {
            var service = CreateSeriesAuthorService();

            service.AddAuthor(model);

            return RedirectToAction("Index", "Series");
        }

        public ActionResult AddSeries()
        {
            var service = CreateSeriesAuthorService();
            var authorModel = service.AuthorOptions();
            var series = service.GetSeries();
            ViewBag.Series = series;
            ViewData["Authors"] = authorModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSeries(AddSeriesCreate model)
        {
            var service = CreateSeriesAuthorService();

            service.AddSeries(model);

            return RedirectToAction("Index", "Author");
        }

        public ActionResult RemoveAuthors()
        {
            var service = CreateSeriesAuthorService();
            var authors = service.GetAuthors();
            var seriesModel = service.SeriesOptions();
            ViewBag.Authors = authors;
            ViewData["Series"] = seriesModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveAuthors(AddAuthorsCreate model)
        {
            var service = CreateSeriesAuthorService();

            service.RemoveAuthor(model);

            return RedirectToAction("Index", "Series");
        }

        public ActionResult RemoveSeries()
        {
            var service = CreateSeriesAuthorService();
            var authorModel = service.AuthorOptions();
            var series = service.GetSeries();
            ViewBag.Series = series;
            ViewData["Authors"] = authorModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveSeries(AddSeriesCreate model)
        {
            var service = CreateSeriesAuthorService();

            service.RemoveSeries(model);

            return RedirectToAction("Index", "Author");
        }

        private SeriesAuthorService CreateSeriesAuthorService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SeriesAuthorService(userId);
            return service;
        }
    }
}