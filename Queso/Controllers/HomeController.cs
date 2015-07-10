using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Queso.Models;

namespace Queso.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<User> users;
            using (var db = new QuesoContext())
            {
                users = db.Users.ToList();
                ViewBag.Users = users;
            }
            return View(users);
        }
    }
}