using GD.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Courses")]
    public class Course : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        public int GradeGroupId { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public decimal Point { set; get; }

        [ForeignKey("GradeGroupId")]
        public virtual GradeGroup GradeGroup { set; get; }

        public virtual IEnumerable<Topic> Topics { set; get; }
    }
}
