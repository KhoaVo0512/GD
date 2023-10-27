using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class GradeViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public int Number { set; get; }

        public string Prefix { set; get; }

        public int ScholasticId { set; get; }

        public int GradeGroupId { set; get; }

        public string Description { set; get; }

    }

}