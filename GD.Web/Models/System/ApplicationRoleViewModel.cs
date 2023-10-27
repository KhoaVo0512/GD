using System.ComponentModel.DataAnnotations;

namespace GD.Web.Models
{
    public class ApplicationRoleViewModel
    {
        public string Id { set; get; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$",
         ErrorMessage = "Only characters")]
        public string Name { set; get; }
        [Required]
        public string Description { set; get; }
    }

}