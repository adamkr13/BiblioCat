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
    [Authorize]
    public class AuthorConventionController : Controller
    {        
        public ActionResult AddAuthors(int id)
        {
            var service = CreateAuthorConventionService();
            var authors = service.GetAuthors();
            var conventionModel = service.ConventionOptions(id);
            ViewBag.Authors = authors;
            ViewData["Conventions"] = conventionModel;

            return View(new AddAuthorsCreate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAuthors(AddAuthorsCreate model)
        {
            var service = CreateAuthorConventionService();

            service.AddAuthor(model);

            return RedirectToAction("Index", "Convention");
        }

        public ActionResult AddConventions(int id)
        {
            var service = CreateAuthorConventionService();
            var authorModel = service.AuthorOptions(id);
            var conventions = service.GetConventions();
            ViewBag.Conventions = conventions;
            ViewData["Authors"] = authorModel;

            return View(new AddConventionsCreate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddConventions(AddConventionsCreate model)
        {
            var service = CreateAuthorConventionService();

            service.AddConvention(model);

            return RedirectToAction("Index", "Author");
        }

        public ActionResult RemoveAuthors(int id)
        {
            var service = CreateAuthorConventionService();
            var authors = service.GetAuthors();
            var conventionModel = service.ConventionOptions(id);
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

        public ActionResult RemoveConventions(int id)
        {
            var service = CreateAuthorConventionService();
            var authorModel = service.AuthorOptions(id);
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
        
        private AuthorConventionService CreateAuthorConventionService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AuthorConventionService(userId);
            return service;
        }
    }
}