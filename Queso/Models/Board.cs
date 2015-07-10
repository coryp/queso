using System;
using System.ComponentModel.DataAnnotations;

namespace Queso.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public bool Active { get; set; }
    }
}