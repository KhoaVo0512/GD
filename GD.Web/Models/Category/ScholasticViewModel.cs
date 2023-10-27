using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class ScholasticViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        [Required]
        public DateTime FromTime { set; get; }

        [Required]
        public DateTime ToTime { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

    }

}