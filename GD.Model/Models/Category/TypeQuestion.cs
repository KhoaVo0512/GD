using GD.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("TypeQuestions")]
    public class TypeQuestion : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        public bool Choice { set; get; }

        public int DisplayOrder { set; get; }

        public virtual IEnumerable<LevelQuestion> LevelQuestions { set; get; }
    }
}
