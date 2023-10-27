using GD.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Questions")]
    public class Question : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }

        [Required]
        public int TypeId { set; get; }

        [Required]
        public int LevelId { set; get; }

        public bool ManyAnswer { set; get; }

        public int LineNumber { set; get; }

        [Required]
        public int TopicId { set; get; }

        public decimal Point { set; get; }


        [ForeignKey("TypeId")]
        public virtual TypeQuestion TypeQuestion { set; get; }

        [ForeignKey("LevelId")]
        public virtual LevelQuestion LevelQuestion { set; get; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { set; get; }
    }
}
