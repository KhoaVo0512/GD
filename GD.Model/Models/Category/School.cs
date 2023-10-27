using GD.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Schools")]
    public class School : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Code { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [MaxLength(500)]
        public string Address { set; get; }

        [MaxLength(4000)]
        public string Description { set; get; }

        [MaxLength(4000)]
        public string ManageBy { set; get; }

        public virtual IEnumerable<GradeGroup> GradeGroups { set; get; }
    }
}
