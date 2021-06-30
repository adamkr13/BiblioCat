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
    [Authorize]
    public class AuthorPublisherController : Controller
    {
        public ActionResult AddAuthors(int id)
        {
            var service = CreateAuthorPublisherService();
            var authors = service.GetAuthors();
            var publisherModel = service.PublisherOptions(id);
            ViewBag.Authors = authors;
            ViewData["Publishers"] = publisherModel;

            return View(new AddAuthorsCreate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAuthors(AddAuthorsCreate model)
        {
            var service = CreateAuthorPublisherService();

            service.AddAuthor(model);

            return RedirectToAction("Index", "Publisher");
        }

        public ActionResult AddPublishers(int id)
        {
            var service = CreateAuthorPublisherService();
            var authorModel = service.AuthorOptions(id);
            var publishers = service.GetPublishers();
            ViewBag.Publishers = publishers;
            ViewData["Authors"] = authorModel;

            return View(new AddPublishersCreate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPublishers(AddPublishersCreate model)
        {
            var service = CreateAuthorPublisherService();

            service.AddPublisher(model);

            return RedirectToAction("Details", "Author", new { id = model.AuthorId });
        }

        public ActionResult RemoveAuthors(int id)
        {
            var service = CreateAuthorPublisherService();
            var authors = service.GetAuthors();
            var publisherModel = service.PublisherOptions(id);
            ViewBag.Authors = authors;
            ViewData["Publishers"] = publisherModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveAuthors(AddAuthorsCreate model)
        {
            var service = CreateAuthorPublisherService();

            service.RemoveAuthor(model);

            return RedirectToAction("Index", "Publisher");
        }

        public ActionResult RemovePublishers(int id)
        {
            var service = CreateAuthorPublisherService();
            var authorModel = service.AuthorOptions(id);
            var publishers = service.GetPublishers();
            ViewBag.Publishers = publishers;
            ViewData["Authors"] = authorModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemovePublishers(AddPublishersCreate model)
        {
            var service = CreateAuthorPublisherService();

            service.RemovePublisher(model);

            return RedirectToAction("Details", "Author", new { id = model.AuthorId });
        }

        private AuthorPublisherService CreateAuthorPublisherService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AuthorPublisherService(userId);

            return service;
        }
    }
}