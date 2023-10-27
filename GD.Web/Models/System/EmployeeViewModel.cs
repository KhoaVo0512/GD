using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class EmployeeViewModel
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
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Vui lòng nhập đúng số điện thoại.")]
        public string PhoneNumber { set; get; }

        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(4000)]
        public string EditorLink { get; set; }

    }

}