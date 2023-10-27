using GD.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("GradeGroups")]
    public class GradeGroup : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        public int Number { set; get; }

        [Required]
        public int SchoolId { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        [ForeignKey("SchoolId")]
        public virtual School School { set; get; }

        public virtual IEnumerable<Grade> Grades { set; get; }

        public virtual IEnumerable<Course> Courses { set; get; }
    }
}
