using BiblioCat.Models.TableJunctions.AuthorPublisher;
using BiblioCat.Services.TableJunctions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiblioCat.WebMVC.Controllers.TableJunctions
{
    public class AuthorPublisherController : Controller
    {
        [Authorize]
        // GET: AuthorPublisher
        public ActionResult Index()
        {
            var service = CreateAuthorPublisherService();
            var model = service.GetAuthorPublishers();

            return View(model);
        }

        public ActionResult Create()
        {
            var service = CreateAuthorPublisherService();
            var authorModel = service.AuthorOptions();
            var publisherModel = service.PublisherOptions();
            ViewData["Authors"] = authorModel;
            ViewData["Publishers"] = publisherModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorPublisherCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAuthorPublisherService();

            if (service.CreateAuthorPublisher(model))
            {
                var ap = service.GetAuthorPublisherById(model.AuthorId, model.PublisherId);
                TempData["SaveResult"] = $"Author {ap.FirstName} {ap.LastName} was added to publisher {ap.PublisherName}";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The author could not be added to the publisher.");

            return View(model);
        }

        public ActionResult Delete(int authorId, int publisherId)
        {
            var service = CreateAuthorPublisherService();
            var model = service.GetAuthorPublisherById(authorId, publisherId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int authorId, int publisherId)
        {
            var service = CreateAuthorPublisherService();
            service.DeleteAuthorPublisher(authorId, publisherId);

            return RedirectToAction("Index");
        }



        private AuthorPublisherService CreateAuthorPublisherService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AuthorPublisherService(userId);

            return service;
        }
    }
}