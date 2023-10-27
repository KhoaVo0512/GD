using GD.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Wards")]
    public class Ward : Auditable
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
        public int DistrictId { set; get; }

        [ForeignKey("DistrictId")]
        public virtual District District { set; get; }
    }
}
