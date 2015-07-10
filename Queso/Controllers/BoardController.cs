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
        private QuesoContext db 
        { 
            get { return new QuesoContext(); }
        }
        private Board board { get; set; }

        public ActionResult Index()
        {
            using (db)
            {
                board = db.Boards.OrderBy(x => x.BoardID).FirstOrDefault();
            }
            return View(board);
        }

        public ActionResult Show(int id)
        {
            using (db)
            {
                board = db.Boards.Find(id);
            }
            return View(board);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Board board)
        {
            //board.Tasks = Task.Random(24);
            using (db)
            {
                db.Boards.Add(board);
                db.SaveChanges();
            }
            return RedirectToAction("/Boards/Show?" + board.BoardID);
        }
    }
}
