using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class PuzzleViewModel
    {
        public int ID { set; get; }

        [MaxLength(4000)]
        public string Suggest { set; get; }

        [MaxLength(4000)]
        public string Answer { set; get; }

        [MaxLength(4000)]
        public string Description { set; get; }

    }

}