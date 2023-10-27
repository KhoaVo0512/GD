using GD.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Model.Models
{
    [Table("Employees")]
    public class Employee : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(4000)]
        public string EditorLink { get; set; }

    }
}
