using GD.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GD.Model.Models
{
    public class Result
    {
        public bool Status { set; get; }
        public int ID { set; get; }
        public string IDString { set; get; }
        public string Notication { set; get; }
    }
}
