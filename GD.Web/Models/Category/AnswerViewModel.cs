using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class AnswerViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }

        public bool Correct { set; get; }

        public int QuestionId { set; get; }

        [Column(TypeName = "ntext")]
        public string ContentAnswerEdit {
            get
            {
                return Content;
            }
        }

    }

}