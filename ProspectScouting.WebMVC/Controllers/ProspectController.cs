using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProspectScouting.WebMVC.Controllers
{
    public class ProspectController : Controller
    {
        // GET: Prospect
        public ActionResult Index()
        {
            return View();
        }
    }
}