using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DotNetOpenAuth.Messaging;
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
                board = db.Boards.Include("Tasks").FirstOrDefault(x => x.BoardID == id);

                if (board != null)
                {
                    var temp = board.Tasks.ToList();
                    board.Tasks = new List<Task>();

                    board.Tasks.AddRange(temp.GetRange(0,12));
                    board.Tasks.Add(temp.Last());
                    board.Tasks.AddRange(temp.GetRange(12,12));
                }
            }

            return View(board);
        }

        public ActionResult Edit(int id)
        {
            Board board;
            using (var db = new QuesoContext())
            {
                board = db.Boards.FirstOrDefault(x => x.BoardID == id);
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

        [HttpPost]
        public ActionResult Answer(int UserID, int TaskID, string CaseNumber)
        {
            using (var db = new QuesoContext())
            {
                var task = db.Tasks.Where(x => x.TaskID == TaskID).FirstOrDefault();
                var user = db.Users.Where(x => x.UserID == UserID).FirstOrDefault();
                
                var answer = new Answer();
                answer.Task = task;
                answer.User = user;
                answer.CreatedAt = System.DateTime.Now;
                answer.CaseNumber = CaseNumber;

                db.Answers.Add(answer);
                db.SaveChanges();
            }
            return Redirect("/Board");
        }
    }
}
