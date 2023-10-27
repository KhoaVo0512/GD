using GD.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Grades")]
    public class Grade : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        public int Number { set; get; }

        public string Prefix { set; get; }

        [Required]
        public int ScholasticId { set; get; }

        [Required]
        public int GradeGroupId { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        [ForeignKey("ScholasticId")]
        public virtual Scholastic Scholastic { set; get; }

        [ForeignKey("GradeGroupId")]
        public virtual GradeGroup GradeGroup { set; get; }
    }
}
