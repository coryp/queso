using System;
using System.ComponentModel.DataAnnotations;

namespace Queso.Models
{
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CaseNumber { get; set; }
        public string Message { get; set; }

        public virtual User User { get; set; }
        public virtual Task Task { get; set; }
    }
}