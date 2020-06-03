using Microsoft.AspNet.Identity;
using ProspectScouting.Data;
using ProspectScouting.Models;
using ProspectScouting.Models.ProspectModels;
using ProspectScouting.Models.SchoolModels;
using ProspectScouting.Services;
using ProspectScouting.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ProspectScouting.WebMVC.Controllers
{
    [Authorize]
    [RoutePrefix("MVC/values")]
    public class ProspectController : Controller
    {
        // GET : Prospect
        public ActionResult Index(string sortingOrder)
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ProspectService(userID);
            //var model = service.GetAllProspects().OrderBy(m => m.LastName);

            ViewBag.SortingFirstName = string.IsNullOrEmpty(sortingOrder) ? "FirstName" : "";
            ViewBag.SortingLastName = string.IsNullOrEmpty(sortingOrder) ? "LastName" : "";
            ViewBag.SortingPosition = string.IsNullOrEmpty(sortingOrder) ? "Position" : "";
            ViewBag.SortingSchoolName = string.IsNullOrEmpty(sortingOrder) ? "SchoolName" : "";
            ViewBag.SortingGrade = string.IsNullOrEmpty(sortingOrder) ? "Grade" : "";

            var prospects = from prospect in service.GetAllProspects() select prospect;
            switch (sortingOrder)
            {
                case "FirstName":
                    prospects = prospects.OrderBy(prospect => prospect.FirstName);
                    break;
                case "LastName":
                    prospects = prospects.OrderBy(prospect => prospect.LastName);
                    break;
                case "Position":
                    prospects = prospects.OrderBy(prospect => prospect.Position);
                    break;
                case "SchoolName":
                    prospects = prospects.OrderBy(prospect => prospect.School.SchoolName);
                    break;
                case "Grade":
                    prospects = prospects.OrderBy(prospect => prospect.Grade);
                    break;
            }

            return View(prospects.ToList());

            //return View(model);
        }

        // CREATE

        // GET : Prospect/Create
        public ActionResult Create()
        {
            var db = new SchoolService();
            //List<School> schoolList = schools
            ViewBag.SchoolID = new SelectList(db.GetAllSchools().OrderBy(e=>e.SchoolName), "SchoolID", "SchoolName");
            
            return View();

        }

        // POST : Prospect/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProspectCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProspectService();

            if (service.CreateProspect(model))
            {
                TempData["SaveResult"] = "The prospect was added successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "There was an issue adding the prospect.");

            return View(model);
        }

        // READ

        // GET : Prospect/Details/{id}
        [Route("id")]
        public ActionResult Details(int id)
        {
            var svc = CreateProspectService();
            var model = svc.GetProspectByID(id);

            return View(model);
        }

        // GET : BIG BOARD
        [Route("bigboard")]
        public ActionResult BigBoard()
        {
            var svc = CreateProspectService();
            var model = svc.GetProspectByBigBoard();

            return View(model);
        }

        //// GET : Prospect/Details/{lastname}
        //[Route("lastname")]
        //public ActionResult Details(string lastName)
        //{
        //    var svc = CreateProspectService();
        //    var model = svc.GetProspectByName(lastName);

        //    return View(model);
        //}

        //// GET : Prospect/Details/{position}
        //[Route("position")]
        //public ActionResult DetailsByPosition(string position)
        //{
        //    var svc = CreateProspectService();
        //    var model = svc.GetProspectByPosition(position);

        //    return View(model);
        //}

        //// GET : Prospect/Details/{school}
        //[Route("school")]
        //public ActionResult DetailsBySchool(string school)
        //{
        //    var svc = CreateProspectService();
        //    var model = svc.GetProspectsBySchool(school);

        //    return View(model);
        //}



        // UPDATE

        // GET : Prospect/Edit/{id}
        public ActionResult Edit(int id)
        {
            var db = new SchoolService();
            ViewBag.SchoolID = new SelectList(db.GetAllSchools().OrderBy(e => e.SchoolName), "SchoolID", "SchoolName");

            var service = CreateProspectService();
            var detail = service.GetProspectByID(id);
            var model =
                new ProspectEdit
                {
                    ProspectID = detail.ProspectID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Position = detail.Position,
                    School = detail.School,
                    Report = detail.Report,
                    Grade = detail.Grade,
                    BigBoard = detail.BigBoard
                };

            return View(model);
        }

        // POST : Prospect/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProspectEdit model)
        {
            //var db = new SchoolService();
            //ViewBag.SchoolID = new SelectList(db.GetAllSchools().ToList(), "SchoolID", "SchoolName");

            if (!ModelState.IsValid) return View(model);

            if (model.ProspectID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateProspectService();

            if (service.UpdateProspect(model))
            {
                TempData["SaveResult"] = "The prospect was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The prospect could not be updated.");
            return View(model);
        }

        // DELETE

        // GET : Prospect/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateProspectService();
            var model = svc.GetProspectByID(id);

            return View(model);
        }

        // POST : Prospect/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProspect(int id)
        {
            var service = CreateProspectService();

            service.DeleteProspect(id);

            TempData["SaveResult"] = "The prospect was successfully removed.";

            return RedirectToAction("Index");
        }

        // CREATE PROSPECT SERVICE
        private ProspectService CreateProspectService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ProspectService(userID);
            return service;
        }
    }
}