using BiblioCat.Models.Author;
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
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            var service = CreateAuthorService();
            var model = service.GetAuthors();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAuthorService();

            if (service.CreateAuthor(model))
            {
                TempData["SaveResult"] = "The author was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Author could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateAuthorService();
            var model = service.GetAuthorById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAuthorService();
            var detail = service.GetAuthorById(id);

            var model =
                new AuthorEdit
                {
                    AuthorId = detail.AuthorId,
                    LastName = detail.LastName,
                    FirstName = detail.FirstName,
                    Patreon = detail.Patreon,
                    OfficialWebsite = detail.OfficialWebsite,
                    AmazonPage = detail.AmazonPage,
                    GoodreadsPage = detail.GoodreadsPage,
                    TwitterHandle = detail.TwitterHandle
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AuthorId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAuthorService();

            if(service.UpdateAuthor(model))
            {
                TempData["SaveResult"] = "The author was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The author could not be updated.");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateAuthorService();
            var model = service.GetAuthorById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAuthorService();
            service.DeleteAuthor(id);

            TempData["SaveResult"] = "The author was deleted.";

            return RedirectToAction("Index");
        }

        private AuthorService CreateAuthorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AuthorService(userId);
            return service;
        }
    }
}