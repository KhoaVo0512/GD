using GD.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Exams")]
    public class Exam : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Code { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        public int Time { set; get; }

        [Required]
        public int NumberTest { set; get; }

        [Required]
        public int TopicId { set; get; }

        public string View { set; get; }


        [ForeignKey("TopicId")]
        public virtual Topic Topic { set; get; }
    }
}
