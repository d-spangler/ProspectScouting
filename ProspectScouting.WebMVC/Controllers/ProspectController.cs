using ProspectScouting.Models.ProspectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProspectScouting.WebMVC.Controllers
{
    [Authorize]
    public class ProspectController : Controller
    {
        // GET: Prospect
        public ActionResult Index()
        {
            var model = new ProspectListItem[0];
            return View();
        }

        // CREATE

        // READ

        // UPDATE

        // DELETE

        
    }
}