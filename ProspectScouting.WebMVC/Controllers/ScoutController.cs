using Microsoft.AspNet.Identity;
using ProspectScouting.Models.ScoutModels;
using ProspectScouting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST : Scout/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScoutCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateScoutService();

            if (service.CreateScout(model))
            {
                TempData["SaveResult"] = "The scout was added successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "There was an issue adding the scout.");

            return View(model);
        }

        // READ

        // GET : Scout/Details/{id}
        [Route("id")]
        public ActionResult Details(int id)
        {
            var svc = CreateScoutService();
            var model = svc.GetScoutByID(id);

            return View(model);
        }

        //// GET : Scout/Details/{lastname}
        //[Route("lastname")]
        //public ActionResult Details(string lastName)
        //{
        //    var svc = CreateScoutService();
        //    var model = svc.GetScoutByName(lastName);

        //    return View(model);
        //}

        // UPDATE

        // GET : Scout/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateScoutService();
            var detail = service.GetScoutByID(id);
            var model =
                new ScoutEdit
                {
                    ScoutID = detail.ScoutID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName
                };

            return View(model);
        }

        // POST : Scout/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ScoutEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ScoutID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateScoutService();

            if (service.UpdateScout(model))
            {
                TempData["SaveResult"] = "The scout was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The scout could not be updated.");
            return View(model);
        }

        // DELETE

        // GET : Scout/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateScoutService();
            var model = svc.GetScoutByID(id);

            return View(model);
        }

        // POST : Scout/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteScout(int id)
        {
            var service = CreateScoutService();

            service.DeleteScout(id);

            TempData["SaveResult"] = "The scout was successfully removed.";

            return RedirectToAction("Index");
        }

        // CREATE SCOUT SERVICE
        private ScoutService CreateScoutService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ScoutService(userID);
            return service;
        }
    }
}