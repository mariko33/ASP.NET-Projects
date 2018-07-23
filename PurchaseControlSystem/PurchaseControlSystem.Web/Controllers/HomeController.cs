using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using PurchaseControlSystem.Models.EntityModels;
using PurchaseControlSystem.Serveses.Contracts;
using PurchaseControlSystem.Web.Models.ViewModels;

namespace PurchaseControlSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeServises servise;

        public HomeController(IHomeServises servise)
        {
            this.servise = servise;
        }


        public ActionResult Index(string SortOrder, string Status, int page = 1, int pageSize = 10)
        {
            ViewBag.Sorted = SortOrder;
            ViewBag.SortId = String.IsNullOrEmpty(SortOrder) ? "desc" : "";
            ViewBag.SortDescription = SortOrder == "SortDescription" ? "desc" : "SortDescription";
            ViewBag.SortPrice = SortOrder == "SortPrice" ? "desc" : "SortPrice";
            ViewBag.SortQuantity = SortOrder == "SortQuantity" ? "desc" : "SortQuantity";



            ViewBag.Status = new List<string> { "Active", "Inactive" };
            ViewBag.SelectedStatus = Status;

            IEnumerable<PurchaseOrder> entityModel = this.servise.GetAllOrders(Status, SortOrder);
            IEnumerable<PurchaseOrderVm> models =
                Mapper.Map<IEnumerable<PurchaseOrder>, IEnumerable<PurchaseOrderVm>>(entityModel);
            PagedList<PurchaseOrderVm> model = new PagedList<PurchaseOrderVm>(models, page, pageSize);
            return View(model);
        }



        //Home/CreateOrder
        [HttpGet]
        public ActionResult CreateOrder()
        {
            ViewBag.CustomerId = new SelectList(this.servise.CustomersList(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder([Bind(Include = "Description,Price,Quantity,Status,CustomerId")]
            CreateOrderVm purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                PurchaseOrder order = Mapper.Map<CreateOrderVm, PurchaseOrder>(purchaseOrder);
                this.servise.CreateOrder(order);
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(this.servise.CustomersList(), "Id", "FullName", purchaseOrder.CustomerId);
            return View(purchaseOrder);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PurchaseOrder purchaseOrder = this.servise.GetOrder(id);
            EditOrderVm order = Mapper.Map<PurchaseOrder, EditOrderVm>(purchaseOrder);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(this.servise.CustomersList(), "Id", "FullName", order.CustomerId);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Price,Quantity,Status,CustomerId")] EditOrderVm purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                this.servise.EditOrder(purchaseOrder.Id, purchaseOrder.Description, purchaseOrder.Price, purchaseOrder.Quantity, purchaseOrder.Status, purchaseOrder.CustomerId);
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(this.servise.CustomersList(), "Id", "FirstName", purchaseOrder.CustomerId);
            return View(purchaseOrder);
        }

        // GET: Home/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PurchaseOrder purchaseOrder = this.servise.GetOrder(id);
            EditOrderVm order = Mapper.Map<PurchaseOrder, EditOrderVm>(purchaseOrder);

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.servise.DeleteOrder(id);
            return RedirectToAction("Index");
        }


        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = this.servise.GetOrder(id);
            EditOrderVm order = Mapper.Map<PurchaseOrder, EditOrderVm>(purchaseOrder);

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }


    }
}