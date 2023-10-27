using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class ExamViewModel
    {
        public int ID { set; get; }

        public string Code { set; get; }

        public string Name { set; get; }

        public int NumberTest { set; get; }

        public int TopicId { set; get; }

        public int Time { set; get; }

        public string View { set; get; }
    }

}