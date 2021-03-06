using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Queso.Models
{
    public class Board
    {
        public Board()
        {
        }

        [Key]
        public int BoardID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public bool Active { get; set; }
    }
}