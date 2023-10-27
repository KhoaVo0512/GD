using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class SchoolViewModel
    {
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Code { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [MaxLength(500)]
        public string Address { set; get; }

        [MaxLength(4000)]
        public string ManageBy { set; get; }

        [MaxLength(4000)]
        public string Description { set; get; }

    }

}