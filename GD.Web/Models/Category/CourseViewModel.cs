using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class CourseViewModel
    {
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        public int GradeGroupId { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        [Range(0, 999.99)]
        public decimal Point { set; get; }

    }

}