using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class TopicViewModel
    {
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        public int CourseId { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

    }

}