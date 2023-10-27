using GD.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("ExamTests")]
    public class ExamTest : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public int ExamId { set; get; }

        [Required]
        public int TestId { set; get; }

        [ForeignKey("ExamId")]
        public virtual Exam Exam { set; get; }

        [ForeignKey("TestId")]
        public virtual Test Test { set; get; }
    }
}
