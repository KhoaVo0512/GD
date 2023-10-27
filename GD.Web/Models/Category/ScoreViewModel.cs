using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class ScoreViewModel
    {
        public int ID { set; get; }

        public int ScholasticId { set; get; }

        public int CourseId { set; get; }

        public int GradeId { set; get; }

        public int StudentId { set; get; }

        public string Code { set; get; }

        public string FullName { set; get; }

        public DateTime BirthDay { set; get; }

        public string BirthDayText
        {
            get
            {
                return BirthDay.ToString("dd/MM/yyyy");
            }

        }

        public decimal? PointDDGTXOne { set; get; }

        public decimal? PointDDGTXTwo { set; get; }

        public decimal? PointDDGTXThree { set; get; }

        public decimal? PointDDGTXFour { set; get; }

        public decimal? PointDDGTXFive { set; get; }

        public decimal? PointDDGGK { set; get; }

        public decimal? PointDDGCK { set; get; }

        public decimal? PointDTBMHK { set; get; }

        public int Type { set; get; }

    }

}