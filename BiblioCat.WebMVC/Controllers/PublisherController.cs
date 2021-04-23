using BiblioCat.Models.Publisher;
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
    public class PublisherController : Controller
    {
        // GET: Publisher
        public ActionResult Index()
        {
            var service = CreatePublisherService();
            var model = service.GetPublishers();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublisherCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePublisherService();

            if (service.CreatePublisher(model))
            {
                TempData["SaveResult"] = "The publisher was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The publisher could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreatePublisherService();
            var model = service.GetPublisherById(id);

            return View(model);
        }

        public ActionResult Edit(int id, PublisherEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PublisherId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePublisherService();
            
            if (service.UpdatePublisher(model))
            {
                TempData["SaveResult"] = "The publisher was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The publisher could not be updated.");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreatePublisherService();
            var model = service.GetPublisherById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePublisherService();
            service.DeletePublisher(id);

            TempData["SaveResult"] = "The publisher was deleted.";

            return RedirectToAction("Index");
        }




        private PublisherService CreatePublisherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PublisherService(userId);

            return service;
        }
    }
}