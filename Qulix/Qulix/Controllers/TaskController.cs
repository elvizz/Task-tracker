using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qulix.Models;
using Qulix.Models.Repository;

namespace Qulix.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult List()
        {
            ViewBag.Message = "Список текущих задач на проект";

            ViewData["States"] = DAL.State.GetStates();
            ViewData["Users"] = DAL.User.GetUsers();
            
            return View(DAL.Task.GetTasks());
        }

        public ActionResult Delete(Guid Id)
        {
            DAL.Task.DeleteTask(Id);
            return RedirectToAction("List");
        }

        public ActionResult Edit(Guid id)
        {
            Tasks task = DAL.Task.GetTaskById(id);
            ViewData["States"] = new SelectList(DAL.State.GetStates(), "StateId", "Title",task.StateId);
            ViewData["Users"] = new SelectList(DAL.User.GetUsers(), "UserId", "FirstName",task.PersonId);
            
            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(Guid id,Tasks task)
        {
            if(ModelState.IsValid)
            {
                task.TaskId = id;
                DAL.Task.UpdateTask(task);
            }
            return RedirectToAction("List");
        }

        public ActionResult Create()
        {
            ViewData["States"] = new SelectList(DAL.State.GetStates(), "StateId", "Title");
            ViewData["Users"] = new SelectList(DAL.User.GetUsers(), "UserId", "FirstName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Tasks task)
        {
            if (ModelState.IsValid)
            {
                DAL.Task.CreateTask(task);
            }
            return RedirectToAction("List");
        }
        
   }
}
