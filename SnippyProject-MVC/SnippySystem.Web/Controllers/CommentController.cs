using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnippySystem.Models.BindingModels;
using SnippySystem.Models.ViewModels.Comments;
using SnippySystem.Services;
using Vereyon.Web;

namespace SnippySystem.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private CommentService service;

        public CommentController()
        {
            this.service = new CommentService();
        }

        //Get
        [HttpGet]
        [Authorize]
        public ActionResult AddComment(int id)
        {
            AddCommentViewModel model = this.service.GetAddComment(id);
            return PartialView("_AddComment", model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(AddCommentBindingModel model)
        {
            if (ModelState.IsValid)
            {

                this.service.AddComment(model);

            }

            return RedirectToAction("Details", "Snippet", new { id = model.SnippetId });
        }

        [HttpGet]
        public ActionResult DeleteComment(int id)
        {
            DeleteCommentViewModel model = this.service.GetDeleteVm(id);
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteComment(DeleteCommentBindingModel model)
        {
            if (ModelState.IsValid)
            {
                //FlashMessage.Confirmation("Are you shore you wont to delete this comment?");
                this.service.DeleteComment(model.Id);
                return RedirectToAction("Details", "Snippet", new {id = model.SnippetId});
            }

            return RedirectToAction("DeleteComment", new {id = model.Id});
        }

    }
}