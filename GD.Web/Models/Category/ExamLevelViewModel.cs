using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class ExamLevelViewModel
    {
        public int ID { set; get; }

        public int ExamId { set; get; }

        public int LevelId { set; get; }

        public int Number { set; get; }

        public int Type { set; get; }

        public int TypePoint { set; get; }

        public decimal? SumPoint { set; get; }
    }

}