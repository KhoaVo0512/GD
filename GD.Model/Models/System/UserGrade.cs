using GD.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("UserGrades")]
    public class UserGrade : Auditable
    {
        [StringLength(128)]
        [Key]
        [Column(Order = 1)]
        public string UserId { set; get; }

        [Key]
        [Column(Order = 2)]
        public int GradeId { set; get; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { set; get; }

        [ForeignKey("GradeId")]
        public virtual Grade Grade { set; get; }
    }
}
