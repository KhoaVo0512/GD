using GD.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("StudentGrades")]
    public class StudentGrade : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public int StudentId { set; get; }

        [Required]
        public int GradeId { set; get; }

        [Required]
        public int ScholasticId { set; get; }

        [ForeignKey("ScholasticId")]
        public virtual Scholastic Scholastic { set; get; }

        [ForeignKey("StudentId")]
        public virtual Student Student { set; get; }

        [ForeignKey("GradeId")]
        public virtual Grade Grade { set; get; }
    }
}
