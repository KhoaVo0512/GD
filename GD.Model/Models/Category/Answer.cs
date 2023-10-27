using GD.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Answers")]
    public class Answer : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }

        public bool Correct { set; get; }

        [Required]
        public int QuestionId { set; get; }


        [ForeignKey("QuestionId")]
        public virtual Question Question { set; get; }
    }
}
