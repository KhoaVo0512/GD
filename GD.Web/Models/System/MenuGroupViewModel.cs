using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class MenuGroupViewModel
    {
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        public string Caption { set; get; }

        [MaxLength(4000)]
        public string ClassIcon { set; get; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số")]
        public int DisplayOrder { set; get; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số")]
        public int DisplayPosition { set; get; }

        public virtual IEnumerable<MenuViewModel> Menus { set; get; }

    }

}