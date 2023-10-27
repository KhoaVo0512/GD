using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class MenuViewModel
    {
        public int ID { set; get; }
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        public string Caption { set; get; }

        [Required]
        [MaxLength(4000)]
        public string URL { set; get; }
        public int? DisplayOrder { set; get; }
        [Required]
        public int GroupId { set; get; }

        [MaxLength(4000)]
        public string Icon { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }
        public virtual MenuGroupViewModel MenuGroup { set; get; }

    }

}