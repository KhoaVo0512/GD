using GD.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Puzzles")]
    public class Puzzle : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [MaxLength(4000)]
        public string Suggest { set; get; }

        [MaxLength(4000)]
        public string Answer { set; get; }

        [MaxLength(4000)]
        public string Description { set; get; }

    }
}
