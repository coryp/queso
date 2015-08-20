using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Queso.Models;

namespace Queso.Controllers
{
    public class UserController : Controller
    {

 

        [HttpPost]
        public ActionResult Login(int UserID)
        {
            using (var db = new QuesoContext())
            {
                Session["UserID"] = db.Users.Find(UserID).UserID;
                return Redirect("/Board");
            }
        }
    }
}
