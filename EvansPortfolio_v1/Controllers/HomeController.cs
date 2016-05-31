using EvansPortfolio_v1.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvansPortfolio_v1.Controllers
{
    public class HomeController : Controller
    {
        private PortfolioDBEntities db = new PortfolioDBEntities();

        public ActionResult Index()
        {
            db.Features.ToList();
            //return View();
            return View(db.Projects.ToList());

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}