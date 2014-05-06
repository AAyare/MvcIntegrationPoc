using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MvcPoc.Web.DAL
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Boolean? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}