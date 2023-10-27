using GD.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GD.Web.Models
{
    public class ObjectReportViewModel
    {
        object data;
        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        public int Count { set; get; }

    }

}