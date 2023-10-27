using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class WardViewModel
    {
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [MaxLength(256)]
        public string Code { set; get; }

        [Required]
        public int DistrictId { set; get; }

    }

}