using BiblioCat.Models.TableJunctions.AuthorConvention;
using BiblioCat.Services.TableJunctions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiblioCat.WebMVC.Controllers.TableJunctions
{
    public class AuthorConventionController : Controller
    {
        [Authorize]
        // GET: AuthorConvention
        public ActionResult Index()
        {
            var service = CreateAuthorConventionService();
            var model = service.GetAuthorConventions();
            return View(model);
        }

        public ActionResult AddAuthors()
        {
            var service = CreateAuthorConventionService();
            var authors = service.GetAuthors();
            var conventionModel = service.ConventionOptions();
            ViewBag.Authors = authors;
            ViewData["Conventions"] = conventionModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAuthors(AddAuthorsCreate model)
        {
            var service = CreateAuthorConventionService();

            service.AddAuthor(model);

            return RedirectToAction("Index", "Convention");
        }

        public ActionResult AddConventions()
        {
            var service = CreateAuthorConventionService();
            var authorModel = service.AuthorOptions();
            var conventions = service.GetConventions();
            ViewBag.Conventions = conventions;
            ViewData["Authors"] = authorModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddConventions(AddConventionsCreate model)
        {
            var service = CreateAuthorConventionService();

            service.AddConvention(model);

            return RedirectToAction("Index", "Author");
        }

        public ActionResult RemoveAuthors()
        {
            var service = CreateAuthorConventionService();
            var authors = service.GetAuthors();
            var conventionModel = service.ConventionOptions();
            ViewBag.Authors = authors;
            ViewData["Conventions"] = conventionModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveAuthors(AddAuthorsCreate model)
        {
            var service = CreateAuthorConventionService();

            service.RemoveAuthor(model);

            return RedirectToAction("Index", "Convention");
        }

        public ActionResult RemoveConventions()
        {
            var service = CreateAuthorConventionService();
            var authorModel = service.AuthorOptions();
            var conventions = service.GetConventions();
            ViewBag.Conventions = conventions;
            ViewData["Authors"] = authorModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveConventions(AddConventionsCreate model)
        {
            var service = CreateAuthorConventionService();

            service.RemoveConvention(model);

            return RedirectToAction("Index", "Author");
        }

        //public ActionResult Create()
        //{
        //    var service = CreateAuthorConventionService();
        //    var authorModel = service.AuthorOptions();
        //    var conventionModel = service.ConventionOptions();
        //    ViewData["Authors"] = authorModel;
        //    ViewData["Conventions"] = conventionModel;

        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(AuthorConventionCreate model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var service = CreateAuthorConventionService();

        //    if (service.CreateAuthorConvention(model))
        //    {
        //        var authors = service.GetAuthorConventionById(model.AuthorId, model.ConventionId);
        //        TempData["SaveResult"] = $"The convention {authors.ConventionName}" +
        //            $" was added to author {authors.FirstName} {authors.LastName}";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "The convention could not be added to the author.");

        //    return View(model);
        //}

        //public ActionResult Delete(int authorId, int conventionId)
        //{
        //    var service = CreateAuthorConventionService();
        //    var model = service.GetAuthorConventionById(authorId, conventionId);
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("Delete")]
        //public ActionResult DeletePost(int authorId, int conventionId)
        //{
        //    var service = CreateAuthorConventionService();
        //    service.DeleteAuthorConvention(authorId, conventionId);

        //    return RedirectToAction("Index");
        //}

        private AuthorConventionService CreateAuthorConventionService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AuthorConventionService(userId);
            return service;
        }
    }
}