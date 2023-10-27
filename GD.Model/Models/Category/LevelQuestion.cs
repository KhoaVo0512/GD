using GD.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("LevelQuestions")]
    public class LevelQuestion : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        public int TypeId { set; get; }

        public int DisplayOrder { set; get; }

        [ForeignKey("TypeId")]
        public virtual TypeQuestion TypeQuestion { set; get; }
    }
}
