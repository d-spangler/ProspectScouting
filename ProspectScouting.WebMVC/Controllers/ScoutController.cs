using Microsoft.AspNet.Identity;
using ProspectScouting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProspectScouting.WebMVC.Controllers
{
    [Authorize]
    [RoutePrefix("MVC/values")]
    public class ScoutController : Controller
    {
        // GET : Scout
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ScoutService(userID);
            var model = service.GetAllScouts();

            return View(model);
        }

        // CREATE

        // GET : Scout/Create

        // READ

        // UPDATE

        // DELETE

        // CREATE SCOUT SERVICE
        private ScoutService CreateScoutService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ScoutService(userID);
            return service;
        }
    }
}