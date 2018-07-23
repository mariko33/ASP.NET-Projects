using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;
using PagedList;
using SnippySystem.Models.ViewModels.Home;
using SnippySystem.Services;

namespace SnippySystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;
        public HomeController()
        {
            service = new HomeService();
        }


        public ActionResult Index()
        {
            HomeIndexViewModel model = this.service.GetIndexViewModel();
            return View(model);
        }

        public ActionResult AllSnippets(int page=1,int pageSize=3)
        {
            ICollection<SnippetViewModel> model = this.service.GetAllSnippets();
            PagedList<SnippetViewModel>models=new PagedList<SnippetViewModel>(model,page,pageSize);
            return PartialView("_AllSnippets",models);
        }

        
    }
}