using System;
using System.ComponentModel.DataAnnotations;

namespace Queso.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Challenge { get; set; }
    }
}