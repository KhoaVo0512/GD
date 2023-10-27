using GD.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("UserGradeGroups")]
    public class UserGradeGroup : Auditable
    {
        [StringLength(128)]
        [Key]
        [Column(Order = 1)]
        public string UserId { set; get; }

        [Key]
        [Column(Order = 2)]
        public int GradeGroupId { set; get; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { set; get; }

        [ForeignKey("GradeGroupId")]
        public virtual GradeGroup GradeGroup { set; get; }
    }
}
