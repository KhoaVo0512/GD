using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class StudentViewModel
    {
        public int ID { set; get; }

        [MaxLength(256)]
        public string Code { set; get; }

        [Required]
        [MaxLength(256)]
        public string FullName { set; get; }

        public bool Male { set; get; }

        public DateTime BirthDay { set; get; }

        [MaxLength(256)]
        public string PhoneNumber { set; get; }

        public int ProvinceId { set; get; }

        public int DistrictId { set; get; }

        public int WardId { set; get; }

        [MaxLength(256)]
        public string Street { get; set; }

    }

}