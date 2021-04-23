using BiblioCat.Models.Series;
using BiblioCat.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiblioCat.WebMVC.Controllers
{
    [Authorize]
    public class SeriesController : Controller
    {
        // GET: Series
        public ActionResult Index()
        {
            var service = CreateSeriesService();
            var model = service.GetSeries();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeriesCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSeriesService();

            if (service.CreateSeries(model))
            {
                TempData["SaveResult"] = "The series was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The series could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateSeriesService();
            var model = service.GetSeriesById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSeriesService();
            var detail = service.GetSeriesById(id);

            var model = new SeriesEdit
            {
                SeriesId = detail.SeriesId,
                SeriesName = detail.SeriesName,
                SeriesDescription = detail.SeriesDescription
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SeriesEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.SeriesId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSeriesService();

            if (service.UpdateSeries(model))
            {
                TempData["SaveResult"] = "The series was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The series could not be updated.");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateSeriesService();
            var model = service.GetSeriesById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSeriesService();
            service.DeleteSeries(id);

            TempData["SaveResult"] = "The series was deleted.";

            return RedirectToAction("Index");
        }

        private SeriesService CreateSeriesService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SeriesService(userId);

            return service;
        }
    }
}