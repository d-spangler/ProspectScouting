using Microsoft.AspNet.Identity;
using ProspectScouting.Data;
using ProspectScouting.Models.SchoolModels;
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
    public class SchoolController : Controller
    {
        // GET : School
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new SchoolService(userID);
            var model = service.GetAllSchools();

            return View(model);
        }

        // CREATE

        // GET : School/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST : School/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSchoolService();

            if (service.CreateSchool(model))
            {
                TempData["SaveResult"] = "The school was added successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "There was an issue adding the school.");

            return View(model);
        }

        // READ

        // GET : School/Details/{id}
        [Route("id")]
        public ActionResult Details(int id)
        {
            var svc = CreateSchoolService();
            var model = svc.GetSchoolByID(id);

            return View(model);
        }

        // GET : School/Details/{schoolname}
        [Route("schoolname")]
        public ActionResult Details(string schoolName)
        {
            var svc = CreateSchoolService();
            var model = svc.GetSchoolByName(schoolName);

            return View(model);
        }

        // GET : School/Details/{state}
        [Route("state")]
        public ActionResult DetailsByState(string state)
        {
            var svc = CreateSchoolService();
            var model = svc.GetSchoolByState(state);

            return View(model);
        }

        // UPDATE

        // GET : School/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateSchoolService();
            var detail = service.GetSchoolByID(id);
            var model =
                new SchoolEdit
                {
                    SchoolID = detail.SchoolID,
                    SchoolName = detail.SchoolName,
                    City = detail.City,
                    State = detail.State
                };

            return View(model);
        }

        // POST : School/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SchoolEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SchoolID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateSchoolService();

            if (service.UpdateSchool(model))
            {
                TempData["SaveResult"] = "The school was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The school could not be updated.");
            return View(model);
        }

        // DELETE

        // GET : School/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateSchoolService();
            var model = svc.GetSchoolByID(id);

            return View(model);
        }

        // POST : School/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSchool(int id)
        {
            var service = CreateSchoolService();

            service.DeleteSchool(id);

            TempData["SaveResult"] = "The school was successfully removed.";

            return RedirectToAction("Index");
        }

        // CREATE SCHOOL SERVICE
        private SchoolService CreateSchoolService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new SchoolService(userID);
            return service;
        }
    }
}