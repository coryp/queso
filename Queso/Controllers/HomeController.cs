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
            User user;
            var answer = new Answer()
            {
                Message = "hi mom",
                CreatedAt = DateTime.Now,
                CaseNumber = "2323322"
            };

            using (var db = new QuesoContext())
            {
                user = db.Users.Where(x => x.UserID == 1).FirstOrDefault();
                user.Answers.Add(answer);
                db.SaveChanges();

                ViewBag.User = user;
            }

            return View(user);
        }
    }
}