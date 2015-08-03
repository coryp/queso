using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Queso.Models
{
    public class Task
    {
        public Task ()
        {
            
        }

        [Key]
        public int TaskID { get; set; }
        public string Name { get; set; }
        public bool Challenge { get; set; }

        public virtual Board Board { get; set; }


       
    }
}