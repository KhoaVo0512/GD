using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class StudentGradeViewModel
    {
        public int ID { set; get; }

        public int StudentId { set; get; }

        public int GradeId { set; get; }

        public int ScholasticId { set; get; }

    }

}