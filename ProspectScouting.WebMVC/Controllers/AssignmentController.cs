using Microsoft.AspNet.Identity;
using ProspectScouting.Data;
using ProspectScouting.Models.AssignmentModels;
using ProspectScouting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;

namespace ProspectScouting.WebMVC.Controllers
{
    [Authorize]
    [RoutePrefix("MVC/values")]
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new AssignmentService(userID);
            var model = service.GetAllAssignments();

            return View(model);
        }

        // CREATE

        // GET : Assignment/Create
        public ActionResult Create()
        {
            //Select School DDL
            var db = new SchoolService();
            ViewBag.SchoolID = new SelectList(db.GetAllSchools().ToList(), "SchoolID", "SchoolName");

            //Select Scout DDL
            var dbTwo = new ScoutService();
            ViewBag.ScoutID = new SelectList(dbTwo.GetAllScouts().ToList(), "ScoutID", "FullName");

            return View();
        }

        // POST : Assignment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssignmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAssignmentService();

            if (service.CreateAssignment(model))
            {
                TempData["SaveResult"] = "The assignment was added successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "There was an issue adding the assignment.");

            return View(model);
        }

        // READ

        // GET : Assignment/Details/{id}
        [Route("id")]
        public ActionResult Details(int id)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentByID(id);

            return View(model);
        }

        // GET : Assignment/Details/{school}
        [Route("school")]
        public ActionResult Details(string schoolName)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentBySchool(schoolName);

            return View(model);
        }

        // GET : Assignment/Details/{scout}
        [Route("scout")]
        public ActionResult DetailsByScout(string scoutLastName)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentByScout(scoutLastName);

            return View(model);
        }

        // GET : Assignment/Details/{active}
        [Route("active")]
        public ActionResult DetailsActiveAssignments(bool completed)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetActiveAssignments(false);

            return View(model);
        }

        // GET : Assignment/Details/{completed}
        [Route("completed")]
        public ActionResult DetailsCompletedAssignments(bool completed)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetCompletedAssignments(true);

            return View(model);
        }

        // UPDATE

        // GET : Assignment/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateAssignmentService();
            var detail = service.GetAssignmentByID(id);
            var model =
                new AssignmentEdit
                {
                    AssignmentID = detail.AssignmentID,
                    AssignmentRequest = detail.AssignmentRequest,
                    SchoolID = detail.SchoolID,
                    ScoutID = detail.ScoutID,
                    Completed = detail.Completed
                };

            return View(model);
        }

        // POST : Assignment/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssignmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AssignmentID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateAssignmentService();

            if (service.UpdateAssignment(model))
            {
                TempData["SaveResult"] = "The assignment was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The assignment could not be updated.");
            return View(model);
        }

        // DELETE

        // GET : Assignment/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateAssignmentService();
            var model = svc.GetAssignmentByID(id);

            return View(model);
        }

        // POST : Assignment/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAssignment(int id)
        {
            var service = CreateAssignmentService();

            service.DeleteAssignment(id);

            TempData["SaveResult"] = "The assignment was successfully removed.";

            return RedirectToAction("Index");
        }

        // CREATE ASSIGNMENT SERVICE
        private AssignmentService CreateAssignmentService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new AssignmentService(userID);
            return service;
        }
    }
}