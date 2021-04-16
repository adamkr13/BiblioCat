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
    public class SeriesAuthorController : Controller
    {
        [Authorize]
        // GET: SeriesAuthor
        public ActionResult Index()
        {
            var service = CreateSeriesAuthorService();
            var model = service.GetSeriesAuthors();
            return View(model);
        }

        public ActionResult Create()
        {
            var service = CreateSeriesAuthorService();
            var seriesModel = service.SeriesOptions();
            var authorModel = service.AuthorOptions();
            ViewData["Series"] = seriesModel;
            ViewData["Authors"] = authorModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeriesAuthorCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSeriesAuthorService();

            if (service.CreateSeriesAuthor(model))
            {
                var series = service.GetSeriesAuthorById(model.SeriesId, model.AuthorId);
                TempData["SaveResult"] = $"The {series.SeriesName} was added to author {series.FirstName} {series.LastName}";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The series could not be added to the author.");

            return View(model);
        }

        public ActionResult Delete(int seriesId, int authorId)
        {
            var service = CreateSeriesAuthorService();
            var model = service.GetSeriesAuthorById(seriesId, authorId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int seriesId, int authorId)
        {
            var service = CreateSeriesAuthorService();
            service.DeleteSeriesAuthor(seriesId, authorId);

            return RedirectToAction("Index");
        }


        private SeriesAuthorService CreateSeriesAuthorService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SeriesAuthorService(userId);
            return service;
        }
    }
}