using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Queso.Models
{
    public class TaskPool
    {

        [Key]
        public int TaskID { get; set; }
        public string Name { get; set; }
        public bool Challenge { get; set; }
        public bool Active { get; set; }

        public static List<TaskPool> Random(int count = 25)
        {
            List<TaskPool> tasks;
            using (var db = new QuesoContext())
            {
                tasks = db.TaskPool
                    .OrderBy(t => Guid.NewGuid())
                    .Where(t => t.Active)
                    .Where(t => !t.Challenge)
                    .Take(count-1).ToList();

                var challenge = db.TaskPool
                    .OrderBy(t => Guid.NewGuid())
                    .Where(t => t.Active)
                    .Where(t => t.Challenge)
                    .Take(1).FirstOrDefault();
                tasks.Add(challenge);
            }
            return tasks;
        }
    }
}