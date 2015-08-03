using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Queso.Models;

namespace Queso.Controllers
{
    public class BoardController : Controller
    {
                  
        private Board board { get; set; }

        public ActionResult Index()
        {
            using (var db = new QuesoContext())
            {
                board = db.Boards.OrderByDescending(x => x.BoardID).FirstOrDefault();
            }
            return Redirect("/Board/Show/" + board.BoardID);
        }

        public ActionResult Show(int id)
        {
            using (var db = new QuesoContext())
            {
                //board = db.Boards.Find(id);
                board = db.Boards.Include("Tasks").Where(x => x.BoardID == id).FirstOrDefault();
            }
            return View(board);
        }

        public ActionResult New()
        {
            using (var db = new QuesoContext())
            {
                board = new Board();
                board.Active = true;
    

                var poolTasks = TaskPool.Random();
                foreach (var poolTask in poolTasks)
                {
                    var task = new Task()
                    {
                        Name = poolTask.Name,
                        Challenge = poolTask.Challenge                        
                    };
                    board.Tasks.Add(task);
                }
                db.Boards.Add(board);
                db.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {
            return null;
        }
    }
}
