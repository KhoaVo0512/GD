using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GD.Model.Abstract;

namespace GD.Model.Models
{
    [Table("Menus")]
    public class Menu : Auditable
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

        [Required]
        [MaxLength(4000)]
        public string URL { set; get; }
        public int? DisplayOrder { set; get; }
        [Required]
        public int GroupId { set; get; }
        
        [MaxLength(4000)]
        public string Icon { get; set; }
        
        [MaxLength(4000)]
        public string Description { get; set; }
        [ForeignKey("GroupId")]
        public virtual MenuGroup MenuGroup { set; get; }
    }
}
