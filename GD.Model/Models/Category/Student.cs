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
    [Table("Students")]
    public class Student : Auditable
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

        public int ProvinceId { set; get; }

        public int DistrictId { set; get; }

        public int WardId { set; get; }

        [MaxLength(256)]
        public string Street { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { set; get; }

        [ForeignKey("DistrictId")]
        public virtual District District { set; get; }

        [ForeignKey("WardId")]
        public virtual Ward Ward { set; get; }

        public virtual IEnumerable<Score> Scores { set; get; }


    }
}
