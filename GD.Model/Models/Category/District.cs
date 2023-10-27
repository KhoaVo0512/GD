using GD.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Districts")]
    public class District : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [MaxLength(256)]
        public string Code { set; get; }

        [Required]
        public int ProvinceId { set; get; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { set; get; }

        public virtual IEnumerable<Ward> Wards { set; get; }
    }
}
