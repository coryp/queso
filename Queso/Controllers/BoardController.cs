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
                board = db.Boards.OrderBy(x => x.BoardID).FirstOrDefault();
            }
            return View(board);
        }

        public ActionResult Show(int id)
        {
            using (var db = new QuesoContext())
            {
                board = db.Boards.Find(id);
            }
            return View(board);
        }

        public ActionResult New()
        {
            using (var db = new QuesoContext())
            {
                board = new Board();
                board.Active = true;
    

                var tasks = Task.Random(24);
                foreach (var task in tasks)
                {
                    var boardTask = new BoardTask()
                    {
                        Task = task
                    };
                    board.BoardTasks.Add(boardTask);
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
