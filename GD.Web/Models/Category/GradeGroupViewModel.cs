using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class GradeGroupViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public int Number { set; get; }

        [Required]
        public int SchoolId { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

    }

}