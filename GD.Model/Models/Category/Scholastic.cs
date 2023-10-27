using GD.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Scholastics")]
    public class Scholastic : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        public DateTime FromTime { set; get; }

        [Required]
        public DateTime ToTime { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public virtual IEnumerable<Grade> Grades { set; get; }
    }
}
