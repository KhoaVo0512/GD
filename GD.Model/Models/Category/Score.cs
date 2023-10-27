using GD.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    [Table("Scores")]
    public class Score : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public int ScholasticId { set; get; }

        [Required]
        public int CourseId { set; get; }

        [Required]
        public int GradeId { set; get; }

        [Required]
        public int StudentId { set; get; }

        public string Code { set; get; }

        public string FullName { set; get; }

        public DateTime BirthDay { set; get; }

        public decimal? PointDDGTXOne { set; get; }

        public decimal? PointDDGTXTwo { set; get; }

        public decimal? PointDDGTXThree { set; get; }

        public decimal? PointDDGTXFour { set; get; }

        public decimal? PointDDGTXFive { set; get; }

        public decimal? PointDDGGK { set; get; }

        public decimal? PointDDGCK { set; get; }

        public decimal? PointDTBMHK { set; get; }

        public int Type { set; get; }

        [ForeignKey("ScholasticId")]
        public virtual Scholastic Scholastic { set; get; }

        [ForeignKey("CourseId")]
        public virtual Course Course { set; get; }

        [ForeignKey("GradeId")]
        public virtual Grade Grade { set; get; }

        [ForeignKey("StudentId")]
        public virtual Student Student { set; get; }

    }
}
