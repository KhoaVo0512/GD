using GD.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("MenuGroups")]
    public class MenuGroup : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        public string Caption { set; get; }

        [MaxLength(4000)]
        public string ClassIcon { set; get; }

        public int DisplayOrder { set; get; }

        public int DisplayPosition { set; get; }

        public virtual IEnumerable<Menu> Menus { set; get; }
    }
}
