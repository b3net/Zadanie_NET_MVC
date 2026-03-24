using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Project.Models;
using Project.Infrastructure;
using Project.Resources;
using Project.Infrastructure.Message;

namespace Project.Controllers
{
    public class MessagesController : Controller
    {
        private readonly MessageRepository _repository;

        public MessagesController()
        {
            var storage = new MessageFileStorage();
            _repository = new MessageRepository(storage);
        }

        public ActionResult List(string sortOrder, int? page)
        {
            ViewBag.Title = AppResources.MessagesTitle;

            int pageNumber = page ?? 1;
            int totalPages;
            var model = new MessageListViewModel
            {
                Messages = _repository.GetMessages(sortOrder, pageNumber, out totalPages, 5),
                Pagination = new PaginationViewModel {
                    CurrentPage = pageNumber,
                    TotalPages = totalPages,
                },
                CurrentSort = sortOrder,
                FirstNameSortParm = sortOrder == "first_name" ? "first_name_desc" : "first_name",
                LastNameSortParm = sortOrder == "last_name" ? "last_name_desc" : "last_name",
                EmailSortParm = sortOrder == "email" ? "email_desc" : "email",
                DateSortParm = string.IsNullOrEmpty(sortOrder) || sortOrder == "date" ? "date_desc" : "date"
            };
            return View("List", model);
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

                    TempData[NotificationKeys.Success] = AppResources.SuccessMessage;

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
