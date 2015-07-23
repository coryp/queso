using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Queso.Models
{
    public class BoardTask
    {
        public BoardTask()
        {
            Answers = new HashSet<Answer>();
        }

        [Key]
        public int BoardTaskID { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Task Task { get; set; }
        public virtual Board Board { get; set; }
    }
}