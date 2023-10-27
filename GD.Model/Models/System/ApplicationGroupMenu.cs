using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("ApplicationGroupMenus")]
    public class ApplicationGroupMenu
    {
        [Key]
        [Column(Order = 1)]
        public int GroupId { set; get; }

        [Key]
        [Column(Order = 2)]
        public int MenuId { set; get; }

        [ForeignKey("MenuId")]
        public virtual Menu Menu { set; get; }

        [ForeignKey("GroupId")]
        public virtual ApplicationGroup ApplicationGroup { set; get; }
    }
}
