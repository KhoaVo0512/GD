using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class QuestionViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }

        public int TypeId { set; get; }

        public int LevelId { set; get; }

        public bool ManyAnswer { set; get; }

        public int LineNumber { set; get; }

        public int TopicId { set; get; }

        public decimal Point { set; get; }

    }

}