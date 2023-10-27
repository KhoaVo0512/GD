using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class FileViewModel
    {
        public int ID { set; get; }

        [Required]
        [MaxLength(4000)]
        public string Name { set; get; }

        public double Size { set; get; }

        [MaxLength(4000)]
        public string Path { set; get; }

        [MaxLength(4000)]
        public string PreviewImage { set; get; }

        public int Type { set; get; }

        public int Category { set; get; }

        public string Author { set; get; }

        public int CourseId { set; get; }

        public int TopicId { set; get; }

        [MaxLength(4000)]
        public string Description { set; get; }

        public string ApproveBy { set; get; }

    }

}