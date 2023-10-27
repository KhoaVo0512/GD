using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class TestViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public int Time { set; get; }

        public string View { set; get; }

    }

}