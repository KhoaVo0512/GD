using GD.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Topics")]
    public class Topic : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        public int CourseId { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        [ForeignKey("CourseId")]
        public virtual Course Course { set; get; }

        public virtual IEnumerable<Exam> Exams { set; get; }
    }
}
