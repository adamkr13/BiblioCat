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
        public ActionResult AddAuthors()
        {
            var service = CreateAuthorPublisherService();
            var authors = service.GetAuthors();
            var publisherModel = service.PublisherOptions();
            ViewBag.Authors = authors;
            ViewData["Publishers"] = publisherModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAuthors(AddAuthorsCreate model)
        {
            var service = CreateAuthorPublisherService();

            service.AddAuthor(model);

            return RedirectToAction("Index", "Publisher");
        }

        public ActionResult AddPublishers()
        {
            var service = CreateAuthorPublisherService();
            var authorModel = service.AuthorOptions();
            var publishers = service.GetPublishers();
            ViewBag.Publishers = publishers;
            ViewData["Authors"] = authorModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPublishers(AddPublishersCreate model)
        {
            var service = CreateAuthorPublisherService();

            service.AddPublisher(model);

            return RedirectToAction("Details", "Author", new { id = model.AuthorId });
        }

        public ActionResult RemoveAuthors()
        {
            var service = CreateAuthorPublisherService();
            var authors = service.GetAuthors();
            var publisherModel = service.PublisherOptions();
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

        public ActionResult RemovePublishers()
        {
            var service = CreateAuthorPublisherService();
            var authorModel = service.AuthorOptions();
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