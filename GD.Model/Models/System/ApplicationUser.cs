using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GD.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        [Required]
        public int EmployeeId { set; get; }

        [Required]
        public int LevelId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [ForeignKey("LevelId")]
        public virtual Level Level { set; get; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { set; get; }

        public virtual IEnumerable<GradeGroup> GradeGroups { set; get; }

        public virtual IEnumerable<Course> Courses { set; get; }
    }
}
