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
    public class ConventionController : Controller
    {
        [Authorize]
        // GET: Convention
        public ActionResult Index()
        {
            var service = CreateConventionService();
            var model = service.GetConventions();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConventionCreate model)
        {

        }






        private ConventionService CreateConventionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ConventionService(userId);

            return service;
        }
    }
}