using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Queso.Models
{
    public class QuesoContext:DbContext
    {
        public QuesoContext() : base("DefaultConnection") { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<TaskPool> TaskPool { get; set; }
    }
}