using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnippySystem.Models.ViewModels.Home;
using SnippySystem.Services;

namespace SnippySystem.Web.Controllers
{
    public class SnippetController : Controller
    {
        private SnippetServices services;

        public SnippetController()
        {
            this.services=new SnippetServices();
        }

        // GET: Snippet
        [HttpGet]
        [Route("Snippet/Details")]
        public ActionResult Details(int id)
        {
            SnippetViewModel model = this.services.GetSnippetDetails(id);
            return View(model);
        }
    }
}