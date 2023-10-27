using GD.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("ExamLevels")]
    public class ExamLevel : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public int ExamId { set; get; }

        [Required]
        public int LevelId { set; get; }

        public int Number { set; get; }

        public int Type { set; get; }

        public int TypePoint { set; get; }

        public decimal SumPoint { set; get; }

        [ForeignKey("ExamId")]
        public virtual Exam Exam { set; get; }


        [ForeignKey("LevelId")]
        public virtual LevelQuestion LevelQuestion { set; get; }
    }
}
