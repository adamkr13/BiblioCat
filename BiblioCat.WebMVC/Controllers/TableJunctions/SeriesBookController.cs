using BiblioCat.Services.TableJunctions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiblioCat.WebMVC.Controllers.TableJunctions
{
    public class SeriesBookController : Controller
    {
        [Authorize]
        // GET: SeriesBook
        public ActionResult Index()
        {
            var service = CreateSeriesBookService();
            var model = service.GetSeriesBooks();
            return View(model);
        }

        public ActionResult Create()
        {
            var service = CreateSeriesBookService();
            var seriesModel = service.SeriesOptions();
            var bookModel = service.BookOptions();
            ViewData["Series"] = seriesModel;
            ViewData["Books"] = bookModel;

            return View();
        }




        private SeriesBookService CreateSeriesBookService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SeriesBookService(userId);
            return service;
        }

    }
}