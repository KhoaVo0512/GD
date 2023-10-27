using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GD.Web.Models
{
    public class ApplicationGroupViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public IEnumerable<ApplicationRoleViewModel> Roles { set; get; }

    }

}