using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SnippySystem.Data;
using SnippySystem.Models.BindingModels;
using SnippySystem.Models.EntityModels;
using SnippySystem.Models.ViewModels.Labels;
using SnippySystem.Services;

namespace SnippySystem.Web.Controllers
{
    public class LabelsController : Controller
    {
        private SnippySystemContext db = new SnippySystemContext();

        private LabelsServece service;

        public LabelsController()
        {
            this.service=new LabelsServece();
        }

    // GET: Labels
        public ActionResult Index()
        {
            IEnumerable<LabelViewModel> model = this.service.GetLabelsList();
            return View(model);
        }

        // GET: Labels/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabelViewModel label = this.service.FindLabelById(id);
            if (label == null)
            {
                return HttpNotFound();
            }
            return View(label);
        }

        // GET: Labels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Labels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Text")] AddLabelBindingModel label)
        {
            if (ModelState.IsValid)
            {
                this.service.AddLabel(label);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Labels/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabelViewModel label = this.service.FindLabelById(id);
            if (label == null)
            {
                return HttpNotFound();
            }
            return View(label);
        }

        // POST: Labels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text")] EditLabelBindingModel label)
        {
            if (ModelState.IsValid)
            {
                this.service.EditLabel(label);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Labels/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LabelViewModel label = this.service.FindLabelById(id);
            if (label == null)
            {
                return HttpNotFound();
            }

            return View(label);
        }

        // POST: Labels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeleteLabe(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
