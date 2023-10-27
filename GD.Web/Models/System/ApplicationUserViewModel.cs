using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class ApplicationUserViewModel
    {
        public string Id { set; get; }

        [Required]
        [MaxLength(256)]
        public string Email { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }
        public string PhoneNumber { set; get; }

        [Required]
        public int LevelId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }

        public virtual LevelViewModel Level { set; get; }
        public virtual EmployeeViewModel Employee { set; get; }

    }

}