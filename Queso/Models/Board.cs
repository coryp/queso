using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Queso.Models
{
    public class Board
    {
        public Board()
        {
            BoardTasks = new HashSet<BoardTask>();
            Answers = new HashSet<Answer>();
        }

        [Key]
        public int BoardID { get; set; }
        
        public DateTime? CreatedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public bool Active { get; set; }


        public virtual ICollection<BoardTask> BoardTasks { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}