using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Queso.Models
{
    public class BoardTask
    {
        public BoardTask()
        {
        }

        [Key]
        public int BoardTaskID { get; set; }
    }
}