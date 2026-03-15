using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Project.Models;
using Project.Infrastructure;
using Project.Resources;

namespace Project.Controllers
{
    public class MessagesController : Controller
    {
        private readonly MessageRepository _repository;

        public MessagesController()
        {
            _repository = new MessageRepository();
        }

        public ActionResult List(string sortOrder, int? page)
        {
            ViewBag.Title = AppResources.MessagesTitle;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = sortOrder == "first_name" ? "first_name_desc" : "first_name";
            ViewBag.LastNameSortParm = sortOrder == "last_name" ? "last_name_desc" : "last_name";
            ViewBag.EmailSortParm = sortOrder == "email" ? "email_desc" : "email";
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder == "date" ? "date_desc" : "date";

            int pageNumber = (page ?? 1);
            int totalPages = 0;

            List <MessageModel> messages = _repository.GetMessages(sortOrder, pageNumber, out totalPages, 5);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = pageNumber;

            return View("List", messages);
        }

        public ActionResult Create()
        {
            ViewBag.Title = AppResources.CreateTitle;
            return View(new MessageModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageModel model)
        {
            ViewBag.Title = AppResources.CreateTitle;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Id = Guid.NewGuid();
                    model.CreatedAt = DateTime.Now;
                    _repository.Add(model);
                    TempData["SuccessMessage"] = AppResources.SuccessMessage;
                    return RedirectToAction("List");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", AppResources.ErrorMessage);
                }
            }
            return View(model);
        }
    }
}
