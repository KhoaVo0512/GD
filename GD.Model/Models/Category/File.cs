using GD.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Files")]
    public class File : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(4000)]
        public string Name { set; get; }

        public double Size { set; get; }

        [MaxLength(4000)]
        public string Path { set; get; }

        [MaxLength(4000)]
        public string PreviewImage { set; get; }

        public int Type { set; get; }

        public int Category { set; get; }

        public string Author { set; get; }

        [Required]
        public int CourseId { set; get; }

        [Required]
        public int TopicId { set; get; }

        [MaxLength(4000)]
        public string Description { set; get; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { set; get; }

        [ForeignKey("CourseId")]
        public virtual Course Course { set; get; }
    }
}
