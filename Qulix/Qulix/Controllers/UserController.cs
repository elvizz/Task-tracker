using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qulix.Models;

namespace Qulix.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult List()
        {
            return View(DAL.User.GetUsers());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Users user)
        {
            if (ModelState.IsValid)
            {
                DAL.User.CreateUser(user);
            }
          return RedirectToAction("List");
        }

        public ActionResult Delete(Guid id)
        {
            DAL.User.DeleteUser(id);
            return RedirectToAction("List");
        }

        public ActionResult Edit(Guid id)
        {
            return View(DAL.User.GetUserById(id));
        }

        [HttpPost]
        public ActionResult Edit(Guid id,Users user)
        {
            if (ModelState.IsValid)
            {
                user.UserId = id;
                DAL.User.UpdateUser(user);
            }
            return RedirectToAction("List");
        }
    }
}
