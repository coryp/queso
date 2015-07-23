using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Queso.Models
{
    public class Task
    {
        [Key]
        public int TaskID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Challenge { get; set; }


        public static List<Task> Random(int count=24)
        {
            List<Task> tasks;
            using (var db = new QuesoContext())
            {
                tasks = db.Tasks
                    .OrderBy(t => Guid.NewGuid())
                    .Where(t=>t.Active)
                    .Where(t=>!t.Challenge)
                    .Take(count).ToList();
            }
            return tasks;
        }
    }
}