using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class TypeScoreViewModel
    {
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        [Required]
        [Range(0, 99, ErrorMessage = "Vui lòng nhập số")]
        public decimal Point { set; get; }

    }

}