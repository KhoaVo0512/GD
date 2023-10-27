using GD.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("TestQuestions")]
    public class TestQuestion : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public int TestId { set; get; }

        [Required]
        public int QuestionId { set; get; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { set; get; }

        [ForeignKey("TestId")]
        public virtual Test Test { set; get; }
    }
}
