using BiblioCat.Models.Convention;
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
    public class ConventionController : Controller
    {
        // GET: Convention
        public ActionResult Index()
        {
            var service = CreateConventionService();
            var model = service.GetConventions();
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new ConventionCreate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConventionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateConventionService();

            if (service.CreateConvention(model))
            {
                TempData["SaveResult"] = "The convention was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The convention could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateConventionService();
            var model = service.GetConventionById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateConventionService();
            var detail = service.GetConventionById(id);

            var model = new ConventionEdit
            {
                ConventionId = detail.ConventionId,
                Name = detail.Name,
                City = detail.City,
                State = detail.State,
                StartDate = detail.StartDate,
                EndDate = detail.EndDate,
                Hotel = detail.Hotel
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConventionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ConventionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateConventionService();

            if (service.UpdateConvention(model))
            {
                TempData["SaveResult"] = "The convention was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The convention could not be updated.");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateConventionService();
            var model = service.GetConventionById(id);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = CreateConventionService();
            service.DeleteConvention(id);

            TempData["SaveResult"] = "The convention was deleted.";

            return RedirectToAction("Index");
        }




        private ConventionService CreateConventionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ConventionService(userId);

            return service;
        }
    }
}