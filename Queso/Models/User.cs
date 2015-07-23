using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Queso.Models
{
    public class User
    {
        public User() {
            Answers = new HashSet<Answer>();
        }

        [Key]
        public int UserID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public string Name
        {
            get { return (FirstName + " " + LastName); }
        }
        public string Initials
        {
            get { return (FirstName.Substring(0,1) + LastName.Substring(0,1)); }
        }
    }
}